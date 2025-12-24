using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Exceptions
{
    public class InvalidTicketDataException : DomainException
    {
        public InvalidTicketDataException(string message) : base(message)
        {
        }
    }
}
