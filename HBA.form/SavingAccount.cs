// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-16-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="SavingAccount.cs" company="">
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
    /// Class SavingAccount.
    /// </summary>
    /// <seealso cref="BankingApplication.Account" />
    [Serializable]
    public class SavingAccount: Account
    {
        private static double maxAmount = 100000;
        private static double maxDepAmt = 50000;
        private static double maxWithdrawAmt = 20000;
        private static double minAmount = 1000;
        private static int totalSavingAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingAccount"/> class.
        /// </summary>
        /// <param name="bal">The initial balance of the account.</param>
        /// <param name="date">The creation date of the account.</param>
        public SavingAccount(double bal, DateTime date)
        {
            accNo = generateNum();
            balance = bal;
            dateCreated = date;
            accType = "SavingAccount";
            CommisionRate = 0;
            totalAccount++;
            totalSavingAccount++;
        }


        /// <summary>
        /// Gets the total saving account.
        /// </summary>
        /// <value>The total saving account.</value>
        public static int TotalSavingAccount { get { return totalSavingAccount; } }

        /// <summary>
        /// Gets or sets the maximum amount allowed in a saving account.
        /// </summary>
        /// <value>The maximum amount.</value>
        public static double MaximumAmount
        {
            get { return maxAmount; }
            set { maxAmount = value; }
        }

        /// <summary>
        /// Gets or sets the minimum amount allowed in a saving account.
        /// </summary>
        /// <value>The minimum amount.</value>
        public static double MinimumAmount
        {
            get { return minAmount; }
            set { minAmount = value; }
        }

        /// <summary>
        /// Gets or sets the maximum deposit amount allowed in a saving account.
        /// </summary>
        /// <value>The maximum deposit amount.</value>
        public static double MaxDepAmount
        {
            get { return maxDepAmt; }
            set { maxDepAmt = value; }
        }

        /// <summary>
        /// Gets or sets the maximum withdrawal amount allowed in a saving account.
        /// </summary>
        /// <value>The maximum withdraw amount.</value>
        public static double MaxWithdrawAmount
        {
            get { return maxWithdrawAmt; }
            set { maxWithdrawAmt = value; }
        }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">
        /// Invalid input
        /// or
        /// You have exceeded the maximum amount allowed in your account
        /// or
        /// Maximum deposit limit exceeded
        /// </exception>
        public override void deposit(double amount)
        {
            if(amount < 0)
            {
                throw new AccountException("Invalid input");
            }
            else if((balance + amount) > maxAmount){
                throw new AccountException("You have exceeded the maximum amount allowed in your account");
            }
            else if (amount > maxDepAmt) {
                throw new AccountException("Maximum deposit limit exceeded");
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
        /// invalid amount
        /// or
        /// You have reached the minimum amount allowed in your account
        /// or
        /// You have less this amount in your account
        /// or
        /// maximum withdrawal limit exceeded
        /// </exception>
        public override void withdraw(double amount)
        {
            if(amount < 0)
            {
                throw new AccountException("invalid amount");
            }
            else if(balance < minAmount)
            {
                throw new AccountException("You have reached the minimum amount allowed in your account");
            }
            else if(amount > balance)
            {
                throw new AccountException("You have less this amount in your account");
            }
            else if (amount > maxWithdrawAmt)
            {
                throw new AccountException("maximum withdrawal limit exceeded");
            }
            else
            {
                balance -= amount;
            }
        }

        

    }
}
