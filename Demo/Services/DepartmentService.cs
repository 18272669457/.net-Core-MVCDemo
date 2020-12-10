using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class DepartmentService:IDepartmentServices
    {
        private readonly List<Department> _departments = new List<Department>();
        public DepartmentService()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name="HR",
                EmployeeCount=16,
                Location="BeiJing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 52,
                Location = "Shanghai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Salas",
                EmployeeCount = 200,
                Location = "China"
            });
           
        }
        public Task Add(Department department)
        {
            //获取序列中最大的值
            department.Id = _departments.Max(p => p.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;// 返回集合
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            // 将对象返回
            return Task.Run(function: () => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => _departments.FirstOrDefault(p => p.Id == id));

        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function:()=> {
                return new CompanySummary
                {
                    //算出 员工数量
                    EmployeeCount = _departments.Sum(p => p.EmployeeCount),
                    // 算出每个部门的平均数量
                    AverageDepartmentEmployeeCount = (int)_departments.Average(p => p.EmployeeCount)
                };
            });
        }
    }
}
