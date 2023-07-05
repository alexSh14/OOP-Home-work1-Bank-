using OOP;
using System;
using System.Collections.Generic;

            Bank bank = new Bank();

            BankAccount account1 = bank.AddAccount("John", 500);
            BankAccount account2 = bank.AddAccount("Jane", 1000);

            bank.TransferFunds("John", "Jane", 200);

            Console.WriteLine("John's balance: " + bank.GetAccountBalance("John"));
            Console.WriteLine("Jane's balance: " + bank.GetAccountBalance("Jane"));
