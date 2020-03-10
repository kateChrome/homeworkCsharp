using System;
using System.Collections.Generic;

namespace UniqueList
{
    public class UniqueList<T>
    {
        private List<T> uniqueList;

        public UniqueList() { uniqueList = new List<T>(); }

        public void AddData(T data)
        {
            if (uniqueList.Exists(data))
            {
                //execution
                return;
            }

            uniqueList.Add(data);
        }

        public void RemoveData(T data)
        {
            if (!uniqueList.Exists(data))
            {
                //execution
                return;
            }

            uniqueList.Remove(data);
        }
    }
}
