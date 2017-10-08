using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWar
{

    public static class Kata
    {
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
