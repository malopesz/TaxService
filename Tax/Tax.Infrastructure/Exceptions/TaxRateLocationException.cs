using System;

namespace Tax.Infrastructure.Exceptions
{
    public class TaxRateLocationException : Exception
    {
        public string ErrorMessage;

        public TaxRateLocationException(string message)
        {
            ErrorMessage = message;
        }
    }
}
