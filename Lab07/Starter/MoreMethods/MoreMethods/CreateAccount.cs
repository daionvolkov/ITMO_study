using MoreMethods;
using System;

using System;

namespace MoreMethods;

class CreateAccount
{
    static void Main()
    {
        BankAccount berts = NewBankAccount();   // Объект на основе класса BankAccount
        Write(berts);                            // Вызов метода вывода  данных акканта
        TestDeposit(berts);                     // Вызов метода увеличения балланса
        Write(berts);
        TestWithdraw(berts);                    //Вызов метода проверки балланса
        Write(berts);

        BankAccount freds = NewBankAccount();   // Объект на основе класса BankAccount
        Write(freds);               // Вызов метода вывода  данных акканта
        TestDeposit(freds);
        Write(freds);
        TestWithdraw(freds);
        Write(freds);

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
    public static void TestDeposit(BankAccount account)             //Метод запроса суммы
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        account.Deposit(amount);
    }
    public static void TestWithdraw(BankAccount account)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (!account.Withdraw(amount))
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}
