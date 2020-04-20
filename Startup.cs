using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace dotnetcoreexample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            List<string> result=new List<string>();
                
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<MyMiddleWare>();
            app.UseMiddleware<MyMiddleWare2>();
            app.UseMiddleware<MyMiddleWare3>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(middlewaresample);

           
            // app.Use(x=>c =>{ 
            //     var r=c.GetEndpoint();
            //     foreach(var i in r.Metadata){
            //         Console.Write(i);
            //     }
            //     return x(c);}
            // );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public RequestDelegate middlewaresample(RequestDelegate k){    
            return c =>{
                return k.Invoke(c);
            };
        }
        
        
    }

    public static class myclass{
        public static void ExtensionMethod(this IServiceCollection application){

        }
    }
    public class MyMiddleWare{
        RequestDelegate _del;
        public MyMiddleWare(RequestDelegate RequestDelegate){
            
            // RequestDelegate will contain refrence to the 
            // next function in the pipeline(MyMiddleware2)
            _del=RequestDelegate;
        }
        public Task InvokeAsync(HttpContext context){
            Console.WriteLine("middleware1");
           // return Task.CompletedTask;
            return _del(context);
        }
    }


    public class MyMiddleWare2{
        RequestDelegate _del;

        public MyMiddleWare2(RequestDelegate RequestDelegate){
            // RequestDelegate will contain refrence to the 
            // next function in the pipeline
            // myMiddleware3
            _del=RequestDelegate;
        }
        public Task InvokeAsync(HttpContext context){
            Console.WriteLine("middleware2");
            return _del(context);
        }
    }

    public class MyMiddleWare3{
        RequestDelegate _del;

        public MyMiddleWare3(RequestDelegate RequestDelegate){
            // RequestDelegate will contain refrence to the 
            // next function in the pipeline
            _del=RequestDelegate;
        }
        public Task InvokeAsync(HttpContext context){
            Console.WriteLine("middleware3");
            return _del(context);
        }
    }
}
