using PayrollApplication.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication.Models
{
    public class PaymentRecordCreateViewModel
    {
        public int Id { get; set; }
       [Display(Name = "Full name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }

        public string Nino { get; set; } // national insurance number
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [ Display(Name = "Pay Date")]
        public string PayMonth { get; set; } = DateTime.Now.Month.ToString();

        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        public string TaxCode { get; set; } = "125L";
        [Display(Name = "Hourly rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours worked")]
        public decimal HourseWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; } = 144m;
                public decimal OvertimeHours { get; set; }
     
        public decimal ContractualEarnings { get; set; }
    
        public decimal OvertimeEarnings { get; set; }
      
        public decimal Tax { get; set; }
     
        public decimal NIC { get; set; } // National Insurance contribution 
      
        public decimal? UnionFee { get; set; }
       
        public Nullable<decimal> SLC { get; set; } //STUDENT LOAN 
       
        public decimal TotalEarning { get; set; }
     
        public decimal TotalDeduction { get; set; }
      
        public decimal NetPayment { get; set; }
    }
}
