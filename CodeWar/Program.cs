using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using NAudio.Wave;

//Human Readable Time
//Valid Braces
//Roman Numerals Decoder
//Adding Big Numbers
namespace CodeWar
{
    public class Program
    {
        public static void Main(string[] args)
            {
            var listone = DeleteNth( new []{1, 1, 3, 3, 7, 2, 2, 2, 2}, 3 );
            var listtwo =  DeleteNth( new []{20, 37, 20, 21}, 1);
            var listthree = DeleteNth(new [] { 3, 3, 2, 1, 1, 3, 1, 2, 3, 2}, 2);//expectd : 3,3,2,1,1,2 Actual: 3,3,2,1,1,3,2
                                                                                 //            Console.WriteLine(GetSum( 0,1 ));
                                                                                 //            Console.WriteLine(GetSum( 0,-1 ));
                                                                                 //Console.WriteLine(rowSumOddNumbers(42));
                                                                                 //GetUserIds( "" );
                                                                                 //            Console.WriteLine("before");
                                                                                 //            Console.WriteLine(new StringBuilder().AppendLine(string.Empty).ToString());
                                                                                 //            Console.WriteLine("after");
            int[] items = null;
            List<int> lst = new List<int>();
            //{ 10, 100, 1000 }
            // Display elements with ForEach.
            //            Array.ForEach(items, element => Console.WriteLine(
            //                "Element is " + element));
            lst.ForEach( Console.WriteLine );
            //Expected: 3,1,3,1,2,2 Actual: 3,1,3,1,2,3,2
            //            Console.WriteLine(HighAndLow( "1 2 3 4 5" ));
            //            Console.WriteLine(Pattern( 5 ));

            //            foreach (var i in listone)
            //                {
            //                Console.Write( i );
            //                Console.Write( "," );
            //                }
            //            Console.WriteLine();
            //            foreach (var i in listtwo)
            //            {
            //                Console.Write(i);
            //                Console.Write(",");
            //            }
            //            Console.WriteLine();
            //            foreach (var i in listthree)
            //            {
            //                Console.Write(i);
            //                Console.Write(",");
            //            }
            //            Console.WriteLine(PigIt("Pig latin is cool"));
            //            Console.WriteLine(PigIt("This is my string"));
            //Console.WriteLine(orderWeight("56 65 74 100 99 68 86 180 90"));
            //            Console.WriteLine(SquareDigits(9119  ));
            //            Console.WriteLine(Reverse( "world" ));
//            High("sadsd");
//            while ( true )
//                {
//                Console.Write("Enter the folder path or enter 'e' to exit : ");
//                var line = Console.ReadLine();
//                if(string.Equals( line,"e",StringComparison.CurrentCultureIgnoreCase ))
//                    break;
//                var files = Directory.GetFiles(line, "*.mp3");
//                var resultFile = $@"{line}/combined.mp3";
//                using (var fileStream = new FileStream(resultFile, FileMode.Create))
//                    {
//                    Combine(files, fileStream);
//                    }
//                Console.WriteLine("Done.");
//            }
            }

        /*
         * Move the first letter of each word to the end of it, then add 'ay' to the end of the word.

Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
         */
        public static string ToCamelCase(string str)
            {
            if (str.Length == 0) return "";
            var arr = str.Split( '-', '_' );
            
            var resultBuilder = new StringBuilder();
            foreach (var s in arr)
                {
                resultBuilder.Append( s[0].ToString().ToUpper() );
                resultBuilder.Append( s.Substring( 1 ).ToLower() );
                }
            if(resultBuilder.Length > 0)
                resultBuilder[0] = arr[0][0];
            return resultBuilder.ToString();
            }
        public static string PigIt( string str )
            {
            var splittedArr = str.Split( ' ' );
            var resultBuilder = new StringBuilder();
            foreach (var s in splittedArr)
                {
                resultBuilder.Append( s.Substring(1) + s.First() + "ay" );
                resultBuilder.Append( " " );
                }
            return resultBuilder.ToString().TrimEnd();
            }
        public static int[] DeleteNth(int[] arr, int x )
            {
            var newList = arr.ToList();

            var group = arr.ToList().GroupBy( v => v );
            
            foreach (var g in group.Where( g => g.Count() > x ))
                {
                newList.RemoveAt(newList.LastIndexOf( g.Key ) );
                DeleteNth( newList.ToArray(), x );
                }
            return newList.ToArray();
            }

