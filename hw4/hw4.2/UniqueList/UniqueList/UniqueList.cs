using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Unique List class implementation.
    /// </summary>
    public class UniqueList<T> : List<T>
    {
        /// <summary>
        /// Adds the unique item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="Task2.ElementAlreadyExistException">Element {item} already exist.</exception>
        public new void Add(T item)
        {
            if (Exists(item))
            {
                throw new ElementAlreadyExistException($"Element {item} already exist.");
            }
            else
            {
                base.Add(item);
            }
        }

        /// <summary>
        /// Inserts item by index. The item will must be unique.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="Task2.ElementAlreadyExistException">Element {item} already exist.</exception>
        public new void Insert(int index, T item)
        {
            if (Exists(item))
            {
                throw new ElementAlreadyExistException($"Element {item} already exist.");
            }
            else
            {
                base.Insert(index, item);
            }
        }
    }
}