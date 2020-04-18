using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollApplication.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; } // could be 
        public string Gender { get; set; } // may be enum
        public string ImageUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public string Designation { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string NationalInsuranceNumber { get; set; }

        public PaymentMathod PaymentMathod { get; set; }

        public StudentLoan StudentLoan { get; set; } // could be a bool
        public UnionMember UnionMember { get; set; } // could be abool
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }


    }
}
