using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using flent_Validation.Models;
using FluentValidation;

namespace flent_Validation.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployeeController emp)
        {
            Employee_Validation Obj = new Employee_Validation();
            ValidationResult Result = Obj.Validate(emp);
            if (!Result.IsValid)
            {
                foreach (ValidationFailure failure in Result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View();
        }
    }
}
