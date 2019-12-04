using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventBrightApplication.Models
{
    public class greaterThanNowAttribute :ValidationAttribute
    {
        public greaterThanNowAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt < DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}