using System;

namespace Tax.Infrastructure.Exceptions
{
    public class EmptyCustomerException : Exception
    {
        public string ErrorMessage;
        public EmptyCustomerException(string message)
        {
            ErrorMessage = message;
        }
    }
}
