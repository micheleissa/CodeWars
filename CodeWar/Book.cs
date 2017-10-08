using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWar
{
    public class Book
    {
        public static int DayIs(int pages, int[] days)
            {
            // Your code is here...
            var daysInWeek = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < daysInWeek.Count; i++)
                dictionary[i+1] = days[i];
            var count = 1;
            var day = -1;
            while (count <= 7)
                {
                pages -= dictionary[count];
                if (pages <= 0)
                    {
                    day = count;
                    break;
                    }
                count++;
                }
            if (day < 0)
                {
                DayIs( pages, days );
                }
            return day;
            }

        public static string sumStrings(string a, string b)
            {
            return new[] {a, b}.Sum(x => Convert.ToDouble(x)).ToString("N30").Split( '.' )[0].Replace( ",","" );
            }
    }
}
