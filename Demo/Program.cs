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
            //����������.net core�ĵ�һ��Ӧ��Ȼ������
            CreateHostBuilder(args).Build().Run(); 
        }
        /// <summary>
        /// .net core �Ǿ���������������õ�CreateHostBuilder ����������IHostBuilder Ȼ����ô���
        /// �ͽ�����̨ת��Ϊ.net core Ӧ����
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //����
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
