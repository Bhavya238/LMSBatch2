using System;
using System.ComponentModel.DataAnnotations;

namespace LMSBatch2.Models
{
    internal class MyDateAttribute : ValidationAttribute
    {
        public MyDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}