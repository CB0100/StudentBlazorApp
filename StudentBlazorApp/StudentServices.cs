using Microsoft.EntityFrameworkCore;
using StudentBlazorApp.Data;

namespace StudentBlazorApp
{
    public class StudentServices
    {
        public int stdid;
        public bool shownav = true;
        public int role = 1;
        private readonly ApplicationDbContext _dbContext;

        public StudentServices(ApplicationDbContext DBContext)
        {
            _dbContext = DBContext;
        }

        public async Task<string> GetRegistrationId()
        {
            string RegistrationId = string.Empty;
            int RegNo = 0;
            RegNo = await _dbContext.TblStudents.AnyAsync() ? await _dbContext.TblStudents.MaxAsync(m => m.StudentId) : 0;
            RegNo = RegNo == 0 ? 1 : (RegNo+1);
            RegistrationId = "STU" + RegNo.ToString("D6") /*string.Format("0:000000", RegNo)*/;
            return RegistrationId;
        }

        public async Task<List<ViewModel>> GetQualificationList()
        {
            List<TblStudent> students = await _dbContext.TblStudents.ToListAsync();
            List<TblQualification> qualification = await _dbContext.TblQualifications.ToListAsync();
            var qualificationlist = from e in students
                                    join d in qualification on e.StudentId equals d.StudentId into table1
                                    from d in table1.ToList()
                                    select new ViewModel
                                    {
                                        student = e,
                                        Qualification = d
                                    };
            return await Task.Run(() => qualificationlist.ToList());
        }

        public async Task<List<ViewModel>> GetHobbyList()
        {
            List<Hobby> hobbies = await _dbContext.Hobbies.ToListAsync();
            List<Hobby2StudentMapp> h2smaps = await _dbContext.Hobby2StudentMapps.ToListAsync();
            var hobbylist = from e in h2smaps
                            join d in hobbies on e.HobbyId equals d.HobbyId into table1
                            from d in table1.ToList()
                            select new ViewModel
                            {
                                singlehobbies = d,
                                hobbieslist = e
                            };

            return await Task.Run(() => hobbylist.ToList());
        }

        public async Task<List<ViewModel>> GetStudentsList()
        {
            List<TblStudent> students = await _dbContext.TblStudents.ToListAsync();
            List<Country> countries = await _dbContext.Countries.ToListAsync();
            List<Role> roleslist = await _dbContext.Roles.ToListAsync();
            List<State> states = await _dbContext.States.ToListAsync();
            List<City> cities = await _dbContext.Cities.ToListAsync();
            var studentList = from e in students
                              join d in countries on e.Country equals d.CountryId into table1
                              from d in table1.ToList()
                              join i in states on e.State equals i.StateId into table2
                              from i in table2.ToList()
                              join c in cities on e.City equals c.CityId into table3
                              from c in table3.ToList()
                              join k in roleslist on e.RoleId equals k.RoleId into table4
                              from k in table4.ToList()
                              select new ViewModel
                              {
                                  student = e,
                                  countryprop = d,
                                  stateprop = i,
                                  cityprop = c,
                                  RoleProp = k
                              };

            return await Task.Run(() => studentList.ToList());
        }

        public async Task<List<ViewModel>> GetCoursesList(int id)
        {
            List<Course2Student> c2slist = await _dbContext.Course2StudentMapps.Where(m => m.StudentId == id).ToListAsync();
            List<Specification> speclist = await _dbContext.Specifications.ToListAsync();
            List<TblStudent> students = await _dbContext.TblStudents.ToListAsync();
            List<Course> courses = await _dbContext.Courses.ToListAsync();
            List<Batch> batches = await _dbContext.Batches.ToListAsync();
            var Courselist = from e in c2slist
                             join d in courses on e.CourseId equals d.CourseId into table1
                             from d in table1.ToList()
                             join k in speclist on d.SpecId equals k.SpecId into table2
                             from k in table2.ToList()
                             join i in batches on e.BatchId equals i.BatchId into table3
                             from i in table3.ToList()
                             select new ViewModel
                             {
                                 c2sMapp = e,
                                 CourseProp = d,
                                 BatchProp = i,
                                 Specprop = k
                             };

            return await Task.Run(() => Courselist.ToList());
        }

        public async Task<List<ViewModel>> GettingCoursesList(List<Course2Student> c2slists)
        {
            List<Course2Student> c2slist = c2slists;
            List<TblStudent> students = await _dbContext.TblStudents.ToListAsync();
            List<Course> courses = await _dbContext.Courses.ToListAsync();
            List<Batch> batches = await _dbContext.Batches.ToListAsync();
            var Courselist = from e in c2slist
                             join d in courses on e.CourseId equals d.CourseId into table1
                             from d in table1.ToList()
                             join i in batches on e.BatchId equals i.BatchId into table2
                             from i in table2.ToList()
                             select new ViewModel
                             {
                                 c2sMapp = e,
                                 CourseProp = d,
                                 BatchProp = i
                             };

            return await Task.Run(() => Courselist.ToList());
        }

        public async Task<bool> InsertStudentsAsync(TblStudent employee)
        {
            await _dbContext.TblStudents.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TblStudent> GetStudentsAsync(int Id)
        {
            TblStudent employee = await _dbContext.TblStudents.FirstOrDefaultAsync(c => c.StudentId.Equals(Id));
            return employee;
        }

        public async Task<bool> UpdateStudentsAsync(TblStudent employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            //await _dbContext.TblStudents.Update(employee);
            _dbContext.TblStudents.Entry(employee).Property(x => x.StudentId).IsModified = false;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudentsAsync(TblStudent employee)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}