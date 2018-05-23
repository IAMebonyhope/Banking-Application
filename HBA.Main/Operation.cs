// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-17-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="Operation.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using HBA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using HBA.Api;


namespace HBA.Main
{

    /// <summary>
    /// Class Operation.
    /// </summary>
    public class Operation
    {
        private static Dictionary<string, Customer> cDatabase = new Dictionary<string, Customer>();
        private int opt;
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation" /> class.
        /// </summary>
        /// <param name="x">The operation.</param>
        public Operation(int x)
        {
            cDatabase = Load();
            updateDictionary();
            opt = x;
            bankSettings();
            selectOperation();
            saveDictionary();
        }

        /// <summary>
        /// Selects the operation.
        /// </summary>
        private void selectOperation()
        {
            switch (opt)
            {
                case 1:
                    createAccount();                   
                    break;
                case 2:                   
                    deposit();
                    break;
                case 3:
                    withdraw();
                    break;
                case 4:
                    transfer();
                    break;
                case 5:
                    checkBalance();
                    break;
                case 6:
                    updateProfile();
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }
        }

        /// <summary>
        /// Create account operation.
        /// </summary>
        private void createAccount()
        {
            DateTime date = DateTime.Now;
            Customer newCust = new Customer(date);

            Console.WriteLine("Please select Account type");
            Console.WriteLine("1. Individual Account");
            Console.WriteLine("2. Coporate Account");

            Console.Write(">> ");
            int x;
            if (Int32.TryParse(Console.ReadLine(), out x))
            {

                if (x == 1)
                {
                    createIndividual(newCust);
                    customerDetails(newCust);
                }
                else if (x == 2)
                {
                    createCoporate(newCust);
                    customerDetails(newCust);
                }
                else
                {
                    Console.WriteLine("Invalid Account Type");
                    createAccount();
                }
            }
            else
            {
                Console.WriteLine("invalid input");
                createAccount();
            }
        }

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <param name="currentCust">The new customer.</param>
        /// <returns>Customer.</returns>
        private Customer getAccountType(Customer currentCust)
        {
            double initialBalance = 0;

            Console.WriteLine("Please select Account type");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Fixed Deposit Account");

            Console.Write(">> ");
            int x;
            if (!Int32.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("invalid input");
                getAccountType(currentCust);
            }
            else if (x == 1)
            {
                initialBalance = 0;
                SavingAccount newAcc = new SavingAccount(initialBalance, currentCust.CreationDate);
                currentCust.GetAccount = newAcc;
            }
            else if (x == 2)
            {
                initialBalance = getCurrentDeposit();
                CurrentAccount newAcc = new CurrentAccount(initialBalance, currentCust.CreationDate);
                currentCust.GetAccount = newAcc;
            }
            else if (x == 3)
            {
                initialBalance = getFixedDeposit();
                FixedDepositAccount newAcc = new FixedDepositAccount(initialBalance, currentCust.CreationDate);
                currentCust.GetAccount = newAcc;
            }
            else
            {
                Console.WriteLine("Invalid Account Type");
                getAccountType(currentCust);
            }

            return currentCust;
        }

        /// <summary>
        /// Creates an individual account for the specified customer
        /// </summary>
        /// <param name="newCustomer">The customer.</param>
        private void createIndividual(Customer newCustomer)
        {

            newCustomer = getAccountType(newCustomer);
            try
            {
                PersonForm newPerson = new PersonForm();
                newCustomer.Name = newPerson.Name;
                newCustomer.Occupation = newPerson.Occupation;
                newCustomer.PhoneNo = newPerson.PhoneNo;
                newCustomer.Pin = newPerson.Pin;
                newCustomer.Address = newPerson.Address;
                newCustomer.DOB = newPerson.DOB;
                newCustomer.Email = newPerson.Email;
                newCustomer.Gender = newPerson.Gender;

                cDatabase.Add(newCustomer.GetAccount.GetAccNum, newCustomer);
            }
            catch(Exception)
            {
                Console.WriteLine("Operation not successful...Please try again");
                createAccount();
            }
           
        }

