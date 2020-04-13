using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
public class MyHostedService: IHostedService{
    Timer timer;
    public  Task StartAsync(CancellationToken cancellationToken){
        Console.WriteLine("started");
        
      //while(true){
          timer=new Timer(print,null,0,5000);
      //}
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken){
      Console.WriteLine("stopped");
    
        return Task.CompletedTask;
    }

    public void print(object? state){
      int i=1;
       Console.WriteLine("hi for the"+i++);
    }
}