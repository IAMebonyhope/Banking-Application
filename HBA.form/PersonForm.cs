// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-18-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="PersonForm.cs" company="">
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
    /// Class PersonForm.
    /// </summary>
    /// <seealso cref="BankingApplication.RegistrationForm" />
    public class PersonForm: RegistrationForm
    {
      
        private string occupation;
        private string gender;
        private string dob;
        private int pin;
        private static int totalPersonForms;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonForm"/> class.
        /// </summary>
        public PersonForm()
        {
            getDetails();
            totalPersonForms++;
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        protected override void getDetails()
        {
            Console.WriteLine("Please Fill The Form Below ");
            base.getDetails();

            occupation = getOccupation();

            gender = getGender();

            dob = getdateOfBirth();

            pin = getPin();
        }

        /// <summary>
        /// Gets the pin.
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
        /// Get the date of birth.
        /// </summary>
        /// <returns>date of birth</returns>
        public string getdateOfBirth()
        {
            Console.Write("Date of Birth: \t");
            string tempD = Console.ReadLine();
            if  (string.IsNullOrEmpty(tempD.Trim()))
            {
                Console.WriteLine("invalid input");
                tempD = getdateOfBirth();
            }
            return tempD;
        }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <returns>the gender</returns>
        public string getGender()
        {
            Console.Write("Gender: \t");
            string tempGend = Console.ReadLine();
            if (string.IsNullOrEmpty(tempGend.Trim()) || ((tempGend.Trim()).ToUpper().Equals("MALE")) || ((tempGend.Trim()).ToUpper().Equals("FEMALE")))
            {
                Console.WriteLine("invalid input");
               tempGend = getGender();
            }
            return tempGend;
        }

        /// <summary>
        /// Gets the occupation.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getOccupation()
        {
            Console.Write("Occupation: \t");
            string tempOcc = Console.ReadLine();
            if (string.IsNullOrEmpty(tempOcc.Trim()))
            {
                Console.WriteLine("invalid input");
                tempOcc = getOccupation();
            }
            return tempOcc;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get{return name;}}

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
        /// Gets the occupation.
        /// </summary>
        /// <value>The occupation.</value>
        public string Occupation { get { return occupation; } }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get { return email; } }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get { return gender; } }

        /// <summary>
        /// Gets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        public string DOB { get { return dob; } }

        /// <summary>
        /// Gets the pin.
        /// </summary>
        /// <value>The pin.</value>
        public int Pin { get { return pin; } }

        /// <summary>
        /// Gets the total person forms.
        /// </summary>
        /// <value>The total person forms.</value>
        public int TotalPersonForms { get { return totalPersonForms; } }
    }
}
