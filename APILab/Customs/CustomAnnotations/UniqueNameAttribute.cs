using APILab.Models;
using System.ComponentModel.DataAnnotations;

namespace APILab.Customs.CustomAnnotations
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = validationContext.GetService(typeof(AppMainContext)) as AppMainContext;

            var name = value?.ToString();

            var department = (Department)validationContext.ObjectInstance;

            bool exists = dbContext.departments.Any(d => d.Name == name && d.Id != department.Id);

            if (exists)
                return new ValidationResult("Department name already exists.");

            return ValidationResult.Success;
        }
    }
}
