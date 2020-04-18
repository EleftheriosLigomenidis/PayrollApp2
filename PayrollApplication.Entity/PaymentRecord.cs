using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayrollApplication.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }

        public string Nino { get; set; } // national insurance number

        public DateTime PaymentDate { get; set; }
        public string PayMonth { get; set; }

        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourseWorked { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal(18,2)")] // Before decimal 16 digits and after it 2 digits.
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal NIC { get; set; } // National Insurance contribution 
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> SLC { get; set; } //STUDENT LOAN 
        [Column(TypeName = "money")]
        public decimal TotalEarning { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName ="money")]
        public decimal NetPayment { get; set; }




    }
}
