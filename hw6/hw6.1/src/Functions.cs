using System;
using System.Collections.Generic;

namespace src
{
    /// <summary>
    /// Class with implementation list functions.
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Map list function.
        /// </summary>
        /// <param name="inputList">List for mapping.</param>
        /// <param name="function">Function of mapping.</param>
        /// <returns>Mapped list.</returns>
        public static List<int> Map(List<int> inputList, Func<int, int> function)
        {
            var outputList = new List<int>();

            foreach (var item in inputList)
            {
                outputList.Add(function(item));
            }

            return outputList;
        }

        /// <summary>
        /// Filter list function.
        /// </summary>
        /// <param name="inputList">List for filtering.</param>
        /// <param name="function">Function of filtering.</param>
        /// <returns>List after filtered.</returns>
        public static List<int> Filter(List<int> inputList, Func<int, bool> function)
        {
            var outputList = new List<int>();

            foreach (var item in inputList)
            {
                if (function(item))
                {
                    outputList.Add(item);
                }
            }

            return outputList;
        }

        /// <summary>
        /// Fold list function.
        /// </summary>
        /// <param name="inputList">List for folding.</param>
        /// <param name="accumulator">accumulator.</param>
        /// <param name="function">Function of folding.</param>
        /// <returns>accumulator after folding.</returns>
        public static int Fold(List<int> inputList, int accumulator, Func<int, int, int> function)
        {
            foreach (var item in inputList)
            {
                accumulator = function(accumulator, item);
            }

            return accumulator;
        }
    }
}