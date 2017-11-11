using System.Collections.Generic;

namespace BankAccount
{
    public interface IBankAccountStorage
    {
        IEnumerable<BankAccount> ReadFromStorage();

        void WriteToStorage(IEnumerable<BankAccount> bookList);
    }
}