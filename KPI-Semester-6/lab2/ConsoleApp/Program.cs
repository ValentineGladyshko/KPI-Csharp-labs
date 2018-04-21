using System;
using Collection.Lib;

namespace Collection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MyQueue<int> newQueue = new MyQueue<int>();

            newQueue.DoClear += (obj, arg) => Console.WriteLine("Queue cleared.");
            newQueue.DoDequeue += (obj, arg) => Console.WriteLine("Dequeue elem : {0}", arg.data);
            newQueue.DoEnqueue += (obj, arg) => Console.WriteLine("Enqueue elem : {0}", arg.data);

            newQueue.Enqueue(1);
            newQueue.Enqueue(2);
            newQueue.Enqueue(3);
            newQueue.Enqueue(4);

            Console.WriteLine(newQueue.Contains(2));
            Console.WriteLine(newQueue.Contains(10));

            Console.WriteLine(newQueue.ToString());

            newQueue.Dequeue();
            Console.WriteLine(newQueue.ToString());

            int[] newArray = newQueue.ToArray();

            Console.WriteLine("\nQueue:");
            foreach (int elem in newQueue)
            {
                Console.Write(elem + " ");
            }

            Console.WriteLine();
            Console.WriteLine("\nArray:");
            foreach (int elem in newArray)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();

            try
            {
                newQueue.CopyTo(null, 0);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            try
            {
                int[] newArray1 = new int[1];
                newQueue.CopyTo(newArray1, -1);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            try
            {
                int[] newArray1 = new int[1];
                newQueue.CopyTo(newArray1, 0);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            newQueue.Clear();

            try
            {
                newQueue.Dequeue();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
