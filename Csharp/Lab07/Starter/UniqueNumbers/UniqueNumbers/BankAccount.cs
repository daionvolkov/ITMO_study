using System;
using System.Security.AccessControl;


namespace UniqueNumbers;

class BankAccount
{
    private long accountNumber;
    private decimal accountBalance;
    private AccountType accountType;
    private static long nextAccountNumber = 123;

    private static long NextNumber()             //Метод добавление номера аккаунта
    {
        return nextAccountNumber++;
    }

    public void Populate(decimal balance)
    {
        accountNumber = NextNumber();
        accountBalance = balance;
        accountType = AccountType.Checking;
    }
    public long? Number()
    {
        return accountNumber;
    }
    public decimal? Ballance()
    {
        return accountBalance;
    }
    public AccountType Type()
    {
        return accountType;
    }
}


