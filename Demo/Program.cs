using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //配置了整个.net core的第一个应用然后运行
            CreateHostBuilder(args).Build().Run(); 
        }
        /// <summary>
        /// .net core 是经过这个方法来配置的CreateHostBuilder 返回类型是IHostBuilder 然后调用创建
        /// 就将控制台转换为.net core 应用了
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //配置
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
