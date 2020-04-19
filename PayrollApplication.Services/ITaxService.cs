using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollApplication.Services
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
