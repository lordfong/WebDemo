using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.CustumExtensions
{
    public static class ExtensionMethods
    {
        public static string UppercaseFirstLetter(this string value)
        {
            //
            // Uppercase the first letter in the string this extension is called on.
            //
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }
    }
}