using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLib
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> newQueue = new MyQueue<int>();
            newQueue.Enqueue(1);
            newQueue.Enqueue(2);
            newQueue.Enqueue(3);
            newQueue.Enqueue(4);
            newQueue.Enqueue(5);
            newQueue.Enqueue(6);
            newQueue.Enqueue(7);
            Console.WriteLine(newQueue.ToString());
            Console.WriteLine(newQueue.Peek());
            Console.WriteLine(newQueue.ToString());
            Console.WriteLine(newQueue.Dequeue());
            Console.WriteLine(newQueue.ToString());
            int[] newArray = newQueue.ToArray();
            foreach(int elem in newQueue)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
