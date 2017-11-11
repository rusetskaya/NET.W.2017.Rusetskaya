using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankAccount.BankAccount;
using static BankAccount.BaseAccount;
using static BankAccount.GoldAccount;
using static BankAccount.PlatinumAccount;

namespace BankAccount
{
    public class AccountManager
    {
        public BankAccount CreateBankAccount(string accountType)
        {
            BankAccount bankAccount = null;
            if (accountType.Equals(BaseAccount.GRADATION))
            {
                bankAccount = new BaseAccount();
            }

            if (accountType.Equals(GoldAccount.GRADATION))
            {
                bankAccount = new GoldAccount();
            }

            if (accountType.Equals(PlatinumAccount.GRADATION))
            {
                bankAccount = new PlatinumAccount();
            }

            return bankAccount;
        }

        public void CloseBankAccount(BankAccount bankAccount)
        {
            bankAccount = null;
        }
    }

    ////enum AccountType
    ////{
    ////    Base,
    ////    Gold,
    ////    Platinum
    ////}
}
