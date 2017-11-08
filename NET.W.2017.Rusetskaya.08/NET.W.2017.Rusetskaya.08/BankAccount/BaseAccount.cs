using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankAccount.BankAccount;

namespace BankAccount
{
    public class BaseAccount : BankAccount
    {
        public const string GRADATION = "Base";
        public BaseAccount(){ }
        public BaseAccount(int id, string name, string surname, long sum, int bonus, string gradation) : base(id, name, surname, sum, bonus, gradation)
        {
            Gradation = GRADATION;
        }

        protected override void CountBonus(long accruedSum, BonusTypes type)
        {
            if (type == BonusTypes.Addition)
            {
                Bonus += (int)((Sum + accruedSum)/Sum);
            }
            if (type == BonusTypes.Subtraction)
            {
                Bonus -= (int)((Sum + accruedSum) / Sum);
            }
        }
    }
}