        /// <summary>
        /// Creates a corporate account for the specified customer.
        /// </summary>
        /// <param name="newCustomer">The customer.</param>
        private void createCoporate(Customer newCustomer)
        {

            newCustomer = getAccountType(newCustomer);
            try
            {
                CompanyForm newPerson = new CompanyForm();
                newCustomer.Name = newPerson.Name;
                newCustomer.PhoneNo = newPerson.PhoneNo;
                newCustomer.Pin = newPerson.Pin;
                newCustomer.Address = newPerson.Address;
                newCustomer.Email = newPerson.Email;

                cDatabase.Add(newCustomer.GetAccount.GetAccNum, newCustomer);
            }
            catch (Exception)
            {
                Console.WriteLine("Operation not successful...Please try again");
                createAccount();
            }

        }

        /// <summary>
        /// Gets the initial deposit for a current account.
        /// </summary>
        /// <returns>the amount</returns>
        private int getCurrentDeposit()
        {
            Console.WriteLine("Make an initial Deposit of N5000 and above");
            Console.Write(">> ");
            int amt=0;
            int y;
            if ((Int32.TryParse(Console.ReadLine(), out y)) && (y > 5000))
            {
                amt = y;
            }
            else
            {
                Console.WriteLine("invalid input");
                amt = getCurrentDeposit();
            }

            return amt;
        }

        /// <summary>
        /// Gets the initial deposit for a fixed deposit account.
        /// </summary>
        /// <returns>the amount</returns>
        private int getFixedDeposit()
        {
            Console.WriteLine("Make an initial Deposit of N50000 and above");
            Console.Write(">> ");
            int amt = 0;
            int y;
            if ((Int32.TryParse(Console.ReadLine(), out y)) && (y > 50000))
            {
                amt = y;
            }
            else
            {
                Console.WriteLine("invalid input");
                amt = getFixedDeposit();
            }

            return amt;
        }

        /// <summary>
        /// Deposit Operation
        /// </summary>
        private void deposit()
        {
            Console.WriteLine("Please input your Account Number");
            Console.Write(">> ");
            string acc = Console.ReadLine();
            Customer cust;
            double amount;

            if (cDatabase.ContainsKey(acc))
            {
                Console.WriteLine("Please Input Amount");
                Console.Write(">> ");
                if((cDatabase.TryGetValue(acc, out cust)) && double.TryParse(Console.ReadLine(), out amount))
                {
                        try
                        {
                            cust.GetAccount.deposit(amount);
                            alert("Deposit", amount, cust.GetAccount.GetBalance);
                        }
                        catch (AccountException e)
                        {
                            Console.WriteLine(e.Message);
                            deposit();
                        }                       
                }
                else
                {
                    Console.WriteLine("invalid Amount");
                    deposit();
                }
            }
            else
            {
                Console.WriteLine("invalid account number");
                deposit();
            }
        }

        /// <summary>
        /// Withdraw operation.
        /// </summary>
        private void withdraw()
        {
            Console.WriteLine("Please input your Account Number");
            Console.Write(">> ");
            string acc = Console.ReadLine();
            Customer cust;
            int custPin;
            double amount;

            if (cDatabase.ContainsKey(acc))
            {
                Console.WriteLine("Please Input Pin");
                Console.Write(">> ");
                if ((cDatabase.TryGetValue(acc, out cust)) && (Int32.TryParse(Console.ReadLine(), out custPin)) && (custPin == cust.Pin))
                {
                    Console.WriteLine("Please Input Amount");
                    Console.Write(">> ");
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        try
                        {
                            cust.GetAccount.withdraw(amount);
                            alert("Withdrawal", amount, cust.GetAccount.GetBalance);
                        }
                        catch (AccountException e)
                        {
                            Console.WriteLine(e.Message);
                            withdraw();
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid amount");
                        withdraw();
                    }
                }
                else
                {
                    Console.WriteLine("invalid pin");
                    withdraw();
                }
            }
            else
            {
                Console.WriteLine("invalid account number");
                withdraw();
            }
        }

