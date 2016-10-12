using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class DateRangeNaissance : ValidationAttribute
    {

        public int AgeMax { get; set; }
        public int AgeMini { get; set; }

        public DateRangeNaissance()
        {
            AgeMax = 99;
            AgeMini = 12;
        }

        public override bool IsValid(Object value)
        {
            DateTime date = Convert.ToDateTime(value);

            if ((date >= DateTime.Now.AddYears(-AgeMax)) && (date <= DateTime.Now.AddYears(-AgeMini)))
            {
                return true;
            }

            return false;
        }
    }

}