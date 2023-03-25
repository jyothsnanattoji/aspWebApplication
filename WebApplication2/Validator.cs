using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public abstract class Validator
    {
        public bool CheckMarks(int Marks)
        {
            if (Marks < 200 || Marks > 500) return false;
            return true;
        }
        public bool CheckDob (String dateString)
        {
            String year = dateString.Substring(Math.Max(0, dateString.Length - 4));
            DateTime dateTime;
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)&& ((Convert.ToInt32(year))-dateTime.Year)>=17)
            {
                return true;
            }
            return false;
        }
        public bool CheckPhone(string Mobile)
        {
            if (Mobile.Length != 10 ) return false;
            return true;
        }
    }
}