        public static string HighAndLow(string numbers)
            {
            return string.Join( " ", numbers.Split( ' ' ).Select( x => Convert.ToInt32( x ) ).Max(),
                numbers.Split( ' ' ).Select( x => Convert.ToInt32( x ) ).Min() );
            }
        public static int[] minMax(int[] lst)
            {
            return new[] {lst.Min(), lst.Max()};
            }
        public static string Pattern( int n )
            {
            if (n < 1) return "";
            var resultStrBuilder = new StringBuilder();
            for (var i = 1; i < n; i++)
                {
                //                for (var j = i; j <= i; j++)
                //                    {
                //                    resultStrBuilder.Append( j );
                //                    }
                var j = i;
                while (j <= 1)
                    {
                    resultStrBuilder.Append( j );
                    j--;
                    }
                resultStrBuilder.AppendLine();
                }
            return resultStrBuilder.ToString();
            }


        public static int GetSum(int a, int b)
        {
            //Good Luck!
            if (a == b) return a;
            var start = a > b ? b : a;
            var end = a > b ? a : b;
            var sum = 0;
            for (var i = start; i <= end; i++)
                {
                sum += i;
                }
            return sum;
        }

        public static int FindSmallestInt( int[] args )
            {
            return args.Min();
            }
        public static long rowSumOddNumbers( long n )
            {
            var sum = 0;
            var oddTriangle = new Dictionary<long,long>();
            for (var i = 1; i < 100; i++)
                {
                oddTriangle[i] = GetOddSum( i );
                }

            return oddTriangle[n];
            }

        public static long GetOddSum( int upper )
            {
            var sum = 0;
            for (var i = 1; i <= upper; i++)
                {
                if (i%2 == 1)
                    sum += i;
                }
            return sum;
            }

        public static int NumberOfOccurrences(int x, int[] xs)
            {
            return xs.ToList().Count( t => t == x );
            }


        public static string orderWeight(string strng)
            {
            if (string.IsNullOrEmpty( strng )) return "";
            var splittedArr = strng.Split( ' ' );
            var sum = 0;
            var orderArr = new List<int>();
            //var orderArray = splittedArr.OrderBy( x => x.Sum( c => c ) ).ToArray();
            foreach (var aa in splittedArr)
                {
                sum += aa.Sum( c => Convert.ToInt32(c.ToString()) );
                orderArr.Add( sum );

                sum = 0;
                }
            var resultBuilder = new StringBuilder();
//            foreach (var a in orderArray)
//                {
//                resultBuilder.Append( a );
//                resultBuilder.Append( " " );
//                }
            return resultBuilder.ToString().TrimEnd();
            }


        public static string Tickets(int[] peopleInLine)
        {
            //Your code is here...
            var result = "YES";
            if (peopleInLine[0] > 25)
                result = "NO";

            var count25 = 0;
            var count50 = 0;

            foreach (var person in peopleInLine)
                {
                if (person == 25)
                    count25++;

                if (person == 50)
                    {
                    if (count25 == 0)
                        result = "NO";
                    else
                        {
                        count25--;
                        count50++;
                        }
                    }

                if (person == 100)
                    {
                    if (count25 < 3 || (count25 < 1 && count50 < 1))
                        result = "NO";
                    else
                        {
                        if (count50 >= 1 && count25 >= 1)
                            {
                            count50--;
                            count25--;
                            }
                        else if (count25 >= 3)
                            {
                            count25 = count25 - 3;
                            }
                        }
                    }
                }


            return result;
        }

