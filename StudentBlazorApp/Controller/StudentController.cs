using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentBlazorApp.Data;

namespace StudentBlazorApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext DBContext)
        {
            _dbContext = DBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync()
        {
            List<TblStudent> students = await _dbContext.TblStudents.ToListAsync();
            List<Country> countries = await _dbContext.Countries.ToListAsync();
            List<State> states = await _dbContext.States.ToListAsync();
            List<City> cities = await _dbContext.Cities.ToListAsync();
            var studentList = from e in students
                              join d in countries on e.Country equals d.CountryId into table1
                              from d in table1.ToList()
                              join i in states on e.State equals i.StateId into table2
                              from i in table2.ToList()
                              join c in cities on e.City equals c.CityId into table3
                              from c in table3.ToList()
                              select new ViewModel
                              {
                                  student = e,
                                  countryprop = d,
                                  stateprop = i,
                                  cityprop = c
                              };

            return Ok(studentList);
        }
    }
}