using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class BusinessException : Exception
    {
        public BusinessException(string message, bool status)
        {
            Text = message;
            Status = status;
        }

        public string? Text { get; set; }
        public bool Status { get; set; }
    }
}
