using System;
using System.Collections.Generic;

namespace UniqueList
{
    public class UniqueList
    {
        private List<T> uniqueList;
        private Type type;

        public UniqueList(Type type) { uniqueList = new List<type>(); this.type = type; }

        public void AddData(type data)
        {
            if (uniqueList.Exists(data))
            {
                //execution
                return;
            }

            uniqueList.Add(data);
        }

        public void RemoveData(type data)
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
