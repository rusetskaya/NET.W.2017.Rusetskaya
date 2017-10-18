using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssembly
{
    public class NewPerson
    {
        public void NewPersonInfo()
        {
            Person person = new Person("Rita", "Rusetskaya", 20);
            Console.WriteLine(person.AboutPerson());
            Console.ReadLine();
        }
    }
}
