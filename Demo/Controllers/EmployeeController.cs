using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentServices departmentServices,IEmployeeService employeeService)
        {
            _departmentServices = departmentServices;
            _employeeService = employeeService;
        }   
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentServices.GetById(departmentId);
            ViewBag.Title = $"Employees of{department.Name}";
            ViewBag.DepartmentId = departmentId;
            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);

        }
        public  IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Emoloyee";
            return View(new Employee { 
            DepartmentId=departmentId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index), routeValues: new { departmentId = model.DepartmentId });
        }
        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), routeValues: new { departmentId = employee.DepartmentId });
        }
    }
}
