// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-18-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="CompanyForm.cs" company="">
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
    /// Class CompanyForm.
    /// </summary>
    /// <seealso cref="BankingApplication.RegistrationForm" />
    public class CompanyForm: RegistrationForm
    {
        private static int totalCompanyForms;
        private int pin;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyForm"/> class.
        /// </summary>
        public CompanyForm()
        {
            getDetails();
            totalCompanyForms++;
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        protected override void getDetails()
        {
            Console.WriteLine("Please Fill The Form Below ");
            base.getDetails();

            pin = getPin();
        }

        /// <summary>
        /// Get the pin number.
        /// </summary>
        /// <returns>the pin</returns>
        public int getPin()
        {
            Console.Write("4-Digit-Pin: \t");
            int x;
            int y;

            if ((Int32.TryParse(Console.ReadLine(), out y)) && (y < 9999) && (y > 999))
            {
                x = y;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                x = getPin();
            }

            return x;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets the phone no.
        /// </summary>
        /// <value>The phone no.</value>
        public string PhoneNo { get { return phoneNum; } }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get { return address; } }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get { return email; } }

        /// <summary>
        /// Gets the pin.
        /// </summary>
        /// <value>The pin.</value>
        public int Pin { get { return pin; } }

        /// <summary>
        /// Gets the total company forms.
        /// </summary>
        /// <value>The total company forms.</value>
        public int TotalCompanyForms { get { return totalCompanyForms; } }
    }
}

