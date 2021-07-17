using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsCoreProject
{
   public class ErrorMessage
    {
        public string Message { get; set; }

        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
