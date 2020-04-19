using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollApplication.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            //based on Uk
            if(totalAmount <= 1042)
            {
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if(totalAmount > 1042 && totalAmount <= 3125)
            {
                //basic tax rate 
                taxRate = .20m;
                //income tax rate
                tax = (1032 * .0m) + ((totalAmount - 1042) * taxRate);
            }
            else if(totalAmount > 3125 && totalAmount <= 12500)
            {
                // higher tax rate
                taxRate = .40m;
                //income tax rate
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((totalAmount - 3125) * taxRate);
            }
            else if(totalAmount > 12500)
            {
                // highest tax rate
                taxRate = .45m;
                //income tax rate
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((12500 - 3125) * .40m) + ((totalAmount - 12500) * taxRate);
            }

            return tax;
        }
    }
}
