using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciarEquipe.Services
{
    public static partial class StringMethod
    {
        public static string FirstToUpper(this string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1);
        }

        public static string ToSearchString(this object o)
        {
            return "%" + o.ToSearchStringEquals() + "%";
        }

        public static string ToSearchStringEquals(this object o)
        {
            if (o == null)
                return "";

            string str = o.ToString();

            str = Regex.Replace(str, "[aáàâãª]", "[aáàâãª]");
            str = Regex.Replace(str, "[AÁÀÂÃ]", "[AÁÀÂÃ]");
            str = Regex.Replace(str, "[eéèê]", "[eéèê]");
            str = Regex.Replace(str, "[EÉÈÊ]", "[EÉÈÊ]");
            str = Regex.Replace(str, "[iíìî]", "[iíìî]");
            str = Regex.Replace(str, "[IÍÌÎ]", "[IÍÌÎ]");
            str = Regex.Replace(str, "[oóòôõº]", "[oóòôõº]");
            str = Regex.Replace(str, "[OÓÒÔÕ]", "[OÓÒÔÕ]");
            str = Regex.Replace(str, "[uúùû]", "[uúùû]");
            str = Regex.Replace(str, "[UÚÙÛ]", "[UÚÙÛ]");
            str = Regex.Replace(str, "[cç]", "[cç]");
            str = Regex.Replace(str, "[CÇ]", "[CÇ]");
            str = str.Replace("'", "''");
            str = str.Replace("%", "[%]");

            return str;
        }

        public static string ToStringWithoutAccents(this Object o)
        {
            if (o == null)
                return "";

            string str = o.ToString();

            str = Regex.Replace(str, "[aáàâãª]", "a");
            str = Regex.Replace(str, "[AÁÀÂÃ]", "A");
            str = Regex.Replace(str, "[eéèê]", "e");
            str = Regex.Replace(str, "[EÉÈÊ]", "E");
            str = Regex.Replace(str, "[iíìî]", "i");
            str = Regex.Replace(str, "[IÍÌÎ]", "I");
            str = Regex.Replace(str, "[oóòôõº]", "o");
            str = Regex.Replace(str, "[OÓÒÔÕ]", "O");
            str = Regex.Replace(str, "[uúùû]", "u");
            str = Regex.Replace(str, "[UÚÙÛ]", "U");
            str = Regex.Replace(str, "[cç]", "c");
            str = Regex.Replace(str, "[CÇ]", "C");

            return str;
        }

        public static string URLEncode(this String str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string URLDecode(this String str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        public static string QuebraLinha(this Object o)
        {
            string str = "";
            try
            {
                str = Convert.ToString(o);
                str = str.Replace("\n", "<br/>");
            }
            catch { }

            return str;
        }

        public static string ReplaceFirstOccurrence(this string str, string oldValue, string newValue)
        {
            int index = str.IndexOf(oldValue);
            string result = str.Remove(index, oldValue.Length).Insert(index, newValue);
            return result;
        }
    }
}
