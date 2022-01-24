using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dziekanat.Controller
{
    internal class InputVerifier
    {

       

        private string patternName = "^[A-Z]+$";
        private string patternNameTwo = "^[A-Za-z]+$";

        private string patternPESEL = "^[0-9]+$";

        private string patternSemester = "^[0-9]+$";

      //  private string patternLong = @"\b\d+\,\d{3}\b";
       private string patternLong = @"\bthe\w*\b";


        public bool IsString(string text)
        {
            return Regex.IsMatch(text, this.patternNameTwo);
        }

        public bool IsPESEL(string text)
        {
            return Regex.IsMatch(text, this.patternPESEL);
        }

        public bool IsSemester (string text)
        {
            return Regex.IsMatch(text, this.patternSemester);
        }

        internal bool IsLongString(string text)
        {
            return Regex.IsMatch(text, this.patternName);
        }
    }
}


//"^[0-9]{0,2}$"