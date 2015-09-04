﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class ReverseComparer : IComparer<char>
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed. 
        public int Compare(char x, char y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    
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
                Console.WriteLine("Get lexicographically greater words:");
                foreach (var s in EnglishWords)
                {
                   // string ls = GetLexicoGreaterWordFor(s);
                    string ls = FastGetLexicographicallyGreaterWord(s.ToCharArray());
                    Console.WriteLine(ls);
                    //LexicographicallyWords.Add(ls);
                }

                Console.WriteLine("Get previous lexicographically greater words:");
                foreach (var s in EnglishWords)
                {                    
                    string ls = FastGetPreviousLexicographicallyGreaterWord(s.ToCharArray());
                    Console.WriteLine(ls);
                }
                //foreach (var s in LexicographicallyWords)
                //{
                //    Console.WriteLine(s);                    
                //}
            }
        }

        /// <summary>
        /// Another fast way to permutation string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string FastGetLexicographicallyGreaterWord(char[] s)
        {
            if (s.Length == 1)
            {
                return "no answer";
            }

            int i = s.Length-1;

            //loop through string, find the first s[i-1], which is smaller than s[i]
            while (i>0 && s[i-1] >=s[i])
            {
                i--;
            }

            if (i == 0)
                return "no answer";

            int j = s.Length - 1;
            while (j>0 && s[j]<=s[i-1])
            {
                j--;
            }

            char tmp = s[i - 1];
            s[i-1] = s[j];
            s[j] = tmp;

            //reverse the string, 按降序排列
            int k = s.Length - 1;
            while (i<k)
            {
                tmp = s[i];
                s[i] = s[k];
                s[k] = tmp;
                i++;
                k--;
            }

            return string.Join("",s);
        }

        //Design the algorithm for stepping backward to the previous lexicographical permutation.
        private string FastGetPreviousLexicographicallyGreaterWord(char[] s)
        {
            if (s.Length == 1)
            {
                return "no answer";
            }

            int i = s.Length - 1;

            //loop through string, find the first s[i-1], which is greater than s[i]
            while (i > 0 && s[i-1] <= s[i])
            {
                i--;
            }

            if (i == 0)
                return "no answer";

            int j = s.Length - 1;
            while (j > 0 && s[j] >= s[i - 1])
            {
                j--;
            }

            char tmp = s[i - 1];
            s[i - 1] = s[j];
            s[j] = tmp;

            //int k = s.Length - 1;
            //while (i < k)
            //{
            //    tmp = s[i];
            //    s[i] = s[k];
            //    s[k] = tmp;
            //    i++;
            //    k--;
            //}

            return string.Join("", s);
        }

        /// <summary>
        /// Using Array.Sort method to sort the string. This method is a bit slower.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetLexicoGreaterWordFor(string s)
        {
            IComparer<char> comparer = new ReverseComparer();

            if (s.Length == 1)
            {
                return "no answer";
            }
            for (int i = s.Length-2; i>=0; i--)
            {
                string lastSubstr = s.Substring(i);
                string sortString = s.Substring(i);

                char[] sort1 = sortString.ToCharArray();
                Array.Sort(sort1, comparer);

                if(lastSubstr == new string(sort1))
                { }
                //if (lastSubstr == string.Concat(lastSubstr.OrderByDescending(c => c)))
                //{

                //}
                else
                {
                    //get smallest char which is greater than first char.
                    //e.g.
                    //cdb, d is the maxChar, greater than the first char in substring "db"
                    char[] sort2 = sortString.ToCharArray();
                    Array.Sort(sort2);
                    sortString = new string(sort2);
                    //  char maxChar = lastSubstr.OrderBy(x=>x).FirstOrDefault(x => x>lastSubstr[0]);
                    char maxChar = sortString.FirstOrDefault(x => x > lastSubstr[0]);

                    string remainStr = lastSubstr.Remove(lastSubstr.IndexOf(maxChar), 1);
                    sort2 = remainStr.ToCharArray();
                    Array.Sort(sort2);
                    remainStr = new string(sort2);
                    string otherSub = remainStr;
                    //  string.Concat(lastSubstr.Remove(lastSubstr.IndexOf(maxChar), 1).OrderBy(x => x));


                    //return string.Format("{0}{1}", maxChar, otherSub);
                    if (i - 1 >= 0)
                        return string.Format("{0}{1}{2}", s.Substring(0, i), maxChar, otherSub);
                    return string.Format("{0}{1}", maxChar, otherSub);
                }
            }

            return "no answer";
        }
    }
}
