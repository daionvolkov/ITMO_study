using System;
using System.Collections;
using System.Security.AccessControl;

namespace Finalizers;
sealed class BankAccount : IDisposable
{
    private long accountNumber;
    private decimal accountBalance;
    private AccountType accountType;
    private Queue tranQueue = new Queue();
    private static long nextNumber = 123;
    private bool disposed = false;

    public void Populate(decimal balance)
    {
        accountNumber = NextNumber();
        accountBalance = balance;
        accountType = AccountType.Checking;
    }

    public bool Withdraw(decimal amount)
    {
        bool sufficientFunds = accountBalance >= amount;
        if (sufficientFunds)
        {
            accountBalance -= amount;
            BankTransaction tran = new BankTransaction(-amount);
            tranQueue.Enqueue(tran);
        }
        return sufficientFunds;
    }

    public decimal Deposit(decimal amount)
    {
        accountBalance += amount;
        BankTransaction tran = new BankTransaction(amount);
        tranQueue.Enqueue(tran);
        return accountBalance;
    }

    public long Number()
    {
        return accountNumber;
    }

    public decimal Balance()
    {
        return accountBalance;
    }

    public string Type()
    {
        return accountType.ToString();
    }

    private static long NextNumber()
    {
        return nextNumber++;
    }
    public void Dispose()
    {
        if (disposed == false)
        {
            StreamWriter swFile = File.AppendText("Transactions.Dat");
            swFile.WriteLine("Account number is {0}", accountNumber);
            swFile.WriteLine("Account balance is {0}", accountBalance);
            swFile.WriteLine("Account type is {0}", accountType);
            swFile.WriteLine("Transactions:");
            foreach (BankTransaction tran in tranQueue)
            {
                swFile.WriteLine("Date/Time: {0}\tAmount:{1}", tran.When(), tran.Amount());
            }
            swFile.Close();
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }


    //Конструкторы
    public BankAccount() { }
    public BankAccount(AccountType aType)
    {
        accountNumber = NextNumber();
        accountType = aType;
        accountBalance = 0;
    }

    public BankAccount(decimal aBal)
    {
        accountNumber = NextNumber();
        accountType = AccountType.Checking;
        accountBalance = aBal;
    }

    public BankAccount(AccountType aType, decimal aBal)
    {
        accountNumber = NextNumber();
        accountType = aType;
        accountBalance = aBal;
    }
    public Queue Transactions()
    {
        return tranQueue;
    }

    ~BankAccount()
    {
        Dispose();
    }
}
