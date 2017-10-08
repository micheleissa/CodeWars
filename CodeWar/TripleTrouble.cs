using System.Collections.Generic;
using System.Linq;

namespace CodeWar
{
    public class TripleTrouble
    {
        public static int TripleDouble(long num1, long num2)
        {
            var listOne = num1.ToString().ToList();
            var foundAsTriple = listOne.FirstOrDefault( x => GetCount(num1.ToString().ToList(), x ) >= 3 );
            var listTwo = num2.ToString().ToList();
            var foundInNum2 = listTwo.Any( x => GetMatch( num2.ToString().ToList(), foundAsTriple) );
            return foundInNum2 ? 1 : 0;
            /*
             * List<string> results = new List<string>();
foreach (var element in array)
{
    if(results.Count == 0 || results.Last() != element)
        results.Add(element);
}
             */
        }

        private static int GetCount( List<char> list, char key )
            {
            list.Sort();

            return list.FindAll( x => x == key ).Count();
            }

        private static bool GetMatch( List<char> list, char key )
            {
            list.Sort();
            return list.FindAll( x => x == key ).Count() >= 2;
            }
    }
}
