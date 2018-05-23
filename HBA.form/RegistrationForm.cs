// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-17-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="RegistrationForm.cs" company="">
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
    /// Class RegistrationForm.
    /// </summary>
    public class RegistrationForm
    {
        /// <summary>
        /// The name
        /// </summary>
        protected string name;
        /// <summary>
        /// The email
        /// </summary>
        protected string email;
        /// <summary>
        /// The phone number
        /// </summary>
        protected string phoneNum;
        /// <summary>
        /// The address
        /// </summary>
        protected string address;
        /// <summary>
        /// The total forms
        /// </summary>
        private static int totalForms;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationForm"/> class.
        /// </summary>
        public RegistrationForm()
        {
            totalForms++; 
        }

        /// <summary>
        /// Gets the  user details.
        /// </summary>
        protected virtual void getDetails()
        {

            name = getName();

            email = getEmail();

            phoneNum = getPhoneNumber();

            address = getAddress();
        }

        /// <summary>
        /// Gets the total form.
        /// </summary>
        /// <value>The total form.</value>
        public int TotalForm { get { return totalForms; } }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>the name</returns>
        public string getName()
        {
            Console.Write("Account Name: \t");
            string tempName = Console.ReadLine();
            if (string.IsNullOrEmpty(tempName.Trim()))
            {
                Console.WriteLine("invalid input");
                tempName = getName();
            }

            return tempName;
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <returns>the email</returns>
        public string getEmail()
        {
            Console.Write("Email: \t");
            string tempEmail = Console.ReadLine();
            if (string.IsNullOrEmpty(tempEmail.Trim()))
            {
                Console.WriteLine("invalid input");
                tempEmail = getEmail();
            }
            return tempEmail;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <returns>the address</returns>
        public string getAddress()
        {
            Console.Write("Address: \t");
            string tempAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(tempAddress.Trim()))
            {
                Console.WriteLine("invalid input");
                tempAddress = getAddress();
            }
            return tempAddress;
        }

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <returns>the phone number</returns>
        public string getPhoneNumber()
        {
            Console.Write("Phone Number: \t");
            string tempPhone = Console.ReadLine();
            if (string.IsNullOrEmpty(tempPhone.Trim()))
            {
                Console.WriteLine("invalid input");
                tempPhone = getPhoneNumber();
            }
            return tempPhone;
        }
    }
}
