using System.Linq;


namespace CodeWar
{
    public class StringMerger
        {
        public static bool IsMerge(string s, string part1, string part2)
            {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(part1) && string.IsNullOrEmpty(part2)) return true;
            var concatStr = part1 + part2;
            return s.Length == concatStr.Count(s.Contains);
            }
        }
}
