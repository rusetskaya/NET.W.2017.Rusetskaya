using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Queue.Queue<int>;

namespace QueueConsole
{
    class Runner
    {
        static void Main(string[] args)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>(4);
            queue.Push(1);
            queue.Push(3);
            queue.Push(4);
            foreach (var element in queue)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();

            //queue.Pop();
            foreach (var element in queue)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();

            Console.WriteLine(queue.Capacity);
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Contains(2));
            Console.WriteLine(queue.Contains(4));
            Console.WriteLine(queue.Peek());
            Console.ReadLine();
        }
    }
}
