using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private string name;
        private string surname;
        private int sum;
        private int bonus;
        private string gradation = "Base";

        public int IDictionary => id;
        public string Name => name;
        public string Surname => surname;
        public int Sum
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

        public BankAccount(int id, string name, string surname, int sum, int bonus, string gradation)
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
            if (Sum<sum)
            {
                Sum = sum;
                Bonus = CountBonus(bonus, sum);
                Gradation = gradation;
            }
            
        }

        private int CountBonus(int bonus, int sum) { }
    }
}
