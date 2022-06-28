using flent_Validation.Controllers;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace flent_Validation.Models
{
    public class Employee_Validation : AbstractValidator<Employee>
    {
     public Employee_Validation()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Employee Name is reqired");
            RuleFor(x => x.Mail_ID).NotEmpty().WithMessage("Employee Mail_ID is required");
            RuleFor(x => x.DOB).NotEmpty().WithMessage("Employee DOB is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Employee Password is required");
            RuleFor(x => x.Confirm_Passord).NotEmpty().WithMessage("Employee Password is required");
            RuleFor(x => x.Confirm_Passord).Equal(x => x.Password).WithMessage("Password Doesn't Match");

            RuleFor(x => x.Mail_ID).EmailAddress().WithMessage("Email Address is not correct");
            RuleFor(x => x.DOB).Must(validateAge).WithMessage("Age Must be 18 or older");
            RuleFor(x => x.Password).Must(passwordLength).WithMessage("Password length must be equal to or greater than 8");

        }

        internal ValidationResult Validate(EmployeeController emp)
        {
            throw new NotImplementedException();
        }

        private bool passwordLength(string pass)
        {
            if (pass.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateAge(DateTime Age)
        {
            DateTime Current = DateTime.Today;
            int age = Current.Year - Convert.ToDateTime(Age).Year;

            if (age < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
