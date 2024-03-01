namespace Timer.Timer.Domain.Types;

public class TimerServiceCreateParams
{
    public string Message { get; set; } = null!;
    public string WaitingTime { get; set; } = null!;
}

public class TimerServiceUpdateParams
{
    public string? Message { get; set; }
    public string? WaitingTime { get; set; }
}

public class TimerServiceReadParams
{
    public string Id { get; set; } = null!;
}

public class TimerServiceDeleteParams
{
    public string Id { get; set; } = null!;
}

public interface ITimerService
{
    static abstract ITimerService GetInstance();
    Task<LocalTimer> Create(TimerServiceCreateParams payload);
    Task<LocalTimer> Update(TimerServiceUpdateParams payload);
    Task<LocalTimer> Read(TimerServiceReadParams payload);
    void Delete(TimerServiceDeleteParams payload);
}