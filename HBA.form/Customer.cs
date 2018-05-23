// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-17-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="Customer.cs" company="">
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
    /// Class Customer.
    /// </summary>
    [Serializable]
    public class Customer
    {
        private string name;
        private DateTime dateCreated;
        private string email;
        private string phoneNum;
        private string address;
        private string occupation;
        private string gender;
        private string dob;
        private int pin;
        private Account account;
        private static int totalCustomers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="date">The creation date of the customer.</param>
        public Customer(DateTime date)
        {
            dateCreated = date;
            totalCustomers++;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public string Name
        {
            get{return name;}
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new CustomerException("invalid input");
                }
                else
                {
                    name = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the phone no.
        /// </summary>
        /// <value>The phone no.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public string PhoneNo
        {
            get { return phoneNum; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new CustomerException("invalid input");
                }
                else
                {
                    phoneNum = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new CustomerException("invalid input");
                }
                else
                {
                    address = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        /// <value>The pin.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public int Pin
        {
            get { return pin; }
            set
            {
                if ((value > 9999) || (value < 0))
                {
                    throw new CustomerException("invalid input");
                }
                else
                {
                    pin = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the occupation.
        /// </summary>
        /// <value>The occupation.</value>
        public string Occupation
        {
            get { return occupation; }
            set{ occupation = value;}
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public string Email
        {
            get { return email; }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new CustomerException("invalid input");
                }
                else
                {
                    email = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>The dob.</value>
        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime CreationDate
        {
            get { return dateCreated; }
        }

        /// <summary>
        /// Gets the total customers.
        /// </summary>
        /// <value>The total customers.</value>
        public static int TotalCustomers
        {
            get { return totalCustomers; }
        }

        //every customer own an account...
        /// <summary>
        /// Gets or sets the Account.
        /// </summary>
        /// <value>The Account.</value>
        /// <exception cref="BankingApplication.CustomerException">invalid input</exception>
        public Account GetAccount
        {
            get { return account; }
            set
            {
                if (value is Account)
                {
                    account = value;
                    
                }
                else
                {
                   throw new CustomerException("invalid input");
                }
            }
        }

        /// <summary>
        /// creates a new customer.
        /// </summary>
        /// <param name="newacctype">The new account type.</param>
        /// <returns>Customer.</returns>
        /// <exception cref="BankingApplication.CustomerException">
        /// You cant create a saving account with this amount
        /// or
        /// You cant create a current account with this amount
        /// or
        /// You cant create a fixed deposit account with this amount
        /// or
        /// Invalid account type
        /// </exception>
        public Customer newCustomer(int newacctype)
        {
            Customer newCust;
            switch (newacctype)
            {
                case 1:
                    if(this.GetAccount.GetBalance > SavingAccount.MaximumAmount)
                    {
                        throw new CustomerException("You cant create a saving account with this amount");
                    }
                    newCust = this;
                    newCust.GetAccount = new SavingAccount(this.GetAccount.GetBalance, DateTime.Now);
                    break;

                case 2:
                    if(this.GetAccount.GetBalance < CurrentAccount.MinimumAmount)
                    {
                        throw new CustomerException("You cant create a current account with this amount");
                    }
                    newCust = this;
                    newCust.GetAccount = new CurrentAccount(this.GetAccount.GetBalance, DateTime.Now);
                    break;

                case 3:
                    if(this.GetAccount.GetBalance < FixedDepositAccount.MinimumAmount)
                    {
                        throw new CustomerException("You cant create a fixed deposit account with this amount");
                    }
                    newCust = this;
                    newCust.GetAccount = new FixedDepositAccount(this.GetAccount.GetBalance, DateTime.Now);
                    break;

                default:
                    throw new CustomerException("Invalid account type");
            }

            return newCust;
        }
    }
}
