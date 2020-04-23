using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayrollApplication.Entity;
using PayrollApplication.Services;
using PayrollApplication.Models;
using PayrollApplication;
using Microsoft.AspNetCore.Authorization;

namespace PayrollApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _env = hostingEnvironment;
        }
        public IActionResult Index(int? pageNumber )
        {
            var employees = _employeeService.GetAll().Select(e => new EmployeeIndexViewModel
            {
                Id = e.Id,
                EmployeeNo = e.EmployeeNo,
                ImageUrl = e.ImageUrl,
                FullName = e.FullName,
                Gender =  e.Gender,
                Designation = e.Designation,
                City = e.City,
                DateJoined = e.DateJoined
            }).ToList();
            int pageSize = 4;
            return View(EmployeeListPagination<EmployeeIndexViewModel>.Create(employees,pageNumber ?? 1,pageSize));
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // prevents cross site Request forgery attacks

        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNumber = model.NationalInsuranceNumber,
                    PaymentMathod = model.PaymentMathod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    PhoneNumber = model.PhoneNumber,
                    PostCode = model.PostCode,
                    MiddleName = model.MiddleName,
                    Designation = model.Designation,


                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0) // see if it contains anything
                {
                    var uploadDirectory = @"images/Employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName); // get the name of the file without the extensions .jpg/.png
                    var extension = Path.GetExtension(model.ImageUrl.FileName); // gets the extensions 
                    var webrootPath = _env.WebRootPath; // needs to be initialised in constructor
                    fileName = DateTime.UtcNow.ToString("ddMMyyyy") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDirectory, fileName);
                  await  model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;
                }
               await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
   
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);

            if(employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,

                Gender = employee.Gender,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                DateJoined = employee.DateJoined,
                NationalInsuranceNumber = employee.NationalInsuranceNumber,
                PaymentMathod = employee.PaymentMathod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PhoneNumber = employee.PhoneNumber,
                PostCode = employee.PostCode,
                MiddleName = employee.MiddleName,
                Designation = employee.Designation,

            };

            return View(model);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);

                if(employee == null)
                {
                    return NotFound();

                }

                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.NationalInsuranceNumber = model.NationalInsuranceNumber;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DateOfBirth = model.DateOfBirth;
                employee.DateJoined = model.DateJoined;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Designation = model.Designation;
                employee.PaymentMathod = model.PaymentMathod;
                employee.StudentLoan = model.StudentLoan;
                employee.UnionMember = model.UnionMember;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.PostCode = model.PostCode;

                if (model.ImageUrl != null && model.ImageUrl.Length> 0) // image has been uploaded check
                {
                    // should be method 

                    var uploadDirectory = @"images/Employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName); // get the name of the file without the extensions .jpg/.png
                    var extension = Path.GetExtension(model.ImageUrl.FileName); // gets the extensions 
                    var webrootPath = _env.WebRootPath; // needs to be initialised in constructor
                    fileName = DateTime.UtcNow.ToString("ddMMyyyy") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDirectory, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;
                }

                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }


        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);

            if(employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                DateOfBirth = employee.DateOfBirth,
                NationalInsuranceNumber = employee.NationalInsuranceNumber,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                PaymentMathod = employee.PaymentMathod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                ImageUrl = employee.ImageUrl,
                PostCode = employee.PostCode

            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {


            await _employeeService.Delete(model.Id);

            return RedirectToAction(nameof(Index));


        }
    }
}