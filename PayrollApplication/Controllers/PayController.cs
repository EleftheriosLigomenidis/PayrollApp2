using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}