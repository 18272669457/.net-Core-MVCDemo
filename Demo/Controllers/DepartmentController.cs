using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IOptions<DemoOptions> _options;
        public DepartmentController(IDepartmentServices departmentServices,IOptions<DemoOptions> options)
        {
            _departmentServices = departmentServices;
            _options = options;
        } 
        public async Task<IActionResult> Index() {
            ViewBag.title = "Department Index";
            var department = await _departmentServices.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.title = "add department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            ViewBag.title = "add save";
            // 判断model是否合法并且验证注解
            if (ModelState.IsValid)
            {
                await _departmentServices.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
