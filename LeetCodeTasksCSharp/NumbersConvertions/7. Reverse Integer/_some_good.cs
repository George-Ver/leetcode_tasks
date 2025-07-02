using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.NumbersConvertions._7._Reverse_Integer
{
    internal class _some_good
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
        public int ReverseEx(int x)
        {
            int reversed = 0;
            if ((x == int.MinValue) || (x == 0))
                return 0;
            var isNegative = (x < 0);
            var val = x;
            //if (isNegative)
            //    val = -x;

            while (x != 0)
            {
                int digit = val % 10;
                val /= 10;
                if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }
                //if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && digit < -8))
                //{
                //    return 0;
                //}
                reversed = reversed * 10 + digit;                
            }
            //if (isNegative)
            //    reversed= -reversed;
            return reversed;
        }
    }
}
