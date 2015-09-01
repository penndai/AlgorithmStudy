using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CaesarCipher
    {
        public int StringLength { get; set; }
        public string RawString { get; set; }
        public char[] EncryptString { get; set; }
        public int RotatedNumber { get; set; }
        
        public void Encryption()
        {            
            EncryptString=new char[StringLength];
            int i = 0;
            foreach (var c in RawString)
            {                
                if (char.IsLetter(c))
                {
                    // get the letter location in 26 letters
                    int cIdx = char.ToLower(c) - 'a';
                    int idx = (RotatedNumber + cIdx)%26;
                    if (char.IsLower(c))
                    {
                        EncryptString[i] = (char)('a' + idx);
                    }
                    else if (char.IsUpper(c))
                    {
                        EncryptString[i] = (char) ('A' + idx);
                    }
                }
                else
                {
                    EncryptString[i] = c;
                }

                i++;
            }

            Console.WriteLine(EncryptString);
        }
    }
}
