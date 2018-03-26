using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionLib
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class MyQueue<T> : IEnumerable<T>, ICollection
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public MyQueue()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            T output = head.Data;
            head = head.Next;
            count--;

            return output;
        }

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = tail;
            tail = node;

            if (count == 0)
            {
                head = tail;
            }
            else
            {
                temp.Next = tail;
            }

            count++;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            T output = head.Data;
            return output;
        }

        public T[] ToArray()
        {
            T[] output = new T[count];

            Node<T> temp = head;
            int i = 0;
            while (temp != null)
            {
                output[i++] = temp.Data;
                temp = temp.Next;
            }
            return output;
        }

        public void TrimExcess() { }

        public bool Contains(T data)
        {
            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                    return true;
                temp = temp.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((array.Length - arrayIndex) < count)
            {
                throw new ArgumentException();
            }

            Node<T> temp = head;
            int i = arrayIndex;
            while (temp != null)
            {
                array[i++] = temp.Data;
                temp = temp.Next;
            }
        }

        public int Count { get { return count; } }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((array.Length - index) < count)
            {
                throw new ArgumentException();
            }

            Node<T> temp = head;
            int i = index;
            while (temp != null)
            {
                array.SetValue(temp.Data, i++);
                temp = temp.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> temp = head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> temp = head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "\nQueue:\n\tCount: " + count.ToString() + "\n\tData: ";

            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.Next != null)
                    output += temp.Data.ToString() + " ";
                else
                    output += temp.Data.ToString();
                temp = temp.Next;
            }
            return output.ToString();
        }
    }
}
