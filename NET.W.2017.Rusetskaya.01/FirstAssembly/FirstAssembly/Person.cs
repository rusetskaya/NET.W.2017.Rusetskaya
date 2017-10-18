using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssembly
{
    public class Person
    {
        public string Name;
        public string Surname;
        public int Age;

        public Person() { }
        public Person(string name, string surname, int age) {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public string AboutPerson()
        {
           return Name + ' ' + Surname + ' ' + Age.ToString();
        }
    }
}
