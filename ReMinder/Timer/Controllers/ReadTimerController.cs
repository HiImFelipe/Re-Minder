using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;

namespace Timer.Timer.Controllers;

public class ReadTimerController(ITimerService timerService)
{
    public async Task<LocalTimer> Execute(TimerControllerReadParams payload)
    {
        var timer = await timerService.Read(new TimerServiceReadParams()
        {
            Id = payload.Id
        });

        if (timer == null)
        {
            throw new Exception("Unexpected Behaviour: TimerServiceCreate returned null");
        }
         
        return timer;
    }
}