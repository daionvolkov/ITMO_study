using System;
using System.Security.AccessControl;


namespace UniqueNumbers;

class BankAccount
{
    private long accountNumber;
    private decimal accountBallance;
    private AccountType accountType;
    private static long nextAccountNumber = 123;

    private static long NextNumber()             //Метод добавление номера аккаунта
    {
        return nextAccountNumber++;
    }

    public void Populate(decimal ballance)
    {
        accountNumber = NextNumber();
        accountBallance = ballance;
        accountType = AccountType.Checking;
    }
    public long? Number()
    {
        return accountNumber;
    }
    public decimal? Ballance()
    {
        return accountBallance;
    }
    public AccountType Type()
    {
        return accountType;
    }
}


