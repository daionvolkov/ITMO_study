using System;
using System.Security.Principal;


namespace Constructors;

class CreateAccount
{
    static void Main()
    {
        BankAccount account1, account2, account3, account4;

        account1 = new BankAccount();
        account2 = new BankAccount(AccountType.Deposit);
        account3 = new BankAccount(100);
        account4 = new BankAccount(AccountType.Deposit, 500);
        
        account1.Deposit(100);
        account1.Withdraw(50);
        
        account2.Deposit(300);
        account2.Withdraw(120);

        account3.Deposit(1000);
        account3.Withdraw(200);


        account4.Deposit(10);
        account4.Withdraw(100);

        Write(account1);
        Write(account2);
        Write(account3);
        Write(account4);
    }

    static void Write(BankAccount account)
    {
        Console.WriteLine("Account number is {0}", account.Number());
        Console.WriteLine("Account balance is {0}", account.Balance());
        //Console.WriteLine("Account type is {0}", account.Type());
        //Console.WriteLine("\n");
        Console.WriteLine("Account type is {0}", account.Type());
        Console.WriteLine("Transactions:");
        foreach (BankTransaction tran in account.Transactions())
        {
            Console.WriteLine("Date/Time: {0}\tAmount: {1}", tran.When(), tran.Amount());
        }
        Console.WriteLine();
    }
}
