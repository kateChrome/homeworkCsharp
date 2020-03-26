using System;
using System.Collections.Generic;

namespace src
{
    public class Functions
    {
        public static List<int> Map(List<int> inputList, Func<int, int> function)
        {
            var outputList = new List<int>();

            foreach (var item in inputList)
            {
                outputList.Add(function(item));
            }

            return outputList;
        }

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