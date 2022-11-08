
using System.IO;
using System.Collections;
using Banking;

// Test harness
class CreateAccount
{
    static void Main()
    {


        long accNo1 = Bank.CreateAccount(AccountType.Checking, 100);
        long accNo2 = Bank.CreateAccount(AccountType.Checking, 100);


        BankAccount acc1 = Bank.GetAccount(accNo1);
        BankAccount acc2 = Bank.GetAccount(accNo2);

      


        acc2.Deposit(200);
        acc2.Withdraw(35);



        Console.WriteLine("acc1 - {0}", acc1);
        Console.WriteLine("acc2 - {0}", acc2);


        Write(acc1);
        //Write(acc2);
    }

    static void Write(BankAccount acc)
    {
        
        Console.WriteLine("Account number is {0}", acc.Number);
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type().ToString());

        // Print out the transactions (if any)
        Console.WriteLine("Transactions");
        //Queue tranQueue = acc.Transactions();

        foreach (BankTransaction tran in tranQueue)
        {
            Console.WriteLine("Date: {0}\tAmount: {1}", tran.When, tran.Amount);
        }



    }
}
