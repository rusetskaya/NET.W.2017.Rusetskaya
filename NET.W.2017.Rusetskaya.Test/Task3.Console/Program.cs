using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new BankEvent();
            var broker = new Broker(manager);
            var bank = new Bank(manager);
            broker.Register(manager);
            manager.SimulateNewStock(20,23);

            //Thread.Sleep(1000);

            bank.Unregister(manager);

            manager.SimulateNewStock(24,26);
        }
    }
}
