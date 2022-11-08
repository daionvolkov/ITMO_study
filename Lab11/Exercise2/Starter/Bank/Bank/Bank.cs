using System;
using System.Collections;


namespace Banking
{ 

public class Bank
{
    static public long CreateAccount()
    {
        BankAccount newAcc = new BankAccount();
        long accNo = newAcc.Number();
        accounts[accNo] = newAcc;
        return accNo;
    }
    static public bool CloseAccount(long accNo)
    {
        BankAccount closing = (BankAccount)accounts[accNo];
        if (closing != null)
        {
            accounts.Remove(accNo);
            closing.Dispose();
            return true;
        }
        else
        {
            return false;
        }
    }

    private static Hashtable accounts = new Hashtable();

    static public BankAccount GetAccount(long accNo)
    {
        return (BankAccount)accounts[accNo];
    }
}
}