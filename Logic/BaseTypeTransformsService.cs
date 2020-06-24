using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Service for transformations with base types: string, int, array, etc
    /// </summary>
    public class BaseTypeTransformsService
    {
        /// <summary>
        /// Returns reversed incoming string
        /// </summary>
        /// <param name="s">Incoming string for reversion</param>
        /// <returns>Reversed string</returns>
        public string ReverseString(string s)
        {
            if (s == null) throw new ArgumentNullException();
            //char[] charArray = s.ToCharArray(); 
            //Array.Reverse(charArray); // would do this but almost same as String.Reverse()

            IEnumerable<char> reversed = Enumerable.Empty<char>();
            s.ToList().ForEach(x => reversed = reversed.Prepend(x));
            return new string(reversed.ToArray());
        }
        /// <summary>
        /// determines if incoming string is a palindrome
        /// </summary>
        /// <param name="s">incoming string</param>
        /// <returns>is palindrome</returns>
        public bool IsPalindrome(string s)
        {
            if (s == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("argument string is empty");
            return s.Equals(ReverseString(s), StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// Returns a collection of missing numbers in ascending order
        /// </summary>
        /// <param name="arr">array of numbers in ascending order</param>
        /// <returns>missing numbers in ascending order</returns>
        public IEnumerable<int> MissingElements(params int[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            IEnumerable<int> result = Enumerable.Empty<int>();
            if (arr.Length == 0) return result;
            int prevValue = arr[0]-1;

            foreach (var item in arr)
            {
                bool isNotMinValue = item != int.MinValue;
                //no throw, if (item == the minimal value of type)
                if (prevValue >= item && isNotMinValue) 
                    throw new ArgumentException("Wrong order of array");
                int expetedPrev = prevValue + 1;
                if (item != expetedPrev)
                {
                    var differenseSequense = CountMissingDifference(expetedPrev, item);
                    result = result.Concat(differenseSequense);
                }
                prevValue = item;
            }
            return result;
        }

        /// <summary>
        /// Transforms two integer numbers into collection of numbers between them
        /// </summary>
        /// <param name="min">lowest number</param>
        /// <param name="max">highest number</param>
        /// <returns>collection of integer numbers between two numbers</returns>
        private IEnumerable<int> CountMissingDifference(int min, int max)
        {
            if (min > max) throw new ArgumentException("minimal value cant be more than maximum value");
            IEnumerable<int> result = Enumerable.Empty<int>();
            for (int i = min; i < max; i++)
            {
                result = result.Append(i);
            }
            return result;
        }
    }
}
