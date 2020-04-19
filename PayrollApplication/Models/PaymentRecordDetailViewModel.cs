using PayrollApplication.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication.Models
{
    public class PaymentRecordDetailViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
  
        public Employee Employee { get; set; }
        [MaxLength(150)]
        [Display(Name = "Employee")]
        public string FullName { get; set; }

        public string Nino { get; set; } // national insurance number
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PaymentDate { get; set; } 
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }
        public string Year { get; set; }
        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        [Display(Name = "Taxt Code")]
        public string TaxCode { get; set; }
        [Display(Name = "Hourly rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours worked")]
        public decimal HourseWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; }
        [Display(Name = "Overtime Hours")]
        public decimal OvertimeHours { get; set; }
        [Display(Name = "Overtime Rate")]
        public decimal OverTimeRate { get; set; }
        [Display(Name = "Contractual Earnings")]
        public decimal ContractualEarnings { get; set; }
        [Display(Name = "Overtime Earnings")]
        public decimal OvertimeEarnings { get; set; }

        public decimal Tax { get; set; }

        public decimal NIC { get; set; } // National Insurance contribution 
        [Display(Name = "Union fee")]
        public decimal? UnionFee { get; set; }

        public Nullable<decimal> SLC { get; set; } //STUDENT LOAN 
        [Display(Name = "Total Earnings")]
        public decimal TotalEarning { get; set; }
        [Display(Name = "Total Payment")]
        public decimal TotalDeduction { get; set; }
        [Display(Name = "Net Payment")]
        public decimal NetPayment { get; set; }
    }
}
