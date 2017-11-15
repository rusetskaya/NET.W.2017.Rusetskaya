using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeEventLibrary;

namespace TimeEventRunner
{
    class Runner
    {
        static void Main(string[] args)
        {
            int time;
            Console.WriteLine("Enter time value, please");
            time = Convert.ToInt32(Console.ReadLine());

            var firstSubscriber = new FirstSubscriber();
            var secondSubscriber = new SecondSubscriber();
            var manager = new MessageManager();

            firstSubscriber.Register(manager);
            manager.SimulateNewMessage(time, "1-st event");

            secondSubscriber.Register(manager);
            manager.SimulateNewMessage(time, "2-nd event");

            firstSubscriber.Unregister(manager);

            var secManager = new MessageManager();
            firstSubscriber.Register(secManager);

            manager.SimulateNewMessage(time, "3-rd event");
            secManager.SimulateNewMessage(time,"4-th event");

            Console.ReadLine();
        }
    }
}
