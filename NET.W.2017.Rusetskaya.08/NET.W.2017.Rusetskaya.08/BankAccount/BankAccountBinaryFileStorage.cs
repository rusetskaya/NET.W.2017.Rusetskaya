using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankAccount.AccountManager;

namespace BankAccount
{
    public class BankAccountBinaryFileStorage : IBankAccountStorage
    {
        const string FILENAME = "BankAccount.dat";

        public IEnumerable<BankAccount> ReadFromStorage()
        {
            List<BankAccount> bankAccountsList = new List<BankAccount>();
            int id;
            string name;
            string surname;
            long sum;
            int bonus;
            string gradation = "Base";

            using (BinaryReader reader = new BinaryReader(File.Open(FILENAME, FileMode.Open)))
            {
                while (reader.PeekChar() > -1) 
                {
                    id = reader.ReadInt32();
                    name = reader.ReadString();
                    surname = reader.ReadString();
                    sum = reader.ReadInt64();
                    bonus = reader.ReadInt32();
                    gradation = reader.ReadString();

                    bankAccountsList.Add(new AccountManager().CreateBankAccount(gradation));
                    bankAccountsList[bankAccountsList.Count].AddAccontInfo(id, name, surname, sum, bonus);
                }
            }

            return bankAccountsList;
        }

        public void WriteToStorage(IEnumerable<BankAccount> bankAccountsList)
        {
            if (ReferenceEquals(bankAccountsList, null))
            {
                throw new ArgumentNullException(nameof(bankAccountsList));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FILENAME, FileMode.OpenOrCreate)))
            {
                foreach (BankAccount bankAccount in bankAccountsList)
                {
                    writer.Write(bankAccount.Id);
                    writer.Write(bankAccount.Name);
                    writer.Write(bankAccount.Surname);
                    writer.Write(bankAccount.Sum);
                    writer.Write(bankAccount.Bonus);
                    writer.Write(bankAccount.Gradation);
                }
            }
        }
    }
}
