using System;
using System.Security.Cryptography.X509Certificates;

namespace CreateAccount;

class CreateAccount
{
    
    static void Main()
    {
        BankAccount berts = NewBankAccount();   // Объект на основе класса BankAccount

        Write(berts);               // Вызов метода вывода  данных акканта

        BankAccount freds = NewBankAccount();   // Объект на основе класса BankAccount

        Write(freds);               // Вызов метода вывода  данных акканта
    }

    static BankAccount NewBankAccount()
    {
        BankAccount created = new BankAccount();

        Console.Write("Enter the account number: ");
        long number = long.Parse(Console.ReadLine());

        Console.Write("Enter the account balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        /*created.accountNumber = number;
        created.accountBallance = balance;
        created.accountType = AccountType.Checking;*/
        created.Populate(number, balance);
        
        return created;
    }
    public static void Write(BankAccount toWrite)
    {
        Console.WriteLine("Account number is {0}", toWrite.Number());
        Console.WriteLine("Account balance is {0}", toWrite.Ballance());
        Console.WriteLine("Account type is {0}", toWrite.Type());
    }
}
