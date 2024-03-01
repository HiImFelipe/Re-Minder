using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;

namespace Timer.Timer.Infrastructure.Repositories;

public class InMemoryTimerRepository: ITimerRepository
{
    private readonly List<LocalTimer> _timers = [];
    private static InMemoryTimerRepository? _instance;

    private InMemoryTimerRepository() { }

    public static ITimerRepository GetInstance()
    {
        return _instance ??= new InMemoryTimerRepository();
    }
    
    public Task<LocalTimer> Create(TimerRepositoryCreateParams payload)
    {
        var timer = new LocalTimer(message: payload.Message, waitingTime: payload.WaitingTime);
        
        _timers.Add(timer);

        return Task.FromResult(timer);
    }
    
    public Task<LocalTimer> Update(TimerRepositoryUpdateParams payload)
    {
        throw new Exception("Not Implemented");
    }
    
    public Task<LocalTimer> Read(TimerRepositoryReadParams payload)
    {
        var timer = _timers.Find((timer) => timer.Id == payload.Id);

        if (timer == null)
        {
            throw new Exception("Timer not found.");
        }

        return Task.FromResult(timer);
    }
    
    public void Delete(TimerRepositoryDeleteParams payload)
    {
        throw new Exception("Not Implemented");
    }
}