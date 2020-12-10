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
    /// ������
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
            //mvc���������
            services.AddControllersWithViews();
            //����api���߽ӿ�������Ϳ���
            //services.AddControllers();
            //ע�����  
            services.AddSingleton<IClock,ChinaClock>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDepartmentServices, DepartmentService>();
            services.Configure<DemoOptions>(_configuration.GetSection("Demo"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �жϻ���
            if (env.IsDevelopment())
            {
                // ���û�в����쳣�ͷ������ҳ��
                app.UseDeveloperExceptionPage();
            }
            // ʹ�þ�̬�ļ���� �ܷ���wwwroot���ļ�
            app.UseStaticFiles();
            // ʹ���м��ת��Ϊhttps
            app.UseHttpsRedirection();
            // ʹ����֤�м��
            app.UseAuthentication();
            // ʹ��·�����
            app.UseRouting();
            // �������
            app.UseEndpoints(endpoints =>
            {
                // �����м��ģ�� ���ģ�� MVC
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=index}/{id?}");
            });
        }
    }
}
