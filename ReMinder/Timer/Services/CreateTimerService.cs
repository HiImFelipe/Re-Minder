using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;

namespace Timer.Timer.Services;

public class CreateTimerService(ITimerRepository timerRepository)
{
    public async Task<LocalTimer> Execute(TimerServiceCreateParams payload)
    {
        var timer = await timerRepository.Create(new TimerRepositoryCreateParams()
        {
            WaitingTime = payload.WaitingTime,
            Message = payload.Message
        });

        if (timer == null)
        {
            throw new Exception("Unexpected Behaviour: TimerRepositoryCreate returned null");
        }
         
        return timer;
    }
}