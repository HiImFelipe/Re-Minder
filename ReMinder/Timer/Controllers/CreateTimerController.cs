using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;

namespace Timer.Timer.Controllers;

public class CreateTimerControllerParams
{
    public string Message { get; set; } = null!;
    public string WaitingTime { get; set; } = null!;
}

public class CreateTimerController(ITimerService timerService)
{
    public async Task<LocalTimer> Execute(TimerControllerCreateParams payload)
    {
        var timer = await timerService.Create(new TimerServiceCreateParams()
        {
            WaitingTime = payload.WaitingTime,
            Message = payload.Message
        });

        if (timer == null)
        {
            throw new Exception("Unexpected Behaviour: TimerServiceCreate returned null");
        }
         
        return timer;
    }
}