        public static string Biggest(int[] nums)
        {
            //code me
            var max = nums[0];
            var list = nums.ToList();
            var builder = new StringBuilder();
//            foreach (var i in nums)
//                {
//                if (i > max)
//                    {
//                    max = i;
//                    builder.Insert( 0, max );
//                    }
//
//                }
            foreach (var i in list)
                {
                if (i > max)
                    {
                    max = i;
                    builder.Insert( 0, max );
                    list.Remove( max );
                    }
                else
                    {
                    builder.Append( max );
                    }
            }
                
            return builder.ToString();

        }

        public static int Find(int[] integers)
            {
            var returnInt = -1;
            var even = integers.Count( x => x%2 == 0 );
            var odd = integers.Count( x => x%2 == 1 );
            if (even == 1)
                returnInt = integers.First( x => x%2 == 0 );
            if (odd == 1)
                returnInt = integers.First( x => x%2 == 1 );
            return returnInt;
        }
        /*
         * true
         *  ({})
            [[]()]
            [{()}]
           false
            {(})
            ([]
            [])
         */
        public static bool Check(string input)
            {
            if (string.IsNullOrEmpty( input ))
                return true;
            if (input.Length%2 == 1)
                return false;

            var partOne = input.Substring( 0, input.Length/2 );
            var partTwo = input.Substring( input.Length/2, input.Length/2 );
            var leftSideStack = new Stack<string>();
            var rightSideStack = new Stack<string>();
            foreach (var c in partOne)
                {
                leftSideStack.Push( c.ToString() );
                }
            foreach (var c in partTwo)
                {
                rightSideStack.Push( c.ToString() );
                }
            var matchCount = 0;
            for (var i = 0; i < leftSideStack.Count; i++)
                {
                var left = leftSideStack.Pop();
                var right = rightSideStack.Pop();
                //if()
                }

            return false;
        }

        public static int Sum( int[] numbers )
            {
            if (numbers == null)
                return 0;
            if (numbers.Length == 0 || numbers.Length == 1)
                return 0;
            var numbersAsList = numbers.ToList();
            var excludedValues = new[] {numbers.Min(), numbers.Max()};
            foreach (var num in excludedValues)
                {
                numbersAsList.Remove( num );
                }
            return numbersAsList.Sum();
            }
    public static int SquareDigits(int n)
        {
        var result = "";
        foreach (var c in n.ToString())
            {
            result += Convert.ToInt32( c.ToString()  ) * Convert.ToInt32(c.ToString());
                //Math.Pow(value, power)
            }

        return Convert.ToInt32( result );
        }
    public static string High(string s)
        {
        var words = s.Split(' ');
        var word = "";
        var score = 0;
            var index = 0;
            var alpha = CreateAlphabet();
        for ( var i = 0; i < words.Length; i++ )
            {
                if (GetWordScore(alpha,words[i]) > score)
                {
                    score = GetWordScore(alpha,words[i]);
                    word = words[i];
                    index = i;
                }
                else if (GetWordScore(alpha,words[i]) == score)
                {
                    word = words[index];
                }
            }
            return word;
        }
        public static List<string> CreateAlphabet()
            {
            var alphabet = new List<string> { "zero" };
            for (var c = 'A'; c <= 'Z'; c++)
                {
                alphabet.Add("" + c);
                }
            for (var i = 0; i < alphabet.Count; i++)
                {
                alphabet[i] = alphabet[i].ToLower();
                }
            return alphabet;
        }
        public static int GetWordScore(List<string> alphabet,string word)
            {
            return word.Sum( c => alphabet.IndexOf( c.ToString() ) );
            }

        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if(!numbers.Any()) return new List<int>();
            var min = numbers.Min();
        if (numbers.Count(x => x == min) > 1)
            {
            numbers.RemoveAt( numbers.IndexOf( min ) );
            }
        else
            {
                numbers.Remove(min);
            }
            return numbers;
//                for ( var i = 0; i < numbers.Count; i++ )
//            {
//                if (numbers[i] < min)
//                    {
//                    min = numbers[i];
//                    index = i;
//                    }
//            }
//            if(numbers.Count(x => x == min) > 1)
//                {
//                var found1 = 
//                numbers.Remove(  )
//                }

