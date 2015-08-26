using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Pleas input: ");
            //int TestCaseNumber = int.Parse(Console.ReadLine());

            //if (TestCaseNumber > 0 && TestCaseNumber <= 10)
            //{
            //	for (int idx = 0; idx <= TestCaseNumber; idx++)
            //	{
            //		OutPutResult();
            //	}
            //}
            //else
            //{
            //	Console.WriteLine("1<=T<=10");
            //}	
            #region Time to Word
            GetTimeInWord gtTimeInWord = new GetTimeInWord();
            int hour = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}",gtTimeInWord.PrintTimeInWord(hour, mins));
            Console.WriteLine("Print time words end");
            Console.ReadLine();
            #endregion
            #region fast Square Integer
            QuickSquareIntegerSolver qsiSolver = new QuickSquareIntegerSolver();
            int T = int.Parse(Console.ReadLine());

            var tests = new List<Tuple<int, int>>();
            for (int i = 0; i < T; i++)
            {
                var line = Console.ReadLine().Split(' ');
                tests.Add(new Tuple<int, int>(int.Parse(line[0].Trim()), int.Parse(line[1].Trim())));
            }

            foreach (var test in tests)
            {
                Console.WriteLine(qsiSolver.NumberOfSquares(test.Item1, test.Item2));
            }

            Console.WriteLine("Quick find square integer end.");
            Console.ReadLine();
            #endregion
            #region test for Square Integer
            SquareIntegerSolver siSolver = new SquareIntegerSolver();
            int loops = Convert.ToInt16(Console.ReadLine());
            List<string> numbers = new List<string>(loops);
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < loops; i++)
            {
                string value = Console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    numbers.Add(value);
                }
            }

            foreach (string t in numbers)
            {
                List<int> eachCount = new List<int>();

                int min = int.Parse(t.Split(' ')[0]);
                int max = int.Parse(t.Split(' ')[1]);

                for (int idx = max; idx >= min; idx--)
                {
                    bool flag = siSolver.HavMaxSquareInt(idx);

                    if (flag)
                    {
                        if (Math.Pow(siSolver.MaxSquareInt, 2) >= min)
                        {
                            if(!eachCount.Contains(siSolver.MaxSquareInt))
                                eachCount.Add(siSolver.MaxSquareInt);

                           // Console.WriteLine("Number {0} max sqr Int: {1}", idx, siSolver.MaxSquareInt);
                        }
                    }
                }

                //if(eachCount.Count>0)
                    result.Add(eachCount);
            }

            foreach (var data in result)
            {
                foreach (var VARIABLE in data)
                {
                    Console.WriteLine("{0}", VARIABLE);
                }
                Console.WriteLine("{0}", data.Count);
            }

            #endregion
            DateTime startTime = DateTime.Now;
            long number = 0;
            number = CalculateWays(4);

            Console.WriteLine(string.Format("1. End Time {0} -- {1}", (DateTime.Now - startTime).TotalSeconds, number));

            number = 0;

            startTime = DateTime.Now;
            number = FibonacciSeries(0);

            Console.WriteLine(string.Format("2. End Time {0} -- {1}", (DateTime.Now - startTime).TotalSeconds, number));

            number = 0;
            number = FibonacciNumber(0);
            Console.WriteLine(string.Format("3. End Time {0} -- {1}", (DateTime.Now - startTime).TotalSeconds, number));
            //bool flag = AreStringsAnagrams("aba", "baba");
            //Console.WriteLine(flag);

            PrintPascalTriangle();
            PrintPascalTriangle2(10);

            // test for list all permutations
            Console.Write("Input String>");
            string inputLine = Console.ReadLine();

            List<string> printString = new List<string>();
            printString = GetPermutations(inputLine.ToArray());

            Console.WriteLine(string.Format("orchestra words are {0}", printString.Count));

            Console.WriteLine(string.Format("{0}", printString.FirstOrDefault(x => x == "orchestra")));
            //Recursion rec = new Recursion();
            //rec.InputSet = rec.MakeCharArray(inputLine);
            //rec.CalcPermutation(0);

            //Console.Write("# of Permutations: " + rec.PermutationCount);

            //int loops = Convert.ToInt16(Console.ReadLine());
            //int[] numbers = new int[loops];

            //for (int i = 0; i < loops; i++)
            //{
            //     numbers[i] = Convert.ToInt16(Console.ReadLine());

            //}

            //for (int j = 0; j < numbers.Length; j++)
            //{
            //    PrintLagestDecentNumber(numbers[j]);
            //}

            LargestDecentNumber ldn = new LargestDecentNumber();
            Console.WriteLine("Print lagest decent number of 1 : {0}", ldn.PrintLagestDecentNumber(1));
            Console.WriteLine("Print lagest decent number of 3 : {0}", ldn.PrintLagestDecentNumber(3));
            Console.WriteLine("Print lagest decent number of 6 : {0}", ldn.PrintLagestDecentNumber(6));
            Console.WriteLine("Print lagest decent number of 9 : {0}", ldn.PrintLagestDecentNumber(9));
            Console.WriteLine("Print lagest decent number of 12 : {0}", ldn.PrintLagestDecentNumber(12));
            Console.WriteLine("Print lagest decent number of 80994 : {0}", ldn.PrintLagestDecentNumber(80994));
            Console.ReadLine();
        }

        /// <summary>
        /// An anagram is a word formed from another by rearranging its letters, using all the original letters exactly once; 
        /// for example, orchestra can be rearranged into carthorse. Write a function that checks if two words are each other's anagrams.
        /// For example, AreStringsAnagrams("momdad", "dadmom") should return true as arguments are anagrams.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool AreStringsAnagrams(string a, string b)
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            a = rgx.Replace(a, string.Empty);
            b = rgx.Replace(b, string.Empty);

            List<KeyValuePair<char, int>> kvp_a = new List<KeyValuePair<char, int>>();
            List<KeyValuePair<char, int>> kvp_b = new List<KeyValuePair<char, int>>();

            var sa = a.Where(c => char.IsLetter(c)).OrderBy(c => c).ToArray();
            var sb = b.Where(x => char.IsLetter(x)).OrderBy(x => x).ToArray();

            foreach (char c in sb)
            {
                KeyValuePair<char, int> pairB = new KeyValuePair<char, int>();
                if (kvp_b.Where(x => x.Key == c).Count() == 0)
                {
                    pairB = new KeyValuePair<char, int>(c, 1);
                    kvp_b.Add(pairB);
                }
                else
                {
                    var newpairB = new KeyValuePair<char, int>(pairB.Key, pairB.Value + 1);
                    kvp_b.Remove(pairB);
                    kvp_b.Add(newpairB);
                }
            }

            foreach (char c in sa)
            {
                KeyValuePair<char, int> pairA = new KeyValuePair<char, int>();

                if (kvp_a.Where(x => x.Key == c).Count() == 0)
                {
                    pairA = new KeyValuePair<char, int>(c, 1);
                    kvp_a.Add(pairA);
                }
                else
                {
                    var newpairA = new KeyValuePair<char, int>(pairA.Key, pairA.Value + 1);
                    kvp_a.Remove(pairA);
                    kvp_a.Add(newpairA);
                }
            }

            if (kvp_a.Count != kvp_b.Count)
            {
                return false;
            }
            else
            {
                foreach (var aa in kvp_a)
                {
                    if (kvp_b.Where(x => x.Key == aa.Key && x.Value == aa.Value).Count() == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// A frog only moves forward, but it can move in steps 1 inch long or in jumps 2 inches long. A frog can cover the same distance using different combinations of steps and jumps.
        /// Write a function that calculates the number of different combinations a frog can use to cover a given distance.
        /// For example, a distance of 3 inches can be covered in three ways: step-step-step, step-jump, and jump-step.
        /// </summary>
        static int num = 0;

        public static long FibonacciNumber(int n)
        {
            int f0 = 0;
            int f1 = 1;
            int f2 = 2;

            int first = f1;
            int second = f2;

            int result = 0;

            if (n == 0)
                result = f0;

            if (n == 1)
                result = f1;

            if (n == 2)
                result = f2;

            for (int idx = 3; idx <= n; idx++)
            {
                result = first + second;

                first = second;
                second = result;
            }

            return result;
        }

        public static long FibonacciSeries(int n)
        {
            long a = 0;
            long b = 1;

            for (int i = 0; i <= n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;


        }

        public static int CalculateWays(int number)
        {
            //Console.WriteLine(string.Format("current deal with {0}", number));
            if (number == 0)
            {
                ++num;
            }
            else if (number < 0)
            {
                return num;
            }

            if (number - 1 >= 0)
                CalculateWays(number - 1);

            if (number - 2 >= 0)
                CalculateWays(number - 2);

            return num;
        }

        public static void PrintPascalTriangle2(int RowNumber)
        {
            //initialize empty print number rows and columns
            List<List<int>> printNumbers = new List<List<int>>(RowNumber);

            // loop through all rows
            for (int idx = 0; idx <= RowNumber - 1; idx++)
            {
                // initialize currentline with -1, the number -1 will be replaced with actual number
                List<int> currentLine = Enumerable.Repeat(-1, idx + 1).ToList();

                // first number of each row is 1
                currentLine[0] = 1;

                // current number position in the current line, start with 1, because the number in position 0 is 1
                int currentLinePosition = 1;

                // start from line 1
                if (idx - 1 >= 0)
                {
                    List<int> previousLine = printNumbers[idx - 1];

                    for (int j = 0; j < previousLine.Count - 1; j++)
                    {
                        currentLine[currentLinePosition] = previousLine[j] + previousLine[j + 1];
                        currentLinePosition++;
                    }
                }

                // last number of each row is 1
                currentLine[idx] = 1;
                printNumbers.Add(currentLine);
            }

            // print all line numbers
            foreach (List<int> number in printNumbers)
            {
                foreach (int a in number)
                {
                    Console.Write(string.Format("{0}  ", a));
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// By using two-dimensional array of C# language, write C# program to display a table that 
        /// represents a Pascal triangle of any size. 
        /// In Pascal triangle, the first and the second rows are set to 1. 
        /// Each element of the triangle (from the third row downward) is the sum of the element directly above it and 
        /// the element to the left of the element directly above it. See the example Pascal triangle(size=5) below:
        /// 1				
        /// 1	1			
        /// 1	2	1		
        /// 1	3	3	1	
        /// 1	4	6	4	1
        /// </summary>
        public static void PrintPascalTriangle()
        {
            System.Console.WriteLine("Pascal Triangle Program");
            System.Console.Write("Enter the number of rows: ");
            string input = System.Console.ReadLine();

            int n = Convert.ToInt32(input);
            // row number=n
            for (int y = 0; y < n; y++)
            {
                int c = 1;
                //for (int q = 0; q < n - y; q++)
                //{
                //	System.Console.Write("   ");
                //}

                //print column for each row
                for (int x = 0; x <= y; x++)
                {
                    System.Console.Write("   {0:D}  ", c);
                    //calculate the number
                    c = c * (y - x) / (x + 1);
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        /// <summary>
        /// Write a function that checks if a given sentence is a palindrome. A palindrome is a word, phrase, verse, or 
        /// sentence that reads the same backward or forward. Only the order of English alphabet letters (A-Z and a-z) should be considered, other characters should be ignored.
        /// For example, IsPalindrome("Noel sees Leon.") should return true as spaces, period, and 
        /// case should be ignored resulting with "noelseesleon" which is a palindrome since it reads same backward and forward.
        /// </summary>
        /// <param name="s"></param>
        private static bool IsPalindrome(string s)
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            s = rgx.Replace(s, "").ToUpper();
            bool result = true;

            if (!string.IsNullOrEmpty(s))
            {
                int startPnt = 0;
                int endPnt = s.Length - 1;

                while (startPnt <= endPnt)
                {
                    if (s[startPnt] == s[endPnt])
                    {
                        startPnt++;
                        endPnt--;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }
            else
            {
                return false;
            }
        }

        static private void OutPutResult()
        {
            string inputString = Console.ReadLine();
            string[] values = inputString.Split(' ');
            if (values.Length == 2)
            {
                int StudentNumber = int.Parse(values[0]);
                int RequiredNumber = int.Parse(values[1]);
                bool cancelled = true;
                int arrivedNumber = 0;
                string StudentArriveTime = Console.ReadLine();
                string[] arriveValues = StudentArriveTime.Split(' ');

                for (int i = 0; i < StudentNumber; i++)
                {
                    if (int.Parse(arriveValues[i]) <= 0)
                        arrivedNumber++;

                    if (arrivedNumber >= RequiredNumber)
                    {
                        cancelled = false;
                        break;
                    }
                }

                if (cancelled)
                {
                    Console.WriteLine("YES");
                }
                else
                    Console.WriteLine("NO");
            }
        }

        #region Run consecutive sequence string
        /// <summary>
        /// Write a function that finds the zero-based index of the longest run in a string. 
        /// A run is a consecutive sequence of the same character. 
        /// If there is more than one run with the same length, return the index of the first one. 
        /// For example, IndexOfLongestRun("abbcccddddcccbba") should return 6 as the longest run is dddd and it first appears on index 6.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int IndexOfLongestRun(string s)
        {
            int maxLongestIndex = 0;
            int maxLength = 0;
            int currentLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    currentLength = 1;
                    maxLength = 1;
                }
                else
                {
                    if (s[i] == s[i - 1])
                    {
                        currentLength++;
                        if (maxLength < currentLength)
                        {
                            maxLength = currentLength;
                            maxLongestIndex = i - maxLength + 1;
                        }
                    }
                    else
                    {
                        currentLength = 1;
                    }
                }
            }

            return maxLongestIndex;
        }
        #endregion

        #region print all permutations
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static List<string> GetPermutations(char[] list)
        {
            int x = list.Length - 1;
            List<string> printString = new List<string>();

            GetPermutations(list, 0, x, printString);

            return printString;
        }

        /// <summary>
        /// If the set just has one element -->
        //return it.
        //perm(a) -> a

        //If the set has two characters: for each element in it: return the element, with the permutation of the rest of the elements added, like so:

        //perm(ab) -> 

        //a + perm(b) -> ab 

        //b + perm(a) -> ba 

        //Further: for each character in the set: return a character, concatenated with a perumation of > the rest of the set

        //perm(abc) ->

        //a + perm(bc) --> abc, acb

        //b + perm(ac) --> bac, bca

        //c + perm(ab) --> cab, cba

        //perm(abc...z) -->

        //a + perm(...), b + perm(....) 			
        /// </summary>		
        private static void GetPermutations(char[] list, int recursionDepth, int maxDepth, List<string> printString)
        {
            if (recursionDepth == maxDepth)
            {
                if (!printString.Contains(new string(list)))
                {
                    printString.Add(new string(list));
                    Console.WriteLine(list);
                }
            }
            else
                for (int i = recursionDepth; i <= maxDepth; i++)
                {
                    Swap(ref list[recursionDepth], ref list[i]);
                    GetPermutations(list, recursionDepth + 1, maxDepth, printString);
                    Swap(ref list[recursionDepth], ref list[i]);
                }
        }
        #endregion

        #region find two number sum = given value
        /// <summary>
        /// Write a function that, given a list and a target sum, returns zero-based indices of any two distinct elements whose sum is equal to the 
        /// target sum. If there are no such elements, the function should return null.
        /// For example, FindTwoSum(new List<int>() { 1, 3, 5, 7, 9 }, 12) should return any of the following tuples of indices:
        /// 1, 4 (3 + 9 = 12)
        /// 2, 3 (5 + 7 = 12)
        /// 3, 2 (7 + 5 = 12)
        /// 4, 1 (9 + 3 = 12)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static Tuple<int, int> QuickFindTwoSum(IList<int> list, int sum)
        {
            IList<int> dealList = list.OrderBy(x => x).ToList();

            int i = 0;
            int j = dealList.Count - 1;

            while (i != j)
            {
                if (dealList[i] + dealList[j] == sum)
                {
                    return new Tuple<int, int>(list.IndexOf(dealList[i]), list.IndexOf(dealList[j]));
                }
                else if (dealList[i] + dealList[j] > sum)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return null;
        }


        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            int maxnumber = list.Max();
            int submaxnumber = list.OrderByDescending(r => r).Take(2).LastOrDefault();

            int minumnumber = list.Min();
            int subminnumber = list.OrderBy(r => r).Take(1).LastOrDefault();

            if (sum < minumnumber + subminnumber || sum > maxnumber + submaxnumber)
            {
                return null;
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] + list[j] == sum)
                    {
                        Tuple<int, int> result = Tuple.Create(i, j);
                        return result;
                    }
                }

            }

            return null;
        }
        #endregion
    }
}
