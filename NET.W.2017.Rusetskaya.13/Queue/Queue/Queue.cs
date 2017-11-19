using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 Очередь
 Разработать обобщенный класс-коллекцию Queue, 
 реализующий основные операции для работы с очередью, 
 и предоставляющий возможность итерирования, 
 реализовав итератор «вручную» 
 (без использования блок-итератора yield). 
 Протестировать методы разработанного класса.
*/

namespace Queue
{
    public class Queue<T> : IEnumerable<T>//, ICloneable
    {
        private const int CAPACITY = 32;
        internal T[] array;
        private int head;
        private int tail;
        private int size;
        private int capacity = CAPACITY;
        ////private int version;

        public Queue()
        {
            array = new T[capacity];
        }

        public Queue(int newCapacity)
        {
            if (newCapacity < 0)
            {
                throw new ArgumentException(nameof(newCapacity));
            }

            this.array = new T[newCapacity];
            this.Head = 0;
            this.Tail = 0;
            this.size = 0;
            capacity = newCapacity;
        }

        public Queue(IEnumerable<T> collection) 
            : this(ReferenceEquals(collection, null) ? CAPACITY : collection.Count())
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            array = new T[collection.Count()];
            foreach (T variable in collection)
            {
                Push(variable);
            }
        }

        public int Head
        {
            get => head;
            set => head = value;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public int Tail
        {
            get => tail;
            set => tail = value;
        }

        public int Count
        {
            get => size;
            set => size = value;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Push(T element)
        {
            if (default(T) == null)
            {
                if (ReferenceEquals(element, null))
                {
                    throw new ArgumentNullException(nameof(element));
                }
            }

            if (Count == capacity)
            {
                ToExpand();
            }

            array[Tail] = element;
            Tail = (Tail + 1) % capacity;
            Count++;
        }

        /// <summary>
        /// Removes the object at the head of the queue and returns it. 
        /// If the queue is empty, this method simply returns null.
        /// </summary>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"Queue {nameof(array)} is already empty");
            }

            T removed = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            Count--;
            return removed;
        }

        /// <summary>
        /// Returns the object at the head of the queue. The object remains in the
        /// queue. If the queue is empty, this method throws an 
        /// InvalidOperationException.
        /// </summary>
        /// <returns></returns>
        public virtual T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            return array[head];
        }

        /// <summary>
        /// Returns true if the queue contains at least one object equal to element.
        /// Equality is determined using element.Equals().
        ///
        /// Exceptions: ArgumentNullException if element == null.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual bool Contains(T element)
        {
            /*
            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }
            */

            if (IsEmpty())
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            int index = head;
            int count = Count;

            while (Count-- > 0)
            {
                if (element == null)
                {
                    if (array[index] == null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (array[index] != null && array[index].Equals(element))
                    {
                        return true;
                    }
                }

                index = (index + 1) % array.Length;
            }

            return false;
        }

        public int GetSize()
        {
            return 1;
        }

        public void Clear()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            Count = 0;
            Head = 0;
            Tail = 0;
            array = new T[CAPACITY];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal T GetElement(int i)
        {
            return array[(head + i) % array.Length];
        }

        private void ToExpand()
        {
            Capacity = Capacity * 2;
            T[] newArray = new T[Capacity];
            if (Count > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, Count);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            head = 0;
            tail = Count;
        }
    }

    public class QueueIterator<T> : IEnumerator<T>
    {
        private Queue<T> queue;
        private int index;
        private T currentElement;

        internal QueueIterator(Queue<T> queue)
        {
            this.queue = queue;
            this.index = queue.Head - 1;
        }

        public T Current
        {
            get
            {
                if (index < 0 || index >= queue.Capacity)
                {
                    throw new ArgumentException(nameof(index));
                }

                currentElement = queue.array[index];
                return currentElement;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (queue.Head < queue.Tail)
            {
                index++;
                currentElement = queue.array[index];
                ////return index < queue.Count + queue.Head;
                return index < queue.Count;
            }
            else
            {
                index = (index + 1) % queue.Capacity;
                return index != queue.Tail;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }
    }
}
