using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollApplication.Services
{
   public  interface INationalInsuranceContributionServices
    {
        decimal NIContribution(decimal totalAmount);
    }
}
