using System;
using System.Text.RegularExpressions;

namespace RegexProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex r = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");
            //class Regex Repesents an immutable regular expression.  

            string[] str = { "+91-9678967101", "96796101", "+91-9678-967101", "+91-96789-67101", "+919678967101" };
            //Input strings for Match valid mobile number.  
            foreach (string s in str)
            {
                Console.WriteLine("{0} {1} a valid mobile number.", s,
                r.IsMatch(s) ? "is" : "is not");
                //The IsMatch method is used to validate a string or  
                //to ensure that a string conforms to a particular pattern.  
            }
        }
    }
}
