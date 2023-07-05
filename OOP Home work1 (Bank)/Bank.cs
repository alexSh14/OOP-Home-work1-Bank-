using System;
namespace OOP;


class BankAccount
{
    private string owner;
    private float balance;

    public BankAccount(string owner, float balance)
    {
        this.owner = owner;
        this.balance = balance;
    }

    public float GetBalance()
    {
        return balance;
    }

    public string GetOwner()
    {
        return owner;
    }

    public void Transfer(BankAccount toAccount, float amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            toAccount.balance += amount;
        }
    }
}

class BankTransaction
{
    private BankAccount sender;
    private BankAccount recipient;
    private float amount;

    public BankTransaction(BankAccount sender, BankAccount recipient, float amount)
    {
        this.sender = sender;
        this.recipient = recipient;
        this.amount = amount;
    }

    public void Execute()
    {
        sender.Transfer(recipient, amount);
    }
}

class Bank
{
    private List<BankAccount> accounts;

    public Bank()
    {
        accounts = new List<BankAccount>();
    }

    public BankAccount AddAccount(string owner, float balance)
    {
        BankAccount account = new BankAccount(owner, balance);
        accounts.Add(account);
        return account;
    }

    public float GetAccountBalance(string owner)
    {
        foreach (BankAccount account in accounts)
        {
            if (account.GetOwner() == owner)
            {
                return account.GetBalance();
            }
        }
        return -1;  // Account not found
    }

    public List<BankAccount> GetAllAccounts()
    {
        return accounts;
    }

    public void TransferFunds(string fromOwner, string toOwner, float amount)
    {
        BankAccount fromAccount = null;
        BankAccount toAccount = null;

        foreach (BankAccount account in accounts)
        {
            if (account.GetOwner() == fromOwner)
            {
                fromAccount = account;
            }
            else if (account.GetOwner() == toOwner)
            {
                toAccount = account;
            }
        }

        if (fromAccount != null && toAccount != null)
        {
            BankTransaction transaction = new BankTransaction(fromAccount, toAccount, amount);
            transaction.Execute();
        }
    }
} 