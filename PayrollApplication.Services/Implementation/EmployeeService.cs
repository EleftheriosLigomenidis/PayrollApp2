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
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
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
