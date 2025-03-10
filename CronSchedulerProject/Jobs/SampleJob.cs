using Quartz;
using System;
using System.Threading.Tasks;

public class SampleJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Job executed at: {DateTime.Now}");
        await Task.CompletedTask;
    }
}

