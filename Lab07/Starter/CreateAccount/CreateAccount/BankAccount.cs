using System;
using System.Security.AccessControl;

namespace CreateAccount;

class BankAccount
{
    private long? accountNumber;
    private decimal? accountBalance;
    private AccountType accountType;

    public void Populate(long number, decimal balance)
    {
        accountNumber = number;
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


}