using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class BankAccount
    {
        private int id;
        private string name;
        private string surname;
        private long sum;
        private int bonus = 1;
        private string gradation = "Base";

        public int Id => id;
        public string Name => name;
        public string Surname => surname;
        public long Sum
        {
            get => sum;
            set => sum = value;
        }

        public int Bonus
        {
            get => bonus;
            set
            {
                bonus = value;
            }
        }
        public string Gradation { get; set; }

        protected BankAccount(int id, string name, string surname, long sum, int bonus, string gradation)
        {
            this.id = id;
            if (name.Length>0)
            {
                this.name = name;
            }
            if (surname.Length>0)
            {
                this.surname = surname;
            }
            Sum = sum;
            Bonus = bonus;
            Gradation = gradation;
            
        }

        public void AddAccontInfo(int id, string name, string surname, long sum, int bonus)
        {
            this.id = id;
            if (name.Length > 0)
            {
                this.name = name;
            }
            if (surname.Length > 0)
            {
                this.surname = surname;
            }
            Sum = sum;
            Bonus = bonus;
        }

        protected BankAccount(){}

        public void AddSumToAccuunt(long sum)
        {
            if (sum<=0)
            {
                throw new ArgumentException(nameof(sum));
            }
            CountBonus(sum, BonusTypes.Addition);
            Sum += sum;
        }

        public void SubtractSumFromAccount(long sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum));
            }
            if (Sum<sum)
            {
                Console.WriteLine("Not enough sum");
                throw new ArgumentException();
            }
            CountBonus(sum, BonusTypes.Subtraction);
            Sum -= sum;
        }

        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, surname: {Surname}, sum: {Sum}, bonus: {Bonus}, gradation: {Gradation}";
        }

        protected abstract void CountBonus(long accruedSum, BonusTypes type);

    }

    public enum BonusTypes
    {
        Addition = 1,
        Subtraction
    }
}
