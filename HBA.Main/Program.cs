// ***********************************************************************
// Assembly         : BankingApplication
// Author           : EbonyHope
// Created          : 07-16-2017
//
// Last Modified By : EbonyHope
// Last Modified On : 07-25-2017
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBA.Api;

namespace HBA.Main
{
 
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO EBONYHOPE BANK");
            Console.WriteLine();
            selectOption();
        }


        public static void selectOption()
        {
            Console.WriteLine("Select an operation");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Check Balance");
            Console.WriteLine("6. Update Details");
            Console.WriteLine("7. Exit");
            Console.Write(">> ");
            //Console.WriteLine();

            int x;

            if ((Int32.TryParse(Console.ReadLine(), out x)) && (x != 7))
            {
                Operation op = new Operation(x);
                System.Threading.Thread.Sleep(10000);
                Console.Clear();
                selectOption();
            }
            else if(x == 7)
            {
                Console.WriteLine();
                Console.WriteLine("Thanks For Banking With Us....");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Operation");
                selectOption();
            }
           
        }
    }
}


