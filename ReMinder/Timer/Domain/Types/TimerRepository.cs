namespace Timer.Timer.Domain.Types;

public class TimerRepositoryCreateParams
{
    public string Message { get; set; } = null!;
    public string WaitingTime { get; set; } = null!;
}

public class TimerRepositoryUpdateParams
{
    public string? Message { get; set; }
    public string? WaitingTime { get; set; }
}

public class TimerRepositoryReadParams
{
    public string Id { get; set; } = null!;
}

public class TimerRepositoryDeleteParams
{
    public string Id { get; set; } = null!;
}

public interface ITimerRepository
{
    static abstract ITimerRepository GetInstance();
    Task<LocalTimer> Create(TimerRepositoryCreateParams payload);
    Task<LocalTimer> Update(TimerRepositoryUpdateParams payload);
    Task<LocalTimer> Read(TimerRepositoryReadParams payload);
    void Delete(TimerRepositoryDeleteParams payload);
}