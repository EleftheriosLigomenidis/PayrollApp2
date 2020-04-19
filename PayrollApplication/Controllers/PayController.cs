﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayrollApplication.Entity;
using PayrollApplication.Models;
using PayrollApplication.Services;

namespace PayrollApplication.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayComputationServices _service;
        private readonly IEmployeeService _employeeService;
        private readonly ITaxService _taxService;
        private readonly INationalInsuranceContributionServices _nationalInsuranceContributionServices;

        private decimal overtimeHrs;
        private decimal contractualEarnings;
        private decimal overTimeEarnings;
        private decimal totalEarnings;
        private decimal tax;
        private decimal uf;
        private decimal nic;
        private decimal slc;
        private decimal totaldeduction;

        public PayController(IPayComputationServices service,
            IEmployeeService employeeService,
            ITaxService taxService,
            INationalInsuranceContributionServices nationalInsuranceContributionServices)
        {
            _service = service;
            _employeeService = employeeService;
            _taxService = taxService;
            _nationalInsuranceContributionServices = nationalInsuranceContributionServices;
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
            var model = new PaymentRecordCreateViewModel();
            ViewBag.TaxYears = _service.GetAllTaxYear();
            ViewBag.employees = _employeeService.GetAllEmployesForPaymentProccesing();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRecordCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = new PaymentRecord()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    FullName = _employeeService.GetById(model.EmployeeId).FullName,
                    Nino = _employeeService.GetById(model.EmployeeId).NationalInsuranceNumber,
                    PaymentDate = model.PaymentDate,
                    PayMonth = model.PayMonth,
                    TaxYearId = model.TaxYearId,
                    TaxCode = model.TaxCode,
                    HourlyRate = model.HourlyRate,
                    HourseWorked = model.HourseWorked,
                    ContractualHours = model.ContractualHours,
                    OvertimeHours = overtimeHrs = _service.OvertimeHours(model.HourseWorked, model.ContractualHours),
                    ContractualEarnings = contractualEarnings = _service.ContractualEarnings(model.ContractualEarnings, model.HourseWorked, model.HourlyRate),
                    OvertimeEarnings = overTimeEarnings = _service.OvertimeEarnings(_service.OvertimeRate(model.HourlyRate), overtimeHrs),
                    TotalEarning = totalEarnings = _service.TotalEarnings(overTimeEarnings, contractualEarnings),
                    Tax = tax = _taxService.TaxAmount(totalEarnings),
                    UnionFee = uf = _employeeService.UnionFees(model.EmployeeId),
                    SLC = slc = _employeeService.StudentLoanRepaymentAmount(model.EmployeeId, totalEarnings),
                    NIC = nic = _nationalInsuranceContributionServices.NIContribution(totalEarnings),
                    TotalDeduction = totaldeduction = _service.TotalDeduction(tax, nic, slc, uf),
                    NetPayment = _service.NetPay(totalEarnings,totaldeduction)




                };
              await  _service.CreateAsynch(payment);
                RedirectToAction(nameof(Index));
            }
            ViewBag.TaxYears = _service.GetAllTaxYear();
            ViewBag.employees = _employeeService.GetAllEmployesForPaymentProccesing();
            return View();
        }
    }
}