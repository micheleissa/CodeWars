using System;
using System.Linq;
namespace CodeWar
{
    public class AreTheySame
    {
        public static bool Comp(int[] a, int[] b)
        {
            // your codere
            if(a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;

            var count = b.ToList().Count( d => a.ToList().IndexOf( (int)Math.Sqrt( d ) ) != -1 );
            return count == a.Length;
        }
    }
}
