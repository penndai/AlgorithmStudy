using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LexicographicallyGreaterWord
    {
        public int TestCaseNumber { get; set; }

        public List<string> EnglishWords { get; set; }

        public List<string> LexicographicallyWords { get; set; }

        public void GetLexicographicallyGreaterWord()
        {
            if (TestCaseNumber != EnglishWords.Count)
            {
                Console.WriteLine("Test case number should be equals to input string number.");
            }
            else
            {
                foreach (var s in EnglishWords)
                {
                    string ls = GetLexicoGreaterWordFor(s);
                    LexicographicallyWords.Add(ls);
                }

                foreach (var s in LexicographicallyWords)
                {
                    Console.WriteLine(s);                    
                }
            }
        }

        private string GetLexicoGreaterWordFor(string s)
        {
            if (s.Length == 1)
            {
                return "no answer";
            }
            else
            {
                for (int i = s.Length-2; i>=0; i--)
                {
                    string lastSubstr = s.Substring(i);

                    if (lastSubstr == string.Concat(s.OrderByDescending(c => c)))
                    {

                    }
                    else
                    {
                        //get smallest char which is greater than first char.
                        //e.g.
                        //cdb, d is the maxChar, greater than the first char in substring "db"
                        char maxChar = lastSubstr.OrderBy(x=>x).FirstOrDefault(x => x>lastSubstr[0]);

                       string otherSub = 
                           string.Concat(lastSubstr.Remove(lastSubstr.IndexOf(maxChar), 1).OrderBy(x => x));

                        if(i-1>=0)
                        return string.Format("{0}{1}{2}",s.Substring(0, i-1), maxChar, otherSub);
                        else
                        {
                            return string.Format("{0}{1}", maxChar, otherSub);
                        }
                    }
                }

                return "no answer";
            }
        }
    }
}
