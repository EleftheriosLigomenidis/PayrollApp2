using PayrollApplication.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee employee);

        Employee GetById(int employeeId);

        Task UpdateAsync(Employee employee);

        Task UpdateAsync(int id); // method overload
    
        Task Delete(int employeeId);

        decimal UnionFees(int id);

        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);

        IEnumerable<Employee> GetAll();
    }
}