        /// <summary>
        /// Transfer Operation.
        /// </summary>
        private void transfer()
        {
            Console.WriteLine("Please input your Account Number");
            Console.Write(">> ");
            string acc = Console.ReadLine();

            Console.WriteLine("Please input Receiver's Account Number");
            Console.Write(">> ");
            string acc2 = Console.ReadLine();

            Customer cust;
            Customer recCust;
            int custPin;
            double amount;

            if ((cDatabase.ContainsKey(acc)) && (cDatabase.ContainsKey(acc2)))
            {
                Console.WriteLine("Please Input Pin");
                Console.Write(">> ");
                if ((cDatabase.TryGetValue(acc, out cust)) && (cDatabase.TryGetValue(acc2, out recCust)) && (Int32.TryParse(Console.ReadLine(), out custPin)) && (custPin == cust.Pin))
                {
                    Console.WriteLine("Please Input Amount");
                    Console.Write(">> ");
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        try
                        {
                            cust.GetAccount.transfer(recCust.GetAccount, amount);
                            alert("Withdrawal", amount, cust.GetAccount.GetBalance);
                        }
                        catch (AccountException e)
                        {
                            Console.WriteLine(e.Message);
                            transfer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid amount");
                        transfer();
                    }
                }
                else
                {
                    Console.WriteLine("invalid pin");
                    transfer();
                }
            }
            else
            {
                Console.WriteLine("invalid account number");
                transfer();
            }
        }

        /// <summary>
        /// Check Balance Operation.
        /// </summary>
        private void checkBalance()
        {
            Console.WriteLine("Please input Your Account Number");
            Console.Write(">> ");
            string acc = Console.ReadLine();

            Customer cust;
            int custPin;
            double amount;

            if (cDatabase.ContainsKey(acc)) 
            {
                Console.WriteLine("Please Input Pin");
                Console.Write(">> ");
                if ((cDatabase.TryGetValue(acc, out cust)) && (Int32.TryParse(Console.ReadLine(), out custPin)) && (custPin == cust.Pin))
                {
                    
                        try
                        {
                            amount = 0;
                            alert("Check Balance", amount, cust.GetAccount.GetBalance);
                        }
                        catch (AccountException e)
                        {
                            Console.WriteLine(e.Message);
                            checkBalance();
                        }
                }
                else
                {
                    Console.WriteLine("invalid pin");
                    checkBalance();
                }
            }
            else
            {
                Console.WriteLine("invalid account number");
                checkBalance();
            }
        }

