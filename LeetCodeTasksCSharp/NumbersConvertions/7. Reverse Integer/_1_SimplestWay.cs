using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.NumbersConvertions._7._Reverse_Integer
{
    internal class _1_SimplestWay
    {
        private static int compareTwoIntStr(string str1, string str2)
        {
            int res = 0;
            if (str1.Length == str2.Length)
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] == str2[i])
                        continue;
                    res = str1[i] > str2[i] ? 1 : -1;
                    break;
                }
            else
                res = (str1.Length > str2.Length) ? 1 : -1;
            return res;
        }


        public int Reverse(int x)
        {
            var result = 0;
            const string maxIntStr = "2147483647";
            var isNegative = x < 0;
            var val = x;
            if (isNegative)
            {
                if (x == int.MinValue)
                    return 0;
                val = -x;
            }
            var strValue = val.ToString();
            char[] charArray = strValue.ToCharArray();
            Array.Reverse(charArray);
            var strVal = new string(charArray);
            var isBigger = -1;
            if (strVal.Length > 9 && strVal[0] >= '2')
                isBigger = compareTwoIntStr(strVal, maxIntStr);
            if (isBigger <= 0)
            {
                result = int.Parse(strVal);
                if (isNegative)
                    result = -result;
            }
            return result;
        }

    }
}
