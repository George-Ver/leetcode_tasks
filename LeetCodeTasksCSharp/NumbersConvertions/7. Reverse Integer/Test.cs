using leetcode.StringProblems._3._Longest_Substring_Without_Repeating_Characters;
using leetcodeCSharp.Helpers;
using leetcodeCSharp.StringProblems._3._Longest_Substring_Without_Repeating_Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcodeCSharp.NumbersConvertions._7._Reverse_Integer
{
    
    public class Test
    {
        static readonly int[] testInputs = [
                //123,                  
                -123,
                -10,
            -100,
            110,
                  
            
                  123456789,
                 2147483647,
                -2147483648,
                122183648,
                433434343,
                11112222,
                33333,
                444423344,
                     -2147482648,
            -21474638,
            -2147464,
            -10,
                  -123,
                  123456789,
                 2147483647,
                -214783648,
                12218648,
                43343343,
                11112222,
                333333,
                444424344,
                     -2147482648,
            -21474438,
            -2147444

                ];
        public static void TestReverse()
        {
    ;
            


            var reverser1 = new _1_SimplestWay();
            var reverser2 = new _2_Just_Integers_no_strings();
            var reverser3 = new _some_good();
            int res1 = 0;
            //res1=_2_Just_Integers_no_strings.totalLen(2);
            //res1=-_2_Just_Integers_no_strings.totalLen(30);
            //res1=_2_Just_Integers_no_strings.totalLen(100001);
            //res1 = _2_Just_Integers_no_strings.totalLen(9999);
            //res1 = _2_Just_Integers_no_strings.totalLen(int.MaxValue);
            int res, res2 = 0;
            
            //TimeSpan tmp = new TimeSpan();
            long ticksDiv = 0;
            long ticksMultipy = 0;
            long totalDiv = 0;
            long totalMult = 0;

            var s1 =
                reverser3.Reverse(123123212);
            var s2 =
                reverser3.Reverse(-123123212);
            var s3 =
                reverser3.Reverse(-2147483648);
            ticksDiv = 0;
            ticksMultipy = 0;
            var resultsDiv = new long[testInputs.Length];
            var results = new int[testInputs.Length];
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < testInputs.Length; i++)
            {
                int testted = testInputs[i];
                res = reverser1.Reverse(testted);
                results[i] = res;
                //res2 =
                //var functionRes
                // =                
                //    reverser2.Reverse(testted);
                //if (functionRes.GetType() == typeof(int))
                //{
                //    res2 = functionRes;
                //}
                //else
                //    (res2, ticksDiv, ticksMultipy) = Unsafe.As < Tuple<int, long, long> > (functionRes);

                //totalDiv += ticksDiv;
                //totalMult += ticksMultipy;
                //resultsDiv[i] = ticksDiv;
                res2 = reverser3.Reverse(testted);
                //results[i] = res;
                //ticksDiv = 0;
                //ticksMultipy = 0;


                if (res != res2)
                {
                    int y = 0;
                }

            }
            stopWatch.Stop();
            var ts = stopWatch.ElapsedTicks;
            //System.Diagnostics.Debug.Write(ts.ToString());
        //for (int i = 0; i < results.Length; i++)
        //    {
        //        Console.WriteLine("resuts  " + results[i].ToString());
        //    }
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine("resuts  " + results[i].ToString());
            }

            Console.WriteLine("fulltime  "   + ts.ToString());            
            //Console.WriteLine("tickDiv  " + totalDiv.ToString());
            //Console.WriteLine("tickMultipy  " + totalMult.ToString());
        }

    }
}
