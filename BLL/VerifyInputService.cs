using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL
{
    public static class VerifyInputService
    {
        public static bool IsInputCorrect(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
