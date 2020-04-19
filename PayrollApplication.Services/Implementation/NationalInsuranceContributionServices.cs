using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollApplication.Services.Implementation
{
    public class NationalInsuranceContributionServices :INationalInsuranceContributionServices
    {
        private decimal NIRate;
        private decimal NIC;

        public decimal NIContribution(decimal totalAmount)
        {
            if(totalAmount < 719)
            {
                NIRate = .0M;
                NIC = 0M;
            }
            else if(totalAmount >719 && totalAmount <= 4167)
            {
                NIRate = .12M;
                NIC = ((totalAmount - 719) * NIRate);
            }
            else if(totalAmount > 4167)
            {
                NIRate = .02M;
                NIC = ((4167 - 719) * .12M) + ((totalAmount - 4167) * NIRate);
            }

            return NIC;
        }
    }
}
