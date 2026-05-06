using APILab.Models;
using System.ComponentModel.DataAnnotations;

namespace APILab.Customs.CustomAnnotations
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (AppMainContext)validationContext.GetService(typeof(AppMainContext)); // can make check if db == null 

            var email = value?.ToString();

            var student = (Student)validationContext.ObjectInstance;

            if (db.students.Any(s => s.Email.ToLower() == email.ToLower() && s.Id != student.Id))
            {

                return new ValidationResult("This Email Already Existed");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
