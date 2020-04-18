using Microsoft.AspNetCore.Http;
using PayrollApplication.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Message required"), RegularExpression(@"^[A-Z] {3,3} [0-9] {3}$")] //uppercase only aplphabetical chars max and mix 3 and numbers 0-9 min 3

        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "first name is required"), StringLength(50, MinimumLength = 2), Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z] [a-zA-Z""'\s-]*$")] //first char must be capital rest of char a-z or A-Z position mark contain dashes or spaces *=zero or many on the left
        public string FirstName { get; set; }
        [StringLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "first name is required"), StringLength(50, MinimumLength = 2), Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z] [a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; }
       



        public string Gender { get; set; } // may be enum
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of birth")]
        public DateTime DateJoined { get; set; } 
        [Required, MaxLength(50)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(50), Display(Name = "National Insurance Number"), RegularExpression(@"^[A-CEGHJ-PR-TW-Z] {1} [A-CEGHJ-NPR-TW-Z] {1} [0-9] {6} [A-D\s]$")] // first can be any letter from A-C EXCLUDING D anything from j-p cannot be u 

        public string NationalInsuranceNumber { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMathod PaymentMathod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; } // could be a bool
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; } // could be abool
        [Required, MaxLength(150)]

        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50), Display(Name = "Post Code")]
        public string PostCode { get; set; }

        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }

        public string PhoneNumber { get; set; }
    }
}