        /// <summary>
        /// Update profile Operation.
        /// </summary>
        private void updateProfile()
        {
            Console.WriteLine("Please input your Account Number");
            Console.Write(">> ");
            string acc = Console.ReadLine();
            Customer cust;
            int custPin;

            if (cDatabase.ContainsKey(acc))
            {
                Console.WriteLine("Please Input Pin");
                Console.Write(">> ");
                if ((cDatabase.TryGetValue(acc, out cust)) && (Int32.TryParse(Console.ReadLine(), out custPin)) && (custPin == cust.Pin))
                {
                    if(cust.Gender != null)
                    {
                        Console.WriteLine("Select the data to be updated: ");

                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Email");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. Phone Number");
                        Console.WriteLine("5. Occupation");
                        Console.WriteLine("6. Pin");
                        Console.WriteLine("7. Account Type");

                        updatePerson(cust);
                    }
                    else
                    {
                        Console.WriteLine("Select the data to be updated: ");

                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Email");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. Phone Number");
                        Console.WriteLine("5. Pin");
                        Console.WriteLine("6. Account Type");

                        updateCompany(cust);
                    }
                }
                else
                {
                    Console.WriteLine("invalid Pin");
                    updateProfile();
                }
            }
            else
            {
                Console.WriteLine("invalid account number");
                updateProfile();
            }

        }


        /// <summary>
        /// Updates the profile of a customer with an individual account.
        /// </summary>
        /// <param name="customer">The customer.</param>
        private void updatePerson(Customer customer)
        {
            PersonForm newForm = new PersonForm();
            int opr;

            if (Int32.TryParse(Console.ReadLine(), out opr))
            {
                try
                {
                    switch (opr)
                    {
                        case 1:
                            Console.WriteLine("Old Name: " + customer.Name);
                            string newName = newForm.getName();
                            customer.Name = newName;
                            break;
                        case 2:
                            Console.WriteLine("Old Email: " + customer.Email);
                            string newEmail = newForm.getEmail();
                            customer.Email = newEmail;
                            break;
                        case 3:
                            Console.WriteLine("Old Address: " + customer.Address);
                            string newAddress = newForm.getAddress();
                            customer.Address = newAddress;
                            break;
                        case 4:
                            Console.WriteLine("Old Phone: " + customer.PhoneNo);
                            string newPhone = newForm.getPhoneNumber();
                            customer.PhoneNo = newPhone;
                            break;
                        case 5:
                            Console.WriteLine("Old Occupation: " + customer.Occupation);
                            string newOccupation = newForm.getOccupation();
                            customer.Occupation = newOccupation;
                            break;
                        case 6:
                            Console.WriteLine("Old Pin: " + customer.Pin);
                            int newPin = newForm.getPin();
                            customer.Pin = newPin;
                            break;
                        case 7:
                            Console.WriteLine("Old Account Type: " + customer.GetAccount.GetAccType);
                            int op;
                            Console.WriteLine("Select Your New account Type");
                            Console.WriteLine("1. Saving Account");
                            Console.WriteLine("1. Curent Account");
                            Console.WriteLine("1. Fixed Deposit Account");
                            if (Int32.TryParse(Console.ReadLine(), out op))
                            {
                                customer.newCustomer(op);
                            }
                            else
                            {
                                Console.WriteLine("invalid input");
                                updatePerson(customer);
                            }
                            break;
                        case 8:
                            Console.WriteLine("Invalid Input");
                            updatePerson(customer);
                            break;
                    }
                }
                catch (CustomerException)
                {
                    Console.WriteLine("Updating not successful...Please try again");
                    updatePerson(customer);

                }
            }
            else
            {
                Console.WriteLine("Invalid Operation");
                updatePerson(customer);
            }

        }


        /// <summary>
        /// Updates the profile of a customer with a corporate account.
        /// </summary>
        /// <param name="customer">The customer.</param>
        private void updateCompany(Customer customer)
        {
            CompanyForm newForm = new CompanyForm();
            int opr;

            if (Int32.TryParse(Console.ReadLine(), out opr))
            {
                try
                {
                    switch (opr)
                    {
                        case 1:
                            Console.WriteLine("Old Name: " + customer.Name);
                            string newName = newForm.getName();
                            customer.Name = newName;
                            break;
                        case 2:
                            Console.WriteLine("Old Email: " + customer.Email);
                            string newEmail = newForm.getEmail();
                            customer.Email = newEmail;
                            break;
                        case 3:
                            Console.WriteLine("Old Address: " + customer.Address);
                            string newAddress = newForm.getAddress();
                            customer.Address = newAddress;
                            break;
                        case 4:
                            Console.WriteLine("Old Phone: " + customer.PhoneNo);
                            string newPhone = newForm.getPhoneNumber();
                            customer.PhoneNo = newPhone;
                            break;
                        case 5:
                            Console.WriteLine("Old Pin: " + customer.Pin);
                            int newPin = newForm.getPin();
                            customer.Pin = newPin;
                            break;
                        case 6:
                            Console.WriteLine("Old Account Type: " + customer.GetAccount.GetAccType);
                            int op;
                            Console.WriteLine("Select Your New account Type");
                            Console.WriteLine("1. Saving Account");
                            Console.WriteLine("1. Curent Account");
                            Console.WriteLine("1. Fixed Deposit Account");
                            if (Int32.TryParse(Console.ReadLine(), out op))
                            {
                                customer.newCustomer(op);
                            }
                            else
                            {
                                Console.WriteLine("invalid input");
                                updatePerson(customer);
                            }
                            break;
                        case 8:
                            Console.WriteLine("Invalid Input");
                            updatePerson(customer);
                            break;
                    }
                }
                catch (CustomerException)
                {
                    Console.WriteLine("Updating not successful...Please try again");
                    updatePerson(customer);

                }
            }
            else
            {
                Console.WriteLine("Invalid Operation");
                updatePerson(customer);
            }

        }

        /// <summary>
        /// Gives an alert according to a specified transaction
        /// </summary>
        /// <param name="trans">The transaction.</param>
        /// <param name="amt">The amount.</param>
        /// <param name="balance">The balance.</param>
        private void alert(string trans, double amt, double balance)
        {
            DateTime date = DateTime.Now;

            Console.WriteLine("Transaction Successful");
            Console.WriteLine("Transaction: {0}", trans);
            Console.WriteLine("Date: {0}", date);
            Console.WriteLine("Amount: {0:0.##}", amt);
            Console.WriteLine("Balance: {0:0.##}", balance);
            Console.WriteLine();
        }

        /// <summary>
        ///the bank settings.
        /// </summary>
        private void bankSettings()
        {

        }

        /// <summary>
        /// Prints a specified customer details.
        /// </summary>
        /// <param name="cust">The customer.</param>
        private void customerDetails(Customer cust)
        {
            Console.WriteLine("Account Details");
            Console.WriteLine("Account Number: {0}", cust.GetAccount.GetAccNum);
            Console.WriteLine("Account Pin: {0}", cust.Pin);
            Console.WriteLine("Account Name: {0}", cust.Name);
            Console.WriteLine("Account Email: {0}", cust.Email);
            Console.WriteLine("Account Phone: {0}", cust.PhoneNo);
            Console.WriteLine("Account Address: {0}", cust.Address);
            Console.WriteLine("Account Date Created: {0}", cust.CreationDate);
            Console.WriteLine("Account Type {0}", cust.GetAccount.GetAccType);
            Console.WriteLine("Account Balance: {0}", cust.GetAccount.GetBalance);
        }

        /// <summary>
        /// Saves the dictionary in the database
        /// </summary>
        private void saveDictionary()
        {
            serialize bla = new serialize(cDatabase);
            BinaryFormatter format = new BinaryFormatter();
            FileStream getFile = new FileStream("AppDatabase", FileMode.Create, FileAccess.Write, FileShare.None);
            using (getFile)
            {
                format.Serialize(getFile, bla);
            }
        }

        /// <summary>
        /// serialize the dictionary.
        /// </summary>
        [Serializable]
        private class serialize
        {
           
            public Dictionary<string, Customer> x;
            /// <summary>
            /// Initializes a new instance of the <see cref="serialize"/> class.
            /// </summary>
            /// <param name="x">The dictionary.</param>
            public serialize(Dictionary<string, Customer> x)
            {
                this.x = x;
            }
        }

        /// <summary>
        /// Loads the dictionary from the database.
        /// </summary>
        /// <returns>The Dictionary</returns>
        /// <exception cref="BankingApplication.AccountException">This account number is not valid</exception>
        private static Dictionary<string, Customer> Load()
        {
            Dictionary<string, Customer> acc = new Dictionary<string, Customer>();
            try
            {
                using (Stream stream = File.Open("AppDatabase", FileMode.Open))
                {
                    var bform = new BinaryFormatter().Deserialize(stream);

                    serialize ax = (serialize)bform;
                    stream.Close();
                    acc = ax.x;
                };
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                
            }

            return acc;
        }


        /// <summary>
        /// Updates the dictionary.
        /// </summary>
        private void updateDictionary()
        {
            foreach(string ck in cDatabase.Keys) 
            {
                Customer oneCust;
                if((cDatabase.TryGetValue(ck, out oneCust)))
                {
                    if((oneCust.GetAccount.GetAccType == "SavingAccount") || (oneCust.GetAccount.GetAccType == "FixedDepositAccount"))
                    {
                        oneCust.GetAccount.addInterest();
                    }
         
                }
            }
        }
            
       

    }
}
