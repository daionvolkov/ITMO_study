
using System;
using System.Collections;
using Banking;

// Test harness
class CreateAccount
{
    static void Main()
    {

        Bank.CreateAccount(AccountType.Checking, 100);
        long accNo1 = Bank.CreateAccount(AccountType.Checking, 200);
        long accNo2 = Bank.CreateAccount(AccountType.Checking, 200);

        BankAccount acc1 = Bank.GetAccount(accNo1);
        BankAccount acc2 = Bank.GetAccount(accNo2);
        BankAccount acc3 = Bank.GetAccount(accNo1);
        acc1.Deposit(100);

        if (acc1.Equals(acc2))
        {
            Console.WriteLine("Both accounts are the same. They should not be!");
            Console.WriteLine("acc1 – {0}", acc1.Deposit);
            Console.WriteLine("acc1 – {0}", acc1);
            //Console.WriteLine("acc2 – {0}", acc2);
            //Console.WriteLine("acc3 – {0}", acc3);
        }
        else
        {
            Console.WriteLine("The accounts are different. Good!");
            //Console.WriteLine("acc1 – {0}", acc1);
            //Console.WriteLine("acc2 – {0}", acc2);
            //Console.WriteLine("acc3 – {0}", acc3);

        }

        if (!acc1.Equals(acc2))
        {
            Console.WriteLine("The accounts are different. Good!");
            //Console.WriteLine("acc1 – {0}", acc1);
            //Console.WriteLine("acc2 – {0}", acc2);
            //Console.WriteLine("acc3 – {0}", acc3);
        }
        else
        {
            Console.WriteLine("Both accounts are the same. They should not be!");
            Console.WriteLine("acc1 – {0}", acc1);
            Console.WriteLine("acc2 – {0}", acc2);
            Console.WriteLine("acc3 – {0}", acc3);
        }

        
        if (acc1.Equals(acc3))
        {
            Console.WriteLine("The accounts are the same. Good!");
            Console.WriteLine("acc1 – {0}", acc1);
            Console.WriteLine("acc2 – {0}", acc2);
            Console.WriteLine("acc3 – {0}", acc3);
        }
        else
        {
            Console.WriteLine("The accounts are different. They should not be!");
            Console.WriteLine("acc1 – {0}", acc1);
            Console.WriteLine("acc2 – {0}", acc2);
            Console.WriteLine("acc3 – {0}", acc3);
        }

        if (!acc1.Equals(acc3))
        {
            Console.WriteLine("The accounts are different. They should not be!");
            Console.WriteLine("acc1 – {0}", acc1);
            Console.WriteLine("acc2 – {0}", acc2);
            Console.WriteLine("acc3 – {0}", acc3);
        }
        else
        {
            Console.WriteLine("The accounts are the same. Good!");
            Console.WriteLine("acc1 – {0}", acc1.ToString());
            Console.WriteLine("acc2 – {0}", acc2);
            Console.WriteLine("acc3 – {0}", acc3);
        }

    }

    static void Write(BankAccount acc)
    {
        Console.WriteLine("Account number is {0}", acc.Number());
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type());

        // Print out the transactions (if any)
        Console.WriteLine("Transactions");
        Queue tranQueue = acc.Transactions();
        foreach (BankTransaction tran in tranQueue)
        {
            Console.WriteLine("Date: {0}\tAmount: {1}", tran.When(), tran.Amount());
        }
    }
}
