using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace CodeWar
{

    public static class Kata
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            var newList = arr.ToList();

            var group = arr.ToList().GroupBy(v => v);

            foreach (var g in group.Where(g => g.Count() > x))
            {
                newList.RemoveAt(newList.LastIndexOf(g.Key));
                DeleteNth(newList.ToArray(), x);
            }
            return newList.ToArray();
        }

        public static string PigIt(string str)
        {
            var splittedArr = str.Split(' ');
            var resultBuilder = new StringBuilder();
            foreach (var s in splittedArr)
            {
                resultBuilder.Append(s.Substring(1) + s.First() + "ay");
                resultBuilder.Append(" ");
            }
            return resultBuilder.ToString().TrimEnd();
        }

        public static string ToCamelCase(string str)
        {
            if (str.Length == 0) return "";
            var arr = str.Split('-', '_');

            var resultBuilder = new StringBuilder();
            foreach (var s in arr)
            {
                resultBuilder.Append(s[0].ToString().ToUpper());
                resultBuilder.Append(s.Substring(1).ToLower());
            }
            if (resultBuilder.Length > 0)
                resultBuilder[0] = arr[0][0];
            return resultBuilder.ToString();
        }



        public static string HighAndLow(string numbers)
        {
            return string.Join(" ", numbers.Split(' ').Select(x => Convert.ToInt32(x)).Max(),
                numbers.Split(' ').Select(x => Convert.ToInt32(x)).Min());
        }
        public static int[] minMax(int[] lst)
        {
            return new[] { lst.Min(), lst.Max() };
        }
        public static string Pattern(int n)
        {
            if (n < 1) return "";
            var resultStrBuilder = new StringBuilder();
            for (var i = 1; i < n; i++)
            {
                var j = i;
                while (j <= 1)
                {
                    resultStrBuilder.Append(j);
                    j--;
                }
                resultStrBuilder.AppendLine();
            }
            return resultStrBuilder.ToString();
        }


        public static int GetSum(int a, int b)
        {
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

        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }
        public static long rowSumOddNumbers(long n)
        {
            var sum = 0;
            var oddTriangle = new Dictionary<long, long>();
            for (var i = 1; i < 100; i++)
            {
                oddTriangle[i] = GetOddSum(i);
            }

            return oddTriangle[n];
        }

        public static long GetOddSum(int upper)
        {
            var sum = 0;
            for (var i = 1; i <= upper; i++)
            {
                if (i % 2 == 1)
                    sum += i;
            }
            return sum;
        }

        public static int NumberOfOccurrences(int x, int[] xs)
        {
            return xs.ToList().Count(t => t == x);
        }


        public static string orderWeight(string strng)
        {
            if (string.IsNullOrEmpty(strng)) return "";
            var splittedArr = strng.Split(' ');
            var sum = 0;
            var orderArr = new List<int>();
            foreach (var aa in splittedArr)
            {
                sum += aa.Sum(c => Convert.ToInt32(c.ToString()));
                orderArr.Add(sum);

                sum = 0;
            }
            var resultBuilder = new StringBuilder();
            return resultBuilder.ToString().TrimEnd();
        }


        public static string Tickets(int[] peopleInLine)
        {
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
            var max = nums[0];
            var list = nums.ToList();
            var builder = new StringBuilder();
            foreach (var i in list)
            {
                if (i > max)
                {
                    max = i;
                    builder.Insert(0, max);
                    list.Remove(max);
                }
                else
                {
                    builder.Append(max);
                }
            }

            return builder.ToString();

        }

        public static int Find(int[] integers)
        {
            var returnInt = -1;
            var even = integers.Count(x => x % 2 == 0);
            var odd = integers.Count(x => x % 2 == 1);
            if (even == 1)
                returnInt = integers.First(x => x % 2 == 0);
            if (odd == 1)
                returnInt = integers.First(x => x % 2 == 1);
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
            if (string.IsNullOrEmpty(input))
                return true;
            if (input.Length % 2 == 1)
                return false;

            var partOne = input.Substring(0, input.Length / 2);
            var partTwo = input.Substring(input.Length / 2, input.Length / 2);
            var leftSideStack = new Stack<string>();
            var rightSideStack = new Stack<string>();
            foreach (var c in partOne)
            {
                leftSideStack.Push(c.ToString());
            }
            foreach (var c in partTwo)
            {
                rightSideStack.Push(c.ToString());
            }
            var matchCount = 0;
            for (var i = 0; i < leftSideStack.Count; i++)
            {
                var left = leftSideStack.Pop();
                var right = rightSideStack.Pop();
            }

            return false;
        }

        public static int Sum(int[] numbers)
        {
            if (numbers == null)
                return 0;
            if (numbers.Length == 0 || numbers.Length == 1)
                return 0;
            var numbersAsList = numbers.ToList();
            var excludedValues = new[] { numbers.Min(), numbers.Max() };
            foreach (var num in excludedValues)
            {
                numbersAsList.Remove(num);
            }
            return numbersAsList.Sum();
        }
        public static int SquareDigits(int n)
        {
            var result = "";
            foreach (var c in n.ToString())
            {
                result += Convert.ToInt32(c.ToString()) * Convert.ToInt32(c.ToString());
            }

            return Convert.ToInt32(result);
        }
        public static string High(string s)
        {
            var words = s.Split(' ');
            var word = "";
            var score = 0;
            var index = 0;
            var alpha = CreateAlphabet();
            for (var i = 0; i < words.Length; i++)
            {
                if (GetWordScore(alpha, words[i]) > score)
                {
                    score = GetWordScore(alpha, words[i]);
                    word = words[i];
                    index = i;
                }
                else if (GetWordScore(alpha, words[i]) == score)
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
        public static int GetWordScore(List<string> alphabet, string word)
        {
            return word.Sum(c => alphabet.IndexOf(c.ToString()));
        }

        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (!numbers.Any()) return new List<int>();
            var min = numbers.Min();
            if (numbers.Count(x => x == min) > 1)
            {
                numbers.RemoveAt(numbers.IndexOf(min));
            }
            else
            {
                numbers.Remove(min);
            }
            return numbers;
        }
        public static string Reverse(string str)
        {
            var reversed = "";
            for (var i = str.Length - 1; i >= 0; i--)
            {
                reversed += str[i];
            }
            return reversed;
        }
        public static string[] GetUserIds(string s)
        {
            var separator = new[] { ", " };
            var splittedIds = s.Split(separator, StringSplitOptions.None);
            var returnedIds = new string[splittedIds.Length];
            for (var i = 0; i < splittedIds.Length; i++)
            {
                splittedIds[i] = splittedIds[i].Trim(' ');
                splittedIds[i] = splittedIds[i].Replace("#", "");
                splittedIds[i] = splittedIds[i].ToLower();
                if (splittedIds[i].IndexOf("uid", StringComparison.CurrentCultureIgnoreCase) == 0)
                    splittedIds[i] = splittedIds[i].Replace("uid", "");
                returnedIds[i] = splittedIds[i];
            }

            return returnedIds;
        }
        public static int TrailingZeros(int n)
        {
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
            BigInteger.TryParse(a, out numOne);
            BigInteger.TryParse(b, out numTwo);
            var sum = numOne + numTwo;
            return sum.ToString();
        }



        public static Dictionary<char, int> GenerateAlphaPos()
        {
            var result = new Dictionary<char, int>();
            var i = 0;
            for (var c = 'a'; c <= 'z'; c++)
            {
                i++;
                result.Add(c, i);
            }
            return result;
        }
        public static string AlphabetPosition(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var myRegex = new Regex("[^a-z]", RegexOptions.IgnoreCase);
            text = myRegex.Replace(text, @"");
            var dictionary = GenerateAlphaPos();
            var textAsDigit = "";
            text = text.Replace(" ", "");
            foreach (var ch in text)
            {
                char? key = dictionary.Keys.FirstOrDefault(k => k == Convert.ToChar(ch.ToString().ToLower()));
                if (key != null)
                {
                    textAsDigit += $"{dictionary[key.Value]} ";
                }
            }
            textAsDigit = textAsDigit.TrimEnd();
            return textAsDigit;
        }
        public static string ReverseWords(string str)
        {
            var splitted = str.Split(new[] { ' ' });
            var reversed = "";
            for (var i = splitted.Length - 1; i >= 0; i--)
            {
                reversed += $"{splitted[i]} ";
            }
            reversed = reversed.TrimEnd();
            return reversed;
        }

        public static string Change(string input)
        {
            var result = new StringBuilder("00000000000000000000000000");
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            input = input.ToLower();
            foreach (var ch in input)
            {
                if (alphabet.Contains(ch.ToString()))
                {
                    var index = GenerateAlphaPos()[ch];
                    result[index - 1] = Convert.ToChar("1");
                }
            }
            return result.ToString();
        }
    }
}
