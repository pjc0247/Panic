using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Test.DataModel
{
    public class InvalidContractUsageException : Exception
    {
        public string Message { get; private set; }

        public InvalidContractUsageException(string message)
        {
            Message = message;
        }
    }
}
