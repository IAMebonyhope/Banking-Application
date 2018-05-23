// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-18-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="FixedDepositAccount.cs" company="">
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
    /// Class FixedDepositAccount.
    /// </summary>
    /// <seealso cref="BankingApplication.Account" />
    [Serializable]
    public class FixedDepositAccount : Account
    {
        private static double minAmount = 50000;
        private static int totalFixedDepositAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedDepositAccount" /> class.
        /// </summary>
        /// <param name="bal">The initial balance.</param>
        /// <param name="date">The creation date of the account.</param>
        public FixedDepositAccount(double bal, DateTime date)
        {
            accNo = generateNum();
            balance = bal;
            dateCreated = date;
            accType = "FixedDepositAccount";
            totalAccount++;
            totalFixedDepositAccount++;
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
        /// Gets the total fixed deposit account.
        /// </summary>
        /// <value>The total fixed deposit account.</value>
        public static int TotalFixedDepositAccount { get { return totalFixedDepositAccount; } }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">You cant deposit into this account</exception>
        public override void deposit(double amount)
        {
            throw new AccountException("You cant deposit into this account");
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">
        /// You cant withdraw from this account yet
        /// or
        /// invalid amount
        /// or
        /// You have less than this amount in your account
        /// </exception>
        public override void withdraw(double amount)
        {
            if (DateTime.Now < (dateCreated.AddMonths(6)))
            {
                throw new AccountException("You cant withdraw from this account yet");
            }
            else if(amount < 0)
            {
                throw new AccountException("invalid amount");
            }
            else if (amount > balance)
            {
                throw new AccountException("You have less than this amount in your account");
            }
            else
            {
                balance -= amount;
            }
           
            
        }

        /// <summary>
        /// Transfers the specified amount into the specified account.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <param name="amount">The amount.</param>
        /// <exception cref="BankingApplication.AccountException">you cant transfer into this account</exception>
        public override void transfer(Account acc, double amount)
        {
            throw new AccountException("you cant transfer into this account");
        }

    }
}
