using APILab.Models;

namespace APILab.Repos
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(AppMainContext context) : base(context) { }
    }
}
