using APILab.Customs.CustomAnnotations;
using System.ComponentModel.DataAnnotations;

namespace APILab.Models
{
    public class Department
    {
        public int Id { get; set; }

        [UniqueName]
        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Manager { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
