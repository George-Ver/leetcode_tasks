
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.StringProblems._3._Longest_Substring_Without_Repeating_Characters
{
    internal class StringReverseTester
    {
        public static bool TestUnique(string s, int startPosition, int len)

        {
            var result = true;
            var searchDict = new Dictionary<char, int>();
            for (int currentPosition = startPosition; currentPosition < startPosition + len; currentPosition++)
            {
                var currentChar = s[currentPosition];
                if (searchDict.ContainsKey(currentChar))
                {
                    result = false;
                }
                else
                    searchDict[currentChar] = currentPosition;
            }
            return result;
        }

        public static void MakeTests()
        {
            var t = new _2_extended_way_with_dictinary();

            var testData = new List<(string astr, int longestLen)>  {
                ("wslznzfxojzd", 6),
                ("gaaqfeqlqky", 4),
                ("abcdab", 4),
                ("abcd" , 4),
                ("abcdae", 5),
                ("bbbbb", 1),
                ("abcddfghk", 5),
                ("bcdebcdebcde",4),
                ("9yA3UZqiBP4XsKtwvphJfRe0G1FoLmauOX7nV6CzHdYQkEgcrMbDjlsWTN58bx2n3tyaVXqpBJzuYFdSkRWcE50gT4lAo9LKhP",47),
                ("W29vXJReukBtS4YnNfTqgKcwEp37HjOaMi5y0dUzmbZCxhGLF1rl6sDAIVonP8bqEyWv3cgTzLAKX9NPusMQJ7hY50RmOdi2ft",59),
                ("q8DsNfYBv4Ejz3LmuARkC0GVxQZeMtwKH1py9iFSaTXn6U7oMg5cqbdRLPJIazshONvEWr9UxJfKY3tmAQzvnhFexLdcPSToBW" , 48  ),
                ("ZlM1ayTJuINXvCErQb6dz2sLgfVm8YRKtpPxW39AoeBHD70UwcFkhnUJ5OMqvLRtXYNsZa6iW0ePClHqfTGyn8K9mjdE3br4SB" , 54 ),
                ("9kYhOJIz2PB0AmXGpNv7dCR3eq5VLnZsaoQEytrTFwWfKuHMiD86U4jg1blcxzMWTEnpRFa3YuqhGSkodXZmbVN5wLCPt7rAi0", 61 )
               };
            var secondReverser = new _2_extended_way_with_dictinary();

            foreach (var x in testData)
            {
                var currentMaxStart = 0;
                var s0 = secondReverser.LengthOfLongestSubstring(x.astr, out currentMaxStart);
                if (x.longestLen > 0)
                {
                    if (s0 != x.longestLen)
                    {
                        bool res = TestUnique(x.astr, currentMaxStart, s0);
                        Console.WriteLine(string.Format("errpr in case  %0 Should be length %1 , but got %2 ", x.astr, x.longestLen, s0));
                        int i = 0;
                    }
                }
            }

        }
    }
}
