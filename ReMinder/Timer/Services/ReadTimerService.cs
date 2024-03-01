using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;

namespace Timer.Timer.Services;

public class ReadTimerService(ITimerRepository timerRepository)
{
    public async Task<LocalTimer> Execute(TimerServiceReadParams payload)
    {
        var timer = await timerRepository.Read(new TimerRepositoryReadParams()
        {
            Id = payload.Id
        });

        if (timer == null)
        {
            throw new Exception("Unexpected Behaviour: TimerRepositoryCreate returned null");
        }
         
        return timer;
    }
}