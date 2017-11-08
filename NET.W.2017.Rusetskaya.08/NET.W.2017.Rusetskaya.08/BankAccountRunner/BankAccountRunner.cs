using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount;
using static BankAccount.BankAccount;
using static BankAccount.AccountManager;
using static BankAccount.BankAccountBinaryFileStorage;


namespace BankAccountRunner
{
    class BankAccountRunner
    {
        static void Main(string[] args)
        {
            BankAccountBinaryFileStorage storage = new BankAccountBinaryFileStorage();
            var manager = new AccountManager();
            var accounts = new List<BankAccount.BankAccount>();

            accounts.Add(manager.CreateBankAccount("Gold"));
            accounts[0].AddAccontInfo(0, "Rita", "Rusetskaya", 2034000, 1);
            accounts[0].AddSumToAccuunt(15);

            Console.WriteLine(accounts[0]);

            accounts.Add(manager.CreateBankAccount("Platinum"));
            accounts[1].AddAccontInfo(1, "User2", "Surname2", 20340, 2);
            accounts[1].SubtractSumFromAccount(40);

            Console.WriteLine(accounts[1]);

            storage.WriteToStorage(accounts);

            IEnumerable<BankAccount.BankAccount> bankAccountsList = storage.ReadFromStorage();
            for (int i = 0; i < bankAccountsList.Count(); i++)
            {
                Console.WriteLine(bankAccountsList.ElementAt(i));
            }

            Console.ReadKey();
        }
    }
}
