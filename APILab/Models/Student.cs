using APILab.Customs.CustomAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILab.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public int SSN { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(12, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters and spaces are only allowed")]
        public string Name { get; set; }
        [DateInPast]
        public DateOnly DateOfBirth { get; set; }

        [Range(18,21, ErrorMessage = " Attr The Age should be between 18 and 20")]
        public int Age { get; set; }

        [UniqueEmail]
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public int Level { get; set; }


        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
