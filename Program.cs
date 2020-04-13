using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetcoreexample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // dotnet core can support

            // Http
            // non-http work loads
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            // HostBuilder builder=new HostBuilder();
            // builder.ConfigureAppConfiguration((y,z)=>{
            //     z.AddEnvironmentVariables();
            //     z.AddJsonFile("");
            // })
            // .ConfigureLogging((y,z)=>{
            //     z.AddConsole();
            //     z.AddDebug();
            // })
            // ;
            
            // return builder;
        
        return Host.CreateDefaultBuilder(args)
                // .ConfigureServices((y)=>{
                //     y.AddHostedService<MyHostedService>();
                    
                // });
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
        }
            
    }
}
