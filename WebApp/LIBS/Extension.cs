using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApp.LIBS
{
    public static class Extension
    {

        public static DateTime DateConvertTextMatchCaseyyyymmddd(this string str)
        {
            if (str.ToLower().Contains('-'))
            {
                return DateTime.ParseExact(str, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            else if (str.ToLower().Contains('.'))
            {
                return DateTime.ParseExact(str, "yyyy.MM.dd", CultureInfo.InvariantCulture);
            }

            else
            {
                return DateTime.ParseExact(str, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
        }


        public static string TrimEndZero(this object d)
        {
            try
            {
                string str = d.ToString();
                if (str.IndexOf(".") > 0)
                {
                    str = System.Text.RegularExpressions.Regex.Replace(str.Trim(), "0+?$", " ");
                    str = System.Text.RegularExpressions.Regex.Replace(str.Trim(), "[.]$", " ");
                }
                return str;
            }
            catch { return ""; }
        }
        public static string ShagunDateTime(this DateTime date)
        {
            return String.Format("{0:dd MMM yyyy}", date);
        }

        public static bool ConvertBoolZeroOne(this string value)
        {
            try
            {
                if (Convert.ToInt32(value) == 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }

            catch { return false; }

        }
        public static string BlankDateConvertWithTime(this DateTime date)
        {
            
            if (date.ToString("dd-MM-yyyy") == "01-01-0001" || date == null)
            {
                return "";
            }
            else
                return date.ToString("dd-MM-yyyy") + " " + date.Date.ToShortTimeString();
       }
        public static string BlankDateConvert(this DateTime date)
        {
             if (date.ToString("dd-MM-yyyy") == "01-01-0001")
            
                return "";
            else
                return date.ToString("dd-MM-yyyy");
        }

        public static int ValidDate(this DateTime date)
        {
            if (date.ToString("dd-MM-yyyy") == "01-01-0001")

                return 1;
            else
                return 0;
        }

        public static string ToAge(this DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;
            return age.ToString();
        }
        public static DateTime DateConvert(this string str)
        {
            return DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime DateConvertFormat(this string str,string Format)
        {
            return DateTime.ParseExact(str, Format, CultureInfo.InvariantCulture);
        }
        public static DateTime DateConvertText(this string str)
        {
            return DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime DateConvertTextMatchCase(this string str)
        {
            if (str.ToLower().Contains('-'))
            {
                return DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }else if (str.ToLower().Contains('.'))
                {
                    return DateTime.ParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                }

                else
            {
                return DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        public static string  DateConvertTextMatchCaseStringSQL(this string str)
        {
            try
            {
                if (str.ToLower().Contains('-'))
                {
                    return DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
                }
                else if (str.ToLower().Contains('.'))
                {
                    return DateTime.ParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
                }

                else
                {
                    return DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy");
                }
            }
            catch {
                return "";
            }
        }





        public static int ConvertInt(this string value)
        {
            try
            {
              return  Convert.ToInt32(value);
                
            }

            catch { return 0; }
           
        }

        public static double Convertdouble(this string value)
        {
            try
            {
                return Convert.ToDouble(value);

            }

            catch { return 0; }

        }

        public static byte Convertbyte(this string value)
        {
            try
            {
              return  Convert.ToByte(value);
              
            }

            catch { return 0; }

        }

        public static short ConvertInt16(this string value)
        {
            try
            {
                return Convert.ToInt16(value);
                
            }

            catch { return 0; }

        }
        public static string Convertstring(this string value)
        {
            string retunvalu;
            try
            {
                retunvalu = value.ToString();
            }

            catch { retunvalu = ""; }
            return retunvalu;
        }
        public static decimal ConvertDecimal(this string value)
        {
            try
            {
              return  Convert.ToDecimal(value.ToString().ToUpper().Replace("CR","").Replace("DR", ""));
            }

            catch { return 0; }
            
        }
        public static bool ConvertBool(this string value)
        {
            try
            {
            return    Convert.ToBoolean(value);
               
            }

            catch { return false; }

        }
    }


}