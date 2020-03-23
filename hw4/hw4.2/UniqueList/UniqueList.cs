using System;
using System.Collections.Generic;

namespace UniqueList
{
    /// <summary>
    /// Class with implementation unique list structure.
    /// </summary>
    /// <typeparam name="T">type of items.</typeparam>
    public class UniqueList<T> : List<T>
    {
        /// <summary>
        /// Add data to tail of the unique list.
        /// </summary>
        public new void Add(T data)
        {
            if (this.Contains(data))
            {
                throw new ElementAlreadyExistException($"{data} already exist in the unique list");
            }

            base.Add(data);
        }

        /// <summary>
        /// Remove data from the unique list.
        /// </summary>
        public new void Remove(T data)
        {
            if (!this.Contains(data))
            {
                throw new ElementDoesNotExistException($"{data} does not exist in the unique list");
            }

            base.Remove(data);
        }

        /// <summary>
        /// Сheck the the unique list for emptiness 
        /// </summary>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// add data by index in the unique list.
        /// </summary>
        public new void Insert(int index, T data)
        {
            if (this.Contains(data))
            {
                throw new ElementAlreadyExistException($"{data} already exist in the unique list");
            }

            base.Insert(index, data);
        }

        /// <summary>
        /// Remove data by index from the unique list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDataByIndex(int index)
        {
            this.Remove(this[index]);
        }

        /// <summary>
        /// Method hiding
        /// </summary>
        public new void AddRange(IEnumerable<T> collection){ }

        /// <summary>
        /// Method hiding
        /// </summary>
        public new void InsertRange(int index, IEnumerable<T> collection) { }
    }
}
