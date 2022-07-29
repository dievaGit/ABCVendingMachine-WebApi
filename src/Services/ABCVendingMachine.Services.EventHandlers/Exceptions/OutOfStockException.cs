using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.EventHandlers.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }
    }
}
