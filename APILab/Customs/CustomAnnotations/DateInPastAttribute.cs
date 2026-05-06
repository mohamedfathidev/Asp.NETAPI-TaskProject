using System.ComponentModel.DataAnnotations;

namespace APILab.Customs.CustomAnnotations
{
    public class DateInPastAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(!DateTime.TryParse(value.ToString(), out DateTime Date))
            {
                return new ValidationResult("Invalid date");
            }
            

            if (Date > DateTime.Now)
            {
                return new ValidationResult("The Date should be in the past");
            }

            int age = DateTime.Now.Year - Date.Year;

            if (age < 18 || age > 20)
            {
                return new ValidationResult("The Age should be between 18 and 20");
            }

            return ValidationResult.Success;
        }
    }
}
