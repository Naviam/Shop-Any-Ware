namespace TdService.Infrastructure.PayPalHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PayPal.PayPalAPIInterfaceService.Model;

    public class PayPalException : Exception
    {
        private List<ErrorType> errors;

        public PayPalException(List<ErrorType> codes)
        {
            this.errors = codes;
        }

        public override string Message
        {
            get
            {
                return string.Join("\n", errors.Select(error => error.ShortMessage).ToArray());
            }
        }
    }
}
