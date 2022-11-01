using System;


namespace MoreMethods;

internal class BankAccount
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
    public decimal Deposit(decimal amount)      // Метод увеличивает балланс счета и возвращает его
    {
        accountBallance += amount;
        return accountBallance;
    }
    public bool Withdraw(decimal amount)            // Метод проверяет указанную сумму на счету
    {
        bool sufficientFunds = accountBallance >= amount;
        if (sufficientFunds)
        {
            accountBallance -= amount;
        }
        return sufficientFunds;
    }
}
