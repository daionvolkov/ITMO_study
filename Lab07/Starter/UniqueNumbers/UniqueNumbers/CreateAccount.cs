using System;

namespace UniqueNumbers;

class CreateAccount
{
    static void Main()
    {
        BankAccount berts = NewBankAccount();   // Объект на основе класса BankAccount

        Write(berts);               // Вызов метода вывода  данных акканта

        BankAccount freds = NewBankAccount();   // Объект на основе класса BankAccount

        Write(freds);               // Вызов метода вывода  данных акканта

    }
    //long number = BankAccount.NextNumber();

    static BankAccount NewBankAccount()
    {
        BankAccount created = new BankAccount();

        Console.Write("Enter the account ballance: ");
        decimal ballance = decimal.Parse(Console.ReadLine());

        created.Populate(ballance);

        return created;
    }
    public static void Write(BankAccount toWrite)
    {
        Console.WriteLine("Account number is {0}", toWrite.Number());
        Console.WriteLine("Account balance is {0}", toWrite.Ballance());
        Console.WriteLine("Account type is {0}", toWrite.Type());
    }
}