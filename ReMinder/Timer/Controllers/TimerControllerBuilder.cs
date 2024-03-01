using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;
using Timer.Timer.Services;

namespace Timer.Timer.Controllers;

public sealed class TimerControllerBuilder : ITimerController
{
    private static TimerControllerBuilder? _instance;
    private readonly ITimerService _timerService;

    private TimerControllerBuilder()
    {
        _timerService = TimerServiceBuilder.GetInstance();
    }

    public static ITimerController GetInstance()
    {
        return _instance ??= new TimerControllerBuilder();
    }
     
    public async Task<LocalTimer> Create(TimerControllerCreateParams payload)
    {
        var timerController = new CreateTimerController(_timerService);

        return await timerController.Execute(payload);
    }
     
    public async Task<LocalTimer> Read(TimerControllerReadParams payload)
    {
        var timerController = new ReadTimerController(_timerService);

        return await timerController.Execute(payload);
    }
     
    public Task<LocalTimer> Update(TimerControllerUpdateParams payload)
    {
        throw new Exception("Not implemented.");
    }
     
    public void Delete(TimerControllerDeleteParams payload)
    {
        throw new Exception("Not implemented.");
    }
}