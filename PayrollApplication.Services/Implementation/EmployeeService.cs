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
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal studentLoanAmount;
        public IEnumerable<SelectListItem> GetAllEmployesForPaymentProccesing()
        {
            return GetAll().Select(e => new SelectListItem()
            {
                Text = e.FirstName,
                Value = e.Id.ToString()
            }); 
        }
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee employee)
        {
           await _context.Employees.AddAsync(employee);

           await  _context.SaveChangesAsync();
        }

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;
      

        public Employee GetById(int employeeId) => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault(); // using expression body
   

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if(employee.StudentLoan == StudentLoan.Yes && totalAmount> 1750 && totalAmount < 2000)
            {
                studentLoanAmount = 15m;
            }
            else if(employee.StudentLoan == StudentLoan.Yes && totalAmount > 2000 && totalAmount < 2250)
            {
                studentLoanAmount = 38;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 2250 && totalAmount < 2500)
            {
                studentLoanAmount = 60m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 2500)
            {
                studentLoanAmount = 83m;
            }
            else
            {
                studentLoanAmount = 0m;
            }
            return studentLoanAmount;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);

            var fees = employee.UnionMember == UnionMember.Yes ? 10m : 0m;
            return fees;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
