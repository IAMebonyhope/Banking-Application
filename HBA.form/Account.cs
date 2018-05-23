using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBA.Api
{
    /// <summary>
    /// Class Account.
    /// </summary>
    [Serializable]
    
    
    public abstract class Account
    {
        /// <summary>
        /// The acc no
        /// </summary>
        protected string accNo;
        /// <summary>
        /// The balance
        /// </summary>
        protected double balance;
        /// <summary>
        /// The total account
        /// </summary>
        protected static int totalAccount;
        /// <summary>
        /// The acc type
        /// </summary>
        protected string accType;
        /// <summary>
        /// The interest rate
        /// </summary>
        private static double interestRate = 0.1;
        /// <summary>
        /// The commission rate
        /// </summary>
        private static double commissionRate;
        /// <summary>
        /// The date created
        /// </summary>
        protected DateTime dateCreated;

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public abstract void deposit(double amount);

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public abstract void withdraw(double amount);

        /// <summary>
        /// Transfers the specified amount to the specified account.
        /// </summary>
        /// <param name="acc">The account.</param>
        /// <param name="amount">The amount.</param>
        /// <exception cref="AccountException">
        /// Transfer not successful
        /// </exception>
        public virtual void transfer(Account acc, double amount)
        {
            try
            {
                this.withdraw(amount);
                try
                {
                    acc.deposit(amount);
                }
                catch (AccountException)
                {
                    double comm = amount * commissionRate;
                    this.deposit(amount + comm);
                    throw new AccountException("Transfer not successful");
                }
            }
            catch (AccountException)
            {
                throw new AccountException("Transfer not successful");
            }
        }

        /// <summary>
        /// Generates account number.
        /// </summary>
        /// <returns>Account Number</returns>
        protected string generateNum()
        {
            Random rand = new Random();

            int a = rand.Next(100, 10000);
            int b = rand.Next(100, 10000);
            string x = a.ToString() + b.ToString();
            return x;
        }

        /// <summary>
        /// Adds interest.
        /// </summary>
        public void addInterest()
        {
            if (DateTime.Now == (dateCreated.AddMonths(1)))
            {
                double interest = balance * interestRate * (0.083);
                balance = balance + interest;
            }

        }

        /// <summary>
        /// Gets or sets the commision rate.
        /// </summary>
        /// <value>The commision rate.</value>
        public static double CommisionRate
        {
            get { return commissionRate; }
            set { commissionRate = value; }
        }

        /// <summary>
        /// Gets or sets the interest rate.
        /// </summary>
        /// <value>The interest rate.</value>
        public static double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        /// <summary>
        /// Gets the get balance.
        /// </summary>
        /// <value>The get balance.</value>
        public double GetBalance{ get { return balance; } }

        /// <summary>
        /// Gets the get acc number.
        /// </summary>
        /// <value>The get acc number.</value>
        public string GetAccNum { get { return accNo; } }

        /// <summary>
        /// Gets the type of the get acc.
        /// </summary>
        /// <value>The type of the get acc.</value>
        public string GetAccType { get { return accType; } }

        /// <summary>
        /// Gets the total account.
        /// </summary>
        /// <value>The total account.</value>
        public static int TotalAccount { get { return totalAccount; } }
    }
}
