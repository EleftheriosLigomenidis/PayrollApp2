using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollApplication.Entity;
using PayrollApplication.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.Services.Implementation
{
    public class PayComputationService : IPayComputationServices
    {
        private readonly ApplicationDbContext _context;
        private decimal contractualEarnings;
        private decimal overTimeHours;
        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if(hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }

            return contractualHours;
        }

        public async Task CreateAsynch(PaymentRecord paymentRecord)
        {
           await _context.PaymentRecords.AddAsync(paymentRecord);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);
        

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(t => new SelectListItem()
            {
                Text = t.YearOfTax,
                Value = t.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int id) => _context.PaymentRecords.Where(pr => pr.Id == id).FirstOrDefault();

        public TaxYear GetTaxYearById(int id) => _context.TaxYears.Find(id);
        

        public decimal NetPay(decimal totalEarning, decimal totalDeduction) => totalEarning - totalDeduction;


        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
            => overtimeHours * overtimeRate;
      

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if(hoursWorked <= contractualHours)
            {
                overTimeHours = 0.00m;
            }
            else if(hoursWorked > contractualHours)
            {
                overTimeHours = hoursWorked - contractualHours;
            }
            return overTimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate) => hourlyRate * 1.5m;


        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFee) => tax + nic + studentLoanRepayment + unionFee;


        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
       => overtimeEarnings + contractualEarnings;
    }
}
