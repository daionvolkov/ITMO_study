using System;
using System.Security.AccessControl;

namespace CreateAccount;

class BankAccount
{
    private long? accountNumber;
    private decimal? accountBallance;
    private AccountType accountType;

    public void Populate(long number, decimal ballance)
    {
        accountNumber = number;
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