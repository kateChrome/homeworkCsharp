using System;
using System.Collections;

namespace Queue
{
    public class QueueElement<T>
    {
        public int Priority { get; set; }
        public T Data { get; set; }

        public QueueElement(T data, int priority)
        {
            Data = data;
            Priority = priority;
        }
    }

    public class Queue<T>
    {
        private QueueElement<T>[] QueueElements;

        public Queue(T data, int priority)
        {
            QueueElements = new QueueElement<T>[1];
            QueueElements[0] = new QueueElement<T>(data, priority);
        }

        public void Enqueue(T data, int priority)
        {
            Array.Resize(ref QueueElements, QueueElements.Length + 1);
            QueueElements[QueueElements.Length - 1] = new QueueElement<T>(data, priority);
        }

        private int FindMaximumPriority()
        {
            int maximumPriority = QueueElements[0].Priority;

            foreach (var item in QueueElements)
            {
                if (item.Priority > maximumPriority)
                {
                    maximumPriority = item.Priority;
                }
            }

            return maximumPriority;
        }

        private int GetIndexOfTheFirstElementWithMaximumPriority(int maximumPriority)
        {
            int index = 0;
            for (int i = 0; i < QueueElements.Length; i++)
            {
                if (QueueElements[i].Priority == maximumPriority)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private T GetDataOfElementAndRemoveThem(int index)
        {
            T data = QueueElements[index].Data;

            for (int i = index; i < QueueElements.Length - 1; i++)
            {
                QueueElements[i] = QueueElements[i + 1];
            }
            Array.Resize(ref QueueElements, QueueElements.Length - 1);

            return data;
        }

        public T Dequeue()
        {
            if (QueueElements.Length == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            int maximumPriority = FindMaximumPriority();
            int indexOfTheFirstElementWithMaximumPriority = GetIndexOfTheFirstElementWithMaximumPriority(maximumPriority);
            T data = GetDataOfElementAndRemoveThem(indexOfTheFirstElementWithMaximumPriority);
            return data;
        }
    }
}
