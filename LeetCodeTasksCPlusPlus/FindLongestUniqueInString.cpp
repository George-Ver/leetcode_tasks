// FindLongestUniqueInString.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
using namespace std;





 class CStringUtuls 
 {
  
     friend class Tester;
       

 protected:

     class CharMemoryHandler
     {
     protected:
         //static 
         const static  unsigned char  maxSymLen = 128;
         //vars
         int storage[maxSymLen];
         unsigned char count = 0;
         int firstValue = -1;

         //functions
         inline void CheckInit(int position) {
             if (this->count == 0)
                 this->firstValue = position;
         }

     public:
         //getters
         inline unsigned char get—ount() {
             return count;
         }



         inline unsigned char getFirstValue() {
             return firstValue;
         }

         bool ContrainsKey(char key) {
             unsigned char k = (unsigned char)key;
             return storage[k] > 0;
         }
         inline bool TryGetValue(char key, int& position) {
             auto result = false;
             unsigned char k = (unsigned char)key;
             auto ks = storage[k];
             result = ks > 0;
             position = ks - 1;
             return result;
         }


         inline void RewriteValueUnsafe(char key, int position) {
             auto k = (unsigned char)key;
             this->storage[k] = position + 1;
         }

         inline void SetValue(char key, int position) {
             auto k = (unsigned char)key;
             CheckInit(position);
             if (this->storage[k] == 0)
                 this->count++;
             this->storage[k] = position + 1;
         }

         inline bool  TrySetValue(char key, int position, int& oldPostion) {
             auto k = (unsigned char)key;
             CheckInit(position);
             auto old_Postion = this->storage[k];
             bool result = (old_Postion == 0);
             if (result) {
                 this->count++;
                 this->storage[k] = position + 1;
                 oldPostion = -1;
             }
             else {
                 oldPostion = old_Postion - 1;
             }
             return result;

         }

         inline void  RemoveValueUnsafe(char key) {
             auto k = (unsigned char)key;
             this->count--;
             this->storage[k] = 0;
         }

         inline void  RemoveValuesStringUnsafe(string aString, int start, int endPos) {

             for (int curIndex = start; curIndex <= endPos; curIndex++)
             {
                 auto k = (unsigned char)aString[curIndex];
                 this->count--;
                 this->storage[k] = 0;
             }
         }

         inline void  RemoveValuesStringFromFirstUnsafe(string aString, int endPos, int newStartPos) {
             RemoveValuesStringUnsafe(aString, firstValue, endPos);
             this->firstValue = newStartPos;
         }

         inline void Clear() {
             this->count = 0;
             this->firstValue = -1;
             memset(this->storage, 0, maxSymLen * sizeof(int));
         }

     };

    inline  int lengthOfLongestSubstringExt(string s, int& currentMaxStart) {
         CharMemoryHandler dictionary = CharMemoryHandler();

         int startPosition = 0;
         int currentMaxLen = 0;
         int  currentPosition = 0;
         auto newStartPos = -1;
         bool startPosMoved = false;
         while (s.length() - startPosition + dictionary.get—ount() > currentMaxLen)
         {
             for (currentPosition = startPosition; currentPosition < s.length(); currentPosition++)
             {
                 char currentChar = s[currentPosition];
                 int oldPosition = 0;
                 if (dictionary.TrySetValue(currentChar, currentPosition, oldPosition))
                 {
                     startPosMoved = true;
                     newStartPos = currentPosition + 1;
                     //currentLen = this->dictionary.get—ount();
                     int relativePos = oldPosition - startPosition;
                     if (relativePos < 80)
                     {
                         dictionary.RemoveValuesStringFromFirstUnsafe(s, oldPosition - 1, oldPosition + 1);
                         auto currentLen12 = dictionary.get—ount();
                         dictionary.RewriteValueUnsafe(currentChar, currentPosition);
                     }
                     else
                     {
                         dictionary.Clear();
                         newStartPos = oldPosition + 1;
                     }
                     break;
                 }
             }

             auto currentLen = dictionary.get—ount();
             if (currentLen > currentMaxLen) {
                 currentMaxLen = currentLen;
                 currentMaxStart = currentPosition - currentLen;
             }
             startPosition = newStartPos;
             if (!startPosMoved) {
                 break;
             }
         }
         dictionary.Clear();
         return currentMaxLen;
     }

      
 public:


     inline int lengthOfLongestSubstring(string s) {
         int _out1 = 0;
         auto result = lengthOfLongestSubstringExt(s, _out1 );
         return result;
     //    CharMemoryHandler dictionary = CharMemoryHandler();
     //    int startPosition = 0;
     //    int currentMaxLen = 0;
     //    int  currentPosition = 0;
     //    auto newStartPos = -1;
     //    int currentLen = 0;
     //    bool startPosMoved = false;
     //    while (s.length() - startPosition + dictionary.get—ount() > currentMaxLen)
     //    {
     //        for (currentPosition = startPosition; currentPosition < s.length(); currentPosition++)
     //        {
     //            char currentChar = s[currentPosition];
     //            int oldPosition = 0;
     //            if (dictionary.TrySetValue(currentChar, currentPosition, oldPosition))
     //            {
     //                startPosMoved = true;
     //                newStartPos = currentPosition + 1;
     //                currentLen = dictionary.get—ount();
     //                int relativePos = oldPosition - startPosition;
     //                if (relativePos < 80)
     //                {
     //                    dictionary.RemoveValuesStringFromFirstUnsafe(s, oldPosition - 1, oldPosition + 1);
     //                    //auto currentLen12 = dictionary.get—ount();
     //                    dictionary.RewriteValueUnsafe(currentChar, currentPosition);
     //                }
     //                else
     //                {
     //                    dictionary.Clear();
     //                    newStartPos = oldPosition + 1;
     //                }
     //                break;
     //            }
     //        }

     //        if (!startPosMoved) {
     //            currentLen = dictionary.get—ount();

     //        }
     //        if (currentLen > currentMaxLen) {
     //            currentMaxLen = currentLen;                 
     //        }
     //        startPosition = newStartPos;
     //        if (!startPosMoved) {
     //            break;
     //        }
     //    }
     //    dictionary.Clear();         
     //    return currentMaxLen;
     }




};

 class Tester {


 public:
     static  void MakeTests()
 {
     auto  t = new CStringUtuls();

     std::vector < pair< string, int> > testData =  {
             {"abcdae", 5},
              {"abcd" , 4},
             {"gaaqfeqlqky", 4},
             {"wslznzfxojzd", 6},             
             {"abcdab", 4},             
             
             {"bbbbb", 1},
             {"abcddfghk", 5},
             {"bcdebcdebcde",4},
             {"9yA3UZqiBP4XsKtwvphJfRe0G1FoLmauOX7nV6CzHdYQkEgcrMbDjlsWTN58bx2n3tyaVXqpBJzuYFdSkRWcE50gT4lAo9LKhP",47},
             {"W29vXJReukBtS4YnNfTqgKcwEp37HjOaMi5y0dUzmbZCxhGLF1rl6sDAIVonP8bqEyWv3cgTzLAKX9NPusMQJ7hY50RmOdi2ft",59},
             {"q8DsNfYBv4Ejz3LmuARkC0GVxQZeMtwKH1py9iFSaTXn6U7oMg5cqbdRLPJIazshONvEWr9UxJfKY3tmAQzvnhFexLdcPSToBW" , 48},
             {"ZlM1ayTJuINXvCErQb6dz2sLgfVm8YRKtpPxW39AoeBHD70UwcFkhnUJ5OMqvLRtXYNsZa6iW0ePClHqfTGyn8K9mjdE3br4SB" , 54},
             {"9kYhOJIz2PB0AmXGpNv7dCR3eq5VLnZsaoQEytrTFwWfKuHMiD86U4jg1blcxzMWTEnpRFa3YuqhGSkodXZmbVN5wLCPt7rAi0", 61}
     };
     for (int i = 0; i < testData.size();i++) {
         
         auto x = testData[i];
         int currentMaxStart = 0;
         auto  s0 = t->lengthOfLongestSubstringExt(x.first,  currentMaxStart);
         if (x.second > 0)
         {
             if (s0 != x.second)
             {
                 //bool res = TestUnique(x.astr, currentMaxStart, s0);
                 //Console.WriteLine(string.Format("errpr in case  %0 Should be length %1 , but got %2 ", x.astr, x.longestLen, s0));
                 int i = 0;
             }
         }
     }
     delete t;
 }
     
 };

int main()
{
    auto stringUtils = new CStringUtuls();
    auto startPos = -1;
    //auto tester = new Tester();
    Tester::MakeTests();
    /*auto result = stringUtils->lengthOfLongestSubstring("wslznzfxojzd", startPos);

    if (result != 6) {
        std::cout << "Hello World!\n";
    }*/
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
