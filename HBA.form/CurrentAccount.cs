// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-17-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="CurrentAccount.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBA.Api
{
    /// <summary>
    /// Class CurrentAccount.
    /// </summary>
    /// <seealso cref="BankingApplication.Account" />
    [Serializable]
    
    public class CurrentAccount: Account
    {
        private static double minAmount = 5000;
        private static int totalCurrentAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentAccount" /> class.
        /// </summary>
        /// <param name="initialBal">The initial balance.</param>
        /// <param name="date">The creation date of the account.</param>
        public CurrentAccount(double initialBal, DateTime date)
        {
            accNo = generateNum();
            balance = initialBal;
            dateCreated = date;
            accType = "CurrentAccount";
            CommisionRate = 0.01;
            totalAccount++;
            totalCurrentAccount++;
        }


        /// <summary>
        /// Gets or sets the minimum amount allowed in a saving account.
        /// </summary>
        /// <value>The minimum amount.</value>
        public static double MinimumAmount{
            get {return minAmount;}
            set{minAmount = value;}
        }

        /// <summary>
        /// Gets the total current account.
        /// </summary>
        /// <value>The total current account.</value>
        public static int TotalCurrentAccount { get { return totalCurrentAccount; } }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">Invalid input</exception>
        public override void deposit(double amount)
        {
            if (amount < 0)
            {
                throw new AccountException("Invalid input");
            }
            else
            {
                balance = balance + amount;
            }
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">
        /// Invalid input
        /// or
        /// You have reached the minimum amount allowed in your account
        /// or
        /// You have less than this amount in your account
        /// </exception>
        public override void withdraw(double amount)
        {
            if(amount < 0)
            {
                throw new AccountException("Invalid input");
            }
            else if (balance < minAmount)
            {
                throw new AccountException("You have reached the minimum amount allowed in your account");
            }
            else if (amount > balance)
            {
                throw new AccountException("You have less than this amount in your account");
            }
            else
            {
                double comm = balance * CommisionRate;
                balance = balance - (amount + comm);
                //balance -= amount;
            }
        }

        
            
    }
}
