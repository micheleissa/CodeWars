using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWar
{
    public class StockList
    {
        //Help the bookseller !
        public static string StockSummary(string[] lstOfArt, string[] lstOf1stLetter)
        {
            if (lstOfArt.Length == 0 || lstOf1stLetter.Length == 0)
                return "";
            var resultBuilder = new StringBuilder();
            foreach (var s in lstOf1stLetter)
            {
                var s1 = s;
                var categoryList = lstOfArt.Where(c => s1.Contains(c[0])).ToList();
                var copies = categoryList.Select(c => int.Parse(c.Split(' ')[1])).Sum();
                resultBuilder.Append(string.Format("({0} : {1}) - ", s1, copies)); //(A : 200) - (B : 1140)
            }
            var result = resultBuilder.ToString().TrimEnd();
            result = result.TrimEnd( '-' );
            return result.TrimEnd();


        }

    }
}
