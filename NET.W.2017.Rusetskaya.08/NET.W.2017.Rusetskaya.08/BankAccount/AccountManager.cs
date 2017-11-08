using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankAccount.BaseAccount;
using static BankAccount.GoldAccount;
using static BankAccount.PlatinumAccount;
using static BankAccount.BankAccount;

namespace BankAccount
{
    public class AccountManager
    {
        public BankAccount CreateAccount(string accountType)
        {
            BankAccount bankAccount;
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
            return null;
        }
        public void CloseAccount(BankAccount bankAccount)
        {
            bankAccount = null;
        }
    }

    //enum AccountType
    //{
    //    Base,
    //    Gold,
    //    Platinum
    //}
}
