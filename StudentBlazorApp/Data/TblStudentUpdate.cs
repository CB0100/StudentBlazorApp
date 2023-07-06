namespace StudentBlazorApp.Data
{
    public class TblStudentUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public bool IsActive { get; set; }

        public TblStudent ToTblStudent()
        {
            return new TblStudent
            {
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                FatherName = FatherName,
                MotherName = MotherName,
                Address = Address,
                ZipCode = ZipCode,
                City = City,
                State = State,
                Country = Country,
                IsActive = IsActive
            };
        }
    }
}