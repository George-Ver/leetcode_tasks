using System;   
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.Arrays._4_Median_of_Two_Sorted_Arrays
{
    internal class _1_SimpleNotLog
    {
        private int check_add(int[] arrFrom, ref int indexFrom )
        {

            //arr[index]=value;
            int result = arrFrom[indexFrom];
            indexFrom++;
            if (indexFrom == arrFrom.Length)
                indexFrom = -1;
            return result;      
        }
        private int[] MergeSorted(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];
            var nums1Ind = 0;
            var nums2Ind = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1Ind == -1)
                {
                    Array.Copy(nums2, nums2Ind, result, i, nums2.Length - i);
                    break;
                }
                if (nums2Ind == -1)
                {
                    Array.Copy(nums1, nums1Ind, result, i, nums1.Length - i);
                    break;
                }
                
                if (nums1[nums1Ind] > nums2[nums2Ind])
                {
                    result[i] = check_add( nums1,  ref  nums1Ind);   
                }
                else
                if (nums1[nums1Ind] == nums2[nums2Ind])
                {
                    result[i] = check_add(nums1, ref nums1Ind);
                    result[++i] = check_add(nums2, ref nums2Ind);
                }
                else {
                    result[i] = check_add(nums2, ref nums2Ind);                    
                }                                                            
            }
            return result;
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var merged = MergeSorted(nums1, nums2);
            var result = 0.0;
            if  (merged.Length % 2 == 0 )
                result = merged[merged.Length/2] + merged[merged.Length / 2 - 1 ] ;
            else
                result = merged[merged.Length / 2] ;
            return result;
        }
    }
}
