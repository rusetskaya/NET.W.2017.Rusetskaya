using FirstAssembly;
using System;
class Client
{
    static void Main()
    {
        NewPerson obj = new NewPerson();
        obj.NewPersonInfo();

        // Здесь будет загружаться модуль Person.netmodule
        Person obj1 = new Person();
        obj1.AboutPerson();
        Console.ReadLine();
    }

}
