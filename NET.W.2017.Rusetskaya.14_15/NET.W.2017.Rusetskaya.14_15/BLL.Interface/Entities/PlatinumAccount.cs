using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankAccount.BankAccount;

namespace BankAccount
{
    public class PlatinumAccount : BankAccount
    {
        public const string GRADATION = "Platinum";

        public PlatinumAccount()
        {
            this.Gradation = GRADATION;
        }

        public PlatinumAccount(int id, string name, string surname, long sum, int bonus, string gradation) : base(id, name, surname, sum, bonus)
        {
            this.Gradation = GRADATION;
        }

        protected override void CountBonus(long accruedSum, BonusTypes type)
        {
            if (type == BonusTypes.Addition)
            {
                this.Bonus += (int)((Sum + accruedSum) / Sum) + 2;
            }

            if (type == BonusTypes.Subtraction)
            {
                int temp = (int)((Sum + accruedSum) / Sum) + 2;
                if (this.Bonus - temp >= 0)
                {
                    this.Bonus -= temp;
                }
            }
        }
    }
}
