using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Encryption
    {
        public string TestString { get; set; }

        public void PrintEncryption()
        {
            if (!string.IsNullOrEmpty(TestString))
            {
                int rownumber = (int)Math.Floor(Math.Sqrt(TestString.Length));
                int columnnumber = (int) Math.Ceiling(Math.Sqrt(TestString.Length));

                if (rownumber*columnnumber < TestString.Length)
                {
                    rownumber++;
                }

                char[,] strArray = new char[rownumber,columnnumber];

                for (int i = 0; i < rownumber; i++)
                {
                    string rowString = string.Empty;
                    if (i == 0)
                    {
                        rowString = TestString.Substring(i, columnnumber);
                    }
                    else
                    {
                        if (TestString.Substring(i*columnnumber).Length >= columnnumber)
                        {
                            rowString =
                                TestString.Substring((i*columnnumber), columnnumber);
                        }
                        else
                        {
                            rowString = TestString.Substring(i*columnnumber);
                        }
                    }

                    Console.WriteLine(rowString);
                    int columnIdx = 0;
                    foreach (char c in rowString)
                    {
                        strArray[i,columnIdx] = c;
                        columnIdx++;
                    }                    
                }

                for (int i = 0; i < columnnumber; i++)
                {
                    for (int j = 0; j < rownumber; j++)
                    {
                        if(strArray[j,i]!='\0')
                            Console.Write(strArray[j,i]);
                    }

                    if(i<columnnumber-1)
                        Console.Write(' ');
                }

                //Console.WriteLine("Print Encryption end.");
               // Console.ReadLine();
            }            
        }
    }
}
