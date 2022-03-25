using System;

namespace Tax.Infrastructure.Exceptions
{
    public class CalculateTaxException : Exception
    {
        public string ErrorMessage;

        public CalculateTaxException(string message)
        {
            ErrorMessage = message;
        }
    }
}
