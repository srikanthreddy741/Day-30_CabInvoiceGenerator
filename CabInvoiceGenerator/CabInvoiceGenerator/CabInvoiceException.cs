using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoiceGenerator
{
    internal class CabInvoiceException
    {
        public class CabInvoiceCustomException : Exception
        {
            public ExceptionType type;
            public CabInvoiceCustomException(ExceptionType type, string message) : base(message)
            {
                this.type = type;
            }
            public enum ExceptionType
            {
                INVALID_ID_DISTANCE, INVALIDID_TIME, NULL_RIDES, INVALID_USER_ID, INVALIDID_RIDETYPE
            }
        }
    }
}
