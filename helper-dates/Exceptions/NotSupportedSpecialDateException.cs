using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Exceptions
{
    public class NotSupportedSpecialDateException : Exception
    {
        public NotSupportedSpecialDateException()
        {
        }

        public NotSupportedSpecialDateException(string message) : base(message)
        {
        }

        public NotSupportedSpecialDateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
