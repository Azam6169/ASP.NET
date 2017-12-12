using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidPlace.Models
{
    public class Min18YearsIfMemeber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            //pay as you option: birthdate is optional here
            if(customer.MembershipTypeId == MembershipType.PayAsyouGo || customer.MembershipTypeId == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }
            //Other plans require age to be over 18
            //Check if the date is provided
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate Required.");

            //Calculating age and validating input
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success:
                new ValidationResult("Customer has to be over 18 years old.");

        }
    }
}