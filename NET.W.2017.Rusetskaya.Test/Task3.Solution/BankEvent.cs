using System;
using System.Collections.Generic;

namespace Task3.Solution
{
    public class BankEvent //Manager
    {
        public event EventHandler<BankEventArgs> NewStock = delegate { };

        public void OnNewStock(BankEventArgs e)
        {
            EventHandler<BankEventArgs> temp = NewStock;
            
            temp?.Invoke(this, e);
        }

        public void SimulateNewStock(int usd, int euro)
        {
            OnNewStock(new BankEventArgs(usd, euro));
        }
    }

    public sealed class BankEventArgs : EventArgs
    {
        private int usd;
        private int euro;

        public BankEventArgs(int usd, int euro)
        {
            Euro = euro;
            USD = usd;
        }

        public int USD { get; set; }
        public int Euro { get; set; }

    }

    //Listeners
    public sealed class Broker
    {
        public string Name { get; set; }

        public Broker(BankEvent be)
        {
            be.NewStock += UpdateBroker;
        }

        public void Register(BankEvent be)
        {
            be.NewStock += UpdateBroker;
        }

        public void UpdateBroker(object sender, BankEventArgs eventArgs)
        {        
            Console.WriteLine($"{eventArgs.Euro} {eventArgs.USD}");
        }

        public void Unregister(BankEvent be)
        {
            be.NewStock -= UpdateBroker;
        }
    }

    public class Bank
    {
        public string Name { get; set; }

        public Bank(BankEvent be)
        {
            be.NewStock += UpdateBank;
        }

        public void Register(BankEvent be)
        {
            be.NewStock += UpdateBank;
        }

        public void UpdateBank(object sender, BankEventArgs eventArgs)
        {
            Console.WriteLine($"{eventArgs.Euro} {eventArgs.USD}");
        }

        public void Unregister(BankEvent be)
        {
            be.NewStock -= UpdateBank;
        }
    }
}