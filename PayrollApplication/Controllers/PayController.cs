using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayrollApplication.Models;
using PayrollApplication.Services;

namespace PayrollApplication.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayComputationServices _service;
        public PayController(IPayComputationServices service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var payRecords = _service.GetAll().Select(pr => new PaymentRecordIndexViewModel(){
                Id = pr.Id,
                EmployeeId = pr.EmployeeId,
                FullName = pr.FullName,
                PayDate = pr.PaymentDate,
                TaxYearId = pr.TaxYearId,
                PayMonth = pr.PayMonth,
                Year = _service.GetTaxYearById(pr.TaxYearId).YearOfTax,
                TotalDeduction = pr.TotalDeduction,
                NetPayment = pr.NetPayment,
                TotalEarnings = pr.NetPayment,
                Employee = pr.Employee

            } ).ToList(); 
            return View(payRecords);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}