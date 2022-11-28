using System;
using System.Security.Cryptography.X509Certificates;

namespace BankAccount;

class Enum
{
    public enum AccountType { Checking, Deposit };
    static void Main(string[] args)
    {
        AccountType goldAccount = AccountType.Checking;
        AccountType platinumAccount = AccountType.Deposit;

        Console.WriteLine("The customer account type is {0} " , goldAccount);
        Console.WriteLine("The customer account type is {0} ", platinumAccount);
    }
}
