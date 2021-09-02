using System;
using System.Globalization;

namespace RemoveSpecificCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "\t\n\rzahid";
            //var charsToRemove = new string[] { "\t", "\n", "\r"};
            //foreach (var c in charsToRemove)
            //{
            //    str = str.Replace(c, string.Empty);
            //}

            string num = "12";

            var dbl = string.Equals("--",num) ? 0.0:double.Parse(num, CultureInfo.InvariantCulture);
            Console.WriteLine(dbl);
        }
    }
}
