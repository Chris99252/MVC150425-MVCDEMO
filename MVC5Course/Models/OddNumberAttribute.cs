using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class OddNumberAttribute : DataTypeAttribute
    {
        public OddNumberAttribute()
            : base("OddNumber")
        {

        }
        public override bool IsValid(object value)
        {
            //if ((Convert.ToInt32(value) % 2) == 0)
            //{
            //    return base.IsValid(value);
            //}
            //return false;

            if (value == null)
            {
                return true;
            }

            int num = 0;

            if (Int32.TryParse(value.ToString(),out num))
            {
                if (num % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;       
        }
    }
}