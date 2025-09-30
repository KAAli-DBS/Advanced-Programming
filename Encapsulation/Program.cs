// Example of OOP-Encapsulation

using System;

public class BankAccount
{
    // Private field: stores the balance (cannot be accessed directly)
    private double balance;

    // Encapsulated property: allows read access but protects write access
    public double Balance
    {
        get { return balance; }      // anyone can read the balance
        private set { balance = value; } // only the class can modify it
    }

    // Constructor to initialize balance
    public BankAccount(double initialBalance)
    {
        if (initialBalance >= 0)
            balance = initialBalance;
        else
            balance = 0;
    }

    // Public method: allows depositing money
    public void Deposit(double amount)
    {
        if (IsValidAmount(amount))   // call private helper method
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    // Public method: allows withdrawing money
    public void Withdraw(double amount)
    {
        if (IsValidAmount(amount) && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    // Private method: encapsulated logic for validating amounts
    private bool IsValidAmount(double amount)
    {
        return amount > 0;
    }
}

class Program
{
    static void Main()
    {
        BankAccount myAccount = new BankAccount(1000);

        Console.WriteLine("Initial Balance: " + myAccount.Balance);

        myAccount.Deposit(500);         // Deposit 500
        myAccount.Withdraw(200);        // Withdraw 200
        myAccount.Withdraw(2000);       // Invalid withdrawal

        Console.WriteLine("Final Balance: " + myAccount.Balance);
    }
}