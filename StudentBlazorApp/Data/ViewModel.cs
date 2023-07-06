namespace StudentBlazorApp.Data
{
    public class ViewModel
    {
        public TblStudent student { get; set; }
        public State stateprop { get; set; }
        public Country countryprop { get; set; }
        public City cityprop { get; set; }
        public Course CourseProp { get; set; }
        public Batch BatchProp { get; set; }
        public Hobby singlehobbies { get; set; }
        public Hobby2StudentMapp hobbieslist { get; set; }
        public Course2Student c2sMapp { get; set; }
        public TblQualification Qualification { get; set; }
        public Specification Specprop { get; set; }
        public Role RoleProp { get; set; }
    }
}