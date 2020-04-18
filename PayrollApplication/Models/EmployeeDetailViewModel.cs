using PayrollApplication.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }

        public string EmployeeNo { get; set; }   
        public string FullName { get; set; } // could be 
        public string Gender { get; set; } // may be enum
        public string ImageUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public string Designation { get; set; }
        public string Email { get; set; }
    
        public string NationalInsuranceNumber { get; set; }

        public PaymentMathod PaymentMathod { get; set; }

        public StudentLoan StudentLoan { get; set; } // could be a bool
        public UnionMember UnionMember { get; set; } // could be abool
  
        public string Address { get; set; }
     
        public string City { get; set; }
  
        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
