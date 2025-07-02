using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.StringProblems._3._Longest_Substring_Without_Repeating_Characters
{
    internal class _2_extended_way_with_dictinary
    {
        public int LengthOfLongestSubstring(string s)
        {
            return LengthOfLongestSubstring(s, out _ );
        }
        internal int LengthOfLongestSubstring(string s, out int currentMaxStart)
        {
            var startPosition = 0;
            var currentMaxLen = 0;
            var searchDict = new Dictionary<char, int>();
            var currentLen = 0;
            var newCurrentLen = 0;
            currentMaxStart = 0;
            var newStartPos = 0;
            var dictionaryStartPosition = 0;
            while ((s.Length - startPosition + searchDict.Count) > currentMaxLen)
            {
                var startPosMoved = false;
                int currentPosition;
                for (currentPosition = startPosition; currentPosition < s.Length; currentPosition++)
                {
                    var currentChar = s[currentPosition];
                    int symbolPos;
                    if (!searchDict.TryGetValue(currentChar, out symbolPos))
                    {
                        searchDict[currentChar] = currentPosition;
                        currentLen++;
                        if (dictionaryStartPosition == -1)
                        {
                            dictionaryStartPosition = currentPosition;
                        }
                    }
                    else
                    {
                        startPosMoved = true;
                        newStartPos = symbolPos + 1;
                        var relativePos = symbolPos - startPosition;
                        if (relativePos < currentLen / 2)
                        {
                            for (var i = dictionaryStartPosition; i < newStartPos; i++)
                            {
                                searchDict.Remove(s[i]);
                            }
                            searchDict[currentChar] = currentPosition;
                            dictionaryStartPosition = symbolPos + 1;
                            newStartPos = currentPosition + 1;
                            newCurrentLen = searchDict.Count;
                        }
                        else
                        {
                            searchDict.Clear();
                            newCurrentLen = 0;
                            dictionaryStartPosition = -1;
                        }

                        break;
                    }
                }
                if (currentLen > currentMaxLen)
                {
                    currentMaxLen = currentLen;
                    currentMaxStart = currentPosition - currentLen;
                }
                currentLen = newCurrentLen;
                startPosition = newStartPos;
                if (!startPosMoved)
                {
                    startPosition = s.Length;
                    searchDict.Clear();
                }
            }
            return currentMaxLen;
        }
    }
}
