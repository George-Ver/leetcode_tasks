//#define PERFOMANCE_MEASURE 

using leetcodeCSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace leetcodeCSharp.NumbersConvertions._7._Reverse_Integer
{
    internal class _2_Just_Integers_no_strings
    {
        private static int totalLen(int number)
        {

            int endInd = numbers10.Length;
            int startInd = 0;

            var res = 0;
            while (true)
            {
                var i = (endInd + startInd) / 2;
                if (number >= numbers10[i])
                {

                    if ((i >= numbers10.Length - 1) || (number < numbers10[i + 1]))
                    {
                        res = i;
                        break;
                    }
                    else
                    {
                        startInd = i + 1;
                    }
                }
                else
                {
                    if (number > numbers10[i - 1])
                    {
                        res = i - 1;
                        break;
                    }
                    endInd = i;

                }
            }
            return res + 1;
        }

        private static int divu10(int n, ref int rem)
        {
            int q, r;
            q = (n >> 1) + (n >> 2);
            q = q + (q >> 4);
            q = q + (q >> 8);
            q = q + (q >> 16);
            q = q >> 3;
            //  orig: r = n - q*10;
            r = n - ((q << 3) + (q << 1));
            rem = r > 9 ? r - 10 : r;

            //  orig: return q + ((r + 6) >> 4);
            return q + ((r > 9) ? 1 : 0);
        }
        private static int compareTwoIntArray(byte[] str1, byte[] str2)
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

        static readonly int[] numbers10 = [ 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000];
        

        private static byte[] ToDigitArrayReverse(int number )
        {
     
            if (number == 0)
            {
                return new byte[] { 0 };
            }
            //int i;
            //int res = numbers10.Length;
            //for (i = 0; i < numbers10.Length; i++)
            //    if (number < numbers10[i])
            //    {
            //        res = i; break;
            //    }

            int sz = 3;

            //int sz = totalLen(number);
            
            var  result = new  byte[10] ;


      
                
                var trueIndex = 0;
                //for ( ; trueIndex < sz; ) 
                while (number>0)
                {
                    //result[trueIndex] = 1;
                    result[trueIndex] = (byte) (number % 10); ;                    
                    number /= 10;
                    trueIndex++;
                }
                var trueRes= new byte[trueIndex ];
                Array.Copy(result, trueRes, trueIndex );
            
            return trueRes;
        }

        private static int FromDigitArray(byte[] number)
        {
            //return 50;
            int[] numbers10 = [1000000000, 100000000, 10000000, 1000000, 100000, 10000, 1000, 100, 10];
            int result = number[number.Length - 1];
            var delta = numbers10.Length - number.Length + 1;
            for (int i = 0; i < number.Length - 1; i++)
            {
                result += number[i] * numbers10[i + delta];
            }
            return result;
        }

        static readonly byte[] maxIntStr = [2, 1, 4, 7, 4, 8, 3, 6, 4, 7];
        
       
        public      int        Reverse(int x)
        {

            var result = 0;
            if ((x == int.MinValue) || (x == 0))

                return 0;

            var val = x;
            var isNegative = (x < 0);
            if (isNegative)
                val = -x;
            byte[] intArrayVal;
            intArrayVal = ToDigitArrayReverse(val);
            
            var isBigger = -1;
            if (intArrayVal.Length > 9)
                isBigger = compareTwoIntArray(intArrayVal, maxIntStr);
            if (isBigger <= 0)
            {
               result = FromDigitArray(intArrayVal);
                if (isNegative)
                    result = -result;
            }
            return   result;
        }

    }
}
