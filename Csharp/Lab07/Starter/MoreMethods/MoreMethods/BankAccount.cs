using System;


namespace MoreMethods;

internal class BankAccount
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
    public decimal? Balance()
    {
        return accountBalance;
    }
    public AccountType Type()
    {
        return accountType;
    }
    public decimal Deposit(decimal amount)      // Метод увеличивает балланс счета и возвращает его
    {
        accountBalance += amount;
        return accountBalance;
    }
    public bool Withdraw(decimal amount)            // Метод проверяет указанную сумму на счету
    {
        bool sufficientFunds = accountBalance >= amount;
        if (sufficientFunds)
        {
            accountBalance -= amount;
        }
        return sufficientFunds;
    }
}
