using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LargestDecentNumber
    {
        public int Number1
        {
            get
            {
                return 5;
            }
        }

        public int Number2
        {
            get { return 3; }
        }

        public string PrintLagestDecentNumber(int Length)
        {
            bool find = false;
            StringBuilder number1Array = new StringBuilder();
            StringBuilder number2Array = new StringBuilder();
            for (int i = Length; i >= 0; i--)
            {
                // i --- max number 5 count
                // length - i ---- min number 3 count
                if (i%Number2 == 0 && (Length - i)%Number1 == 0)
                {
                    find = true;

                    if (i > 0)
                    {
                        for (int idx = 0; idx < i; idx++)
                        {
                            number1Array.Append(Number1);
                        }
                        // Repeat is a much slower method to initial array
                        //number1Array =
                        //    Enumerable.Repeat(Number1.ToString(), i).Aggregate((previous, next) => previous + next);
                    }
                    if (Length - i > 0)
                    {
                        for (int idx2 = 0; idx2 < Length-i; idx2++)
                        {
                            number2Array.Append(Number2);
                        }
                    }
                        //number2Array = Enumerable.Repeat(Number2.ToString(), Length - i).Aggregate((previous, next) => previous + next);

                    break;
                }
                
            }

            if (find)
            {
                return string.Format("{0}{1}", number1Array.ToString(), number2Array.ToString());
            }
            
            return "-1";            
        }

    }
}
