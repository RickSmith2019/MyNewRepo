using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventBrightApplication.Models
{
    public class notZeroAttribute : ValidationAttribute
    {
        readonly int notzero;
        public notZeroAttribute(int notzero) :base("{0} must be greater then zero.")
        {
            this.notzero = notzero;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((int)value <= 0)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errormessage);
                }
            }
            return ValidationResult.Success;
        }
    }

}