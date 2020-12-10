using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //mvc用这个即可
            services.AddControllersWithViews();
            //创建api或者接口用这个就可以
            //services.AddControllers();
            //注册组件  
            services.AddSingleton<IClock,ChinaClock>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDepartmentServices, DepartmentService>();
            services.Configure<DemoOptions>(_configuration.GetSection("Demo"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 判断环境
            if (env.IsDevelopment())
            {
                // 如果没有捕获异常就返回这个页面
                app.UseDeveloperExceptionPage();
            }
            // 使用静态文件组件 能访问wwwroot的文件
            app.UseStaticFiles();
            // 使用中间件转换为https
            app.UseHttpsRedirection();
            // 使用验证中间件
            app.UseAuthentication();
            // 使用路由组件
            app.UseRouting();
            // 配置组件
            app.UseEndpoints(endpoints =>
            {
                // 配置中间件模板 表格模板 MVC
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=index}/{id?}");
            });
        }
    }
}