        // Good Luck!
        }
        public static string Reverse(string str)
            {
            var reversed = "";
            for ( var i = str.Length-1; i >= 0; i-- )
                {
                reversed += str[i];
                }
            return reversed;
            }
        public static string[] GetUserIds(string s)
        {
            var separator = new [] {", "};
            var splittedIds = s.Split(separator,StringSplitOptions.None );
            var returnedIds = new string[splittedIds.Length];
            for (var i = 0; i < splittedIds.Length; i++)
                {
                splittedIds[i] = splittedIds[i].Trim( ' ' );
                splittedIds[i] = splittedIds[i].Replace( "#", "" );
                splittedIds[i] = splittedIds[i].ToLower();
                if (splittedIds[i].IndexOf("uid", StringComparison.CurrentCultureIgnoreCase) == 0)
                    splittedIds[i] = splittedIds[i].Replace( "uid", "" );
                returnedIds[i] = splittedIds[i];
                }
            
            return returnedIds;
        }
    public static int TrailingZeros(int n)
        {
        //Solution
        var result = Factorial(n).ToString();
        var zeros = 0;
        var i = result.Length - 1;
        while (result[i] == '0')
            {
            zeros++;
            i--;
            }
        return zeros;
        }

    public static BigInteger Factorial(int n)
        {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
        }
        public static string SumStrings(string a, string b)
            {
            BigInteger numOne, numTwo;
            BigInteger.TryParse( a, out numOne );
            BigInteger.TryParse( b, out numTwo );
            var sum = numOne + numTwo;
            return sum.ToString();
        }

    public static void Combine(string[] inputFiles, Stream output)
        {
        foreach (var file in inputFiles)
            {
            var reader = new Mp3FileReader(file);
            if ((output.Position == 0) && (reader.Id3v2Tag != null))
                {
                output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
                }
            Mp3Frame frame;
            while ((frame = reader.ReadNextFrame()) != null)
                {
                output.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }
        }

    }
    public class Evaluator
        {
        public double Evaluate(string expression)
            {
            if (string.IsNullOrWhiteSpace(expression)) return 0.0;
            var dt = new DataTable();
            var v = dt.Compute(expression, "");
            return Convert.ToDouble(v.ToString(),new NumberFormatInfo()
                {
                NumberDecimalDigits = 6
                });
            }
        }

    public class StringMerger
        {
        public static bool isMerge(string s, string part1, string part2)
            {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(part1) && string.IsNullOrEmpty(part2)) return true;
            var concatStr = part1 + part2;
            return s.Length == concatStr.Count(s.Contains);
            }
        }

    public class Arge
        {
        public static int NbYear(int p0, double percent, int aug, int p)
            {
            /*
             * In a small town the population is p0 = 1000 at the beginning of a year. 
             * The population regularly increases by 2 percent per year and moreover 50 new inhabitants per year come to live in the town. 
             * How many years does the town need to see its population greater or equal to p = 1200 inhabitants?
             * At the end of the first year there will be: 
1000 + 1000 * 0.02 + 50 => 1070 inhabitants

At the end of the 2nd year there will be: 
1070 + 1070 * 0.02 + 50 => 1141 inhabitants (number of inhabitants is an integer)

At the end of the 3rd year there will be:
1141 + 1141 * 0.02 + 50 => 1213

It will need 3 entire years.

            More generally given parameters:

p0, percent, aug (inhabitants coming or leaving each year), p (population to surpass)

the function nb_year should return n number of entire years needed to get a population greater or equal to p.

aug is an integer (> 0), percent a positive or null floating number, p0 and p are positive integers (> 0)
             */
            var popAsDouble = (double)p0;
            var numOfYear = 0;
            percent = percent / 100;
            while (popAsDouble <= p)
                {
                popAsDouble += popAsDouble * percent + Convert.ToDouble(aug);
                numOfYear++;
                }
            return numOfYear;
            }
        }
}
