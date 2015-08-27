using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class KaprekarNumber
    {
        public List<int> Data { get; private set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void PrintKaprekarNumber()
        {
            if (Min > 0 && Max > 0 && Min<=Max)
            {
                Data = new List<int>();
                for (int idx = Min; idx <= Max;idx++)
                {
                    Int64 squar = (Int64)Math.Pow(idx, 2);
                    string squarString = squar.ToString();

                    //for one digital,prefix with "0"
                    if (squar<= 9)
                        squarString = string.Format("0{0}", squarString);

                    int midIdx = squarString.Length/2;
                    string leftSubstring = squarString.Substring(0, midIdx);
                    string rightSubstring = squarString.Substring(midIdx);

                    Int64 leftSubInt = Int64.Parse(leftSubstring);
                    Int64 rightSubInt = Int64.Parse(rightSubstring);

                    if (leftSubInt + rightSubInt == idx)
                    {
                        Data.Add(idx);
                    }
                }
            }            
        }
    }
}
