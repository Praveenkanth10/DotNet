using Microsoft.AspNetCore.Mvc;
using Quartz;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly ISchedulerFactory _schedulerFactory;

    public JobController(ISchedulerFactory schedulerFactory)
    {
        _schedulerFactory = schedulerFactory;
    }

    [HttpPost("trigger")]
    public async Task<IActionResult> TriggerJob()
    {
        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create<SampleJob>().Build();
        var trigger = TriggerBuilder.Create().StartNow().Build();
        await scheduler.ScheduleJob(job, trigger);
        return Ok("Job triggered successfully.");
    }
}

