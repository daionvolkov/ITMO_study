
using System;
using System.Collections;
using Banking;

class CreateAccount
{
    static void Main()
    {

        long accNo1 = Bank.CreateAccount(AccountType.Checking, 100);
        long accNo2 = Bank.CreateAccount(AccountType.Deposit, 100);


        BankAccount acc1 = Bank.GetAccount(accNo1);
        BankAccount acc2 = Bank.GetAccount(accNo2);
        acc1.Holder = "John Smith";
        acc2.Holder = "Bob Marly";


        Console.WriteLine("acc1 - {0}", acc1);
        Console.WriteLine("acc2 - {0}", acc2);


        for (int i = 0; i < 5; i++)
        {
            acc1.Deposit(50);
            acc1.Withdraw(25);
        }
        Write(acc1);
        
        for (int i = 0; i < 5; i++)
        {
            acc2.Deposit(60);
            acc2.Withdraw(5);
        }
        Write(acc2);
    }
       
    

    static void Write(BankAccount acc)
    {   

        Console.WriteLine("Account number is {0}", acc.Number);
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type);

        Console.WriteLine("Transactions");
        Queue tranQueue = acc.Transactions();

        
        /*foreach (BankTransaction tran in tranQueue)
        {
            Console.WriteLine("Date: {0}\tAmount: {1}", tran.When, tran.Amount);
        }*/

        for (int counter = 0; counter < tranQueue.Count; counter++)
        {
            BankTransaction tran = acc[counter];
            Console.WriteLine("Date: {0}\tAmount: {1}", tran.When, tran.Amount);
        }

    }

}
