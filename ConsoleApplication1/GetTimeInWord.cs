using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GetTimeInWord
    {
        private string[] _betweenTenTweenty = {"","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
        string[] _tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty" };
        string[] _words = 
        { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven","twelve" };
        public string PrintTimeInWord(int Hour, int Minutes)
        {
            if (Hour < 1 || Hour>24 || Minutes<0 || Minutes > 60)
                return string.Empty;
            else
            {
                string hourStr = _words[Hour];
                if (Minutes == 30)
                {
                    return string.Format("half past {0}", _words[Hour]);
                }
                else if (Minutes < 30)
                {
                    string minstr = GetLess30Mins(Minutes);
                    if (!string.IsNullOrEmpty(minstr))
                    {
                        if (Minutes != 15)
                            return string.Format("{1} minutes past {0}", hourStr, minstr);
                        else
                            return string.Format("quarter past {0}", hourStr, minstr);
                    }
                    else
                    {
                        return string.Format("{0} o' clock", hourStr);
                    }
                }
                else
                {
                    string minstr = GetLess30Mins(60 - Minutes);
                    if (Minutes != 45)
                        return string.Format("{0} minutes to {1}", minstr, _words[Hour + 1]);
                    else
                        return string.Format("quarter to {1}", minstr, _words[Hour + 1]);
                } 
            }
        }

        private string GetLess30Mins(int Minutes)
        {
            int ten = Minutes/10;

            switch (ten)
            {
                case 0:
                    return _words[Minutes];
                case 1:
                    return _betweenTenTweenty[Minutes%10];
                default:
                    string tens = _tensMap[Minutes/10];
                    string min = _words[Minutes%10];
                    
                    return string.Format("{0} {1}", tens,min);                    
            }
        }
    }
}
