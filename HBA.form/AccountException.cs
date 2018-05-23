using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBA.Api
{
    /// <summary>
    /// Class AccountException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class AccountException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountException"/> class.
        /// </summary>
        public AccountException(string message) : base(message)
        {

        }

    }

    /// <summary>
    /// Class CustomerException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomerException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomerException(string message) : base(message)
        {

        }

    }
}
