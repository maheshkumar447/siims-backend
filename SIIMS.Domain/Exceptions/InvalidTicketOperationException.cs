using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Exceptions
{
    public class InvalidTicketOperationException : DomainException
    {
        public InvalidTicketOperationException(string message) : base(message)
        {

        }
    }
}
