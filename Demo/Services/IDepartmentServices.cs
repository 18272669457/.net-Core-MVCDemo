using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
   public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAll();// 获取所有的部门
        Task<Department> GetById(int id); // 通过id获取部门
        Task<CompanySummary> GetCompanySummary();// 获得公司的整体情况
        Task Add(Department department);// 添加部门
    }
}
