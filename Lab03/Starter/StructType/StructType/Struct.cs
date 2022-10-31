using System;
using System.Reflection.Metadata.Ecma335;

namespace StructType;

class Struct
{
    public enum AccountType { Checking, Deposit };
    public struct BankAccount
    {
        public long accountNumber;
        public decimal accountBallance;
        public AccountType accountType;
    }

    static void Main(string[] args)
    {
        BankAccount BankAccount, goldAccount;

        // Присвоение значений полям.
        goldAccount.accountType = AccountType.Checking;
        goldAccount.accountBallance = (decimal)3200.00;

        try
        {
            Console.WriteLine("Enter your Acoount Number: ");
            string? userInput = Console.ReadLine();
            goldAccount.accountNumber = long.Parse(userInput);
            Console.WriteLine("** Account Summaty **\n Account Number {0} \n Account Type {1} \n Account Ballance {2} $",
            goldAccount.accountNumber, goldAccount.accountType, goldAccount.accountBallance);
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong enter");
        }



    }
}