using System;
using System.Collections;

/// <summary>
/// пространство имен очередь
/// </summary>
namespace Queue
{
    /// <summary>
    /// Класс , реализующий элемент очереди
    /// </summary>
    /// <typeparam name="T">тип</typeparam>
    public class QueueElement<T>
    {
        /// <summary>
        /// приоритет элемента
        /// </summary>
        /// <value>значение приоритета</value>
        public int Priority { get; set; }

        /// <summary>
        /// Данные элемента
        /// </summary>
        /// <value>данные</value>
        public T Data { get; set; }

        /// <summary>
        /// Конструктор элемента, принимающий данные и приоритет элемента
        /// </summary>
        public QueueElement(T data, int priority)
        {
            Data = data;
            Priority = priority;
        }
    }

    /// <summary>
    /// Класс, реализующий очередь
    /// </summary>
    /// <typeparam name="T">тип элементов очереди</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Массив элементов
        /// </summary>
        private QueueElement<T>[] QueueElements;

        /// <summary>
        /// Конструктор очереди, принимающий данные и приоритет превого элемента
        /// </summary>
        public Queue(T data, int priority)
        {
            QueueElements = new QueueElement<T>[1];
            QueueElements[0] = new QueueElement<T>(data, priority);
        }

        /// <summary>
        /// Метод добавления элемента в очередь
        /// </summary>
        public void Enqueue(T data, int priority)
        {
            Array.Resize(ref QueueElements, QueueElements.Length + 1);
            QueueElements[QueueElements.Length - 1] = new QueueElement<T>(data, priority);
        }

        /// <summary>
        /// Поиск максимального приоритета
        /// </summary>
        /// <returns>максимальный приоритет</returns>
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

        /// <summary>
        /// Поиск индекса первого элемента с максимальным приоритетом
        /// </summary>
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

        /// <summary>
        /// Удаление элемента по заданному индексу и возвращение его данных
        /// </summary>
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

        /// <summary>
        /// Удаление элемента с наивысшим приоритетом, вошедшего раньше всех
        /// </summary>
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

        /// <summary>
        /// Возвращает длинну очереди
        /// </summary>
        public int GetSize() => QueueElements.Length;
    }
}
