using System;
using System.Collections.Generic;

namespace UniqueList
{
    /// <summary>
    /// Class with implementation unique list structure.
    /// </summary>
    /// <typeparam name="T">type of items.</typeparam>
    public class UniqueList<T>
    {
        private List<T> uniqueList;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList"/> class.
        /// </summary>
        /// <typeparam name="T">type of items.</typeparam>
        public UniqueList() { uniqueList = new List<T>(); }

        /// <summary>
        /// Add data to tail of the unique list.
        /// </summary>
        public void AddData(T data)
        {
            if (uniqueList.Contains(data))
            {
                throw new ElementAlreadyExistException($"{data} already exist in the unique list");
            }

            uniqueList.Add(data);
        }

        /// <summary>
        /// Remove data from the unique list.
        /// </summary>
        public void RemoveData(T data)
        {
            if (!uniqueList.Contains(data))
            {
                throw new ElementDoesNotExistException($"{data} does not exist in the unique list");
            }

            uniqueList.Remove(data);
        }

        /// <summary>
        /// Get size of the unique list.
        /// </summary>
        public int GetSizeOfList() => uniqueList.Count;

        /// <summary>
        /// Сheck the the unique list for emptiness 
        /// </summary>
        public bool IsEmpty() => GetSizeOfList() == 0;

        /// <summary>
        /// add data by index in the unique list.
        /// </summary>
        public void InsertData(int index, T data)
        {
            if (uniqueList.Contains(data))
            {
                throw new ElementAlreadyExistException($"{data} already exist in the unique list");
            }

            uniqueList.Insert(index, data);
        }

        /// <summary>
        /// Remove data by index from the unique list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDataByIndex(int index)
        {
            uniqueList.Remove(uniqueList[index]);
        }
    }
}
