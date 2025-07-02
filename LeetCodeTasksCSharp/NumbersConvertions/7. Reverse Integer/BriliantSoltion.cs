using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.StringProblems._3._Longest_Substring_Without_Repeating_Characters
{
    internal class BriliantSoltion
    {
        public int Reverse(int x)
        {
            int reversed = 0;
            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;
                if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }
                if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && digit < -8))
                {
                    return 0;
                }

                reversed = reversed * 10 + digit;
            }
            return reversed;
        }
    }
}
