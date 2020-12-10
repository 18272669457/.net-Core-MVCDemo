using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Services;

using Microsoft.AspNetCore.Mvc;

namespace Demo.ViewComponents
{
    public class CompanySummaryViewComponent:ViewComponent
    {
        private readonly IDepartmentServices _departmentService;

        public CompanySummaryViewComponent(IDepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.title = title;
            var summery =await _departmentService.GetCompanySummary();
            return View(summery);
        }
    }
}
