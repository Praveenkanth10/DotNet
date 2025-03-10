using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Spi;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<IJobFactory, SimpleJobFactory>();  // Use SimpleJobFactory
        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

        services.AddSingleton<SampleJob>();  // Register job
        services.AddHostedService<QuartzHostedService>(); // Register Quartz service
    });

var host = builder.Build();
await host.RunAsync();
