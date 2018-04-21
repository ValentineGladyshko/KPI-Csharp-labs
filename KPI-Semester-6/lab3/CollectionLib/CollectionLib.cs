using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection.Lib
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

        public class TEventArgs : EventArgs
        {
            public T data;

            public TEventArgs(T data)
            {
                this.data = data;
            }
        };

        public delegate void ClearHandler(object obj, EventArgs args);
        public delegate void DequeueHandler(object obj, TEventArgs args);
        public delegate void EnqueueHandler(object obj, TEventArgs args);

        public event ClearHandler DoClear;
        public event DequeueHandler DoDequeue;
        public event EnqueueHandler DoEnqueue;

        public void OnDoClear()
        {
            EventArgs args = new EventArgs();
            DoClear?.Invoke(this, args);
        }

        public void OnDoDequeue(T data)
        {
            TEventArgs args = new TEventArgs(data);
            DoDequeue?.Invoke(this, args);
        }

        public void OnDoEnqueue(T data)
        {
            TEventArgs args = new TEventArgs(data);
            DoEnqueue?.Invoke(this, args);
        }

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
                throw new InvalidOperationException("Empty collection.");
            }

            T output = head.Data;
            OnDoDequeue(output);
            head = head.Next;
            count--;

            return output;
        }

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = tail;
            tail = node;
            OnDoEnqueue(data);
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
                throw new InvalidOperationException("Empty collection.");
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
            OnDoClear();
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
                throw new ArgumentException("Array is small.");
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

        public object SyncRoot => throw new NotImplementedException("I don't know async programming.");

        public bool IsSynchronized => throw new NotImplementedException("I don't know async programming.");

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
                throw new ArgumentException("Array is small.");
            }

            Node<T> temp = head;
            int i = index;
            while (temp != null)
            {
                array.SetValue(temp.Data, i++);
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
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
