namespace Timer.Timer.Domain.Types;

public class TimerControllerCreateParams
{
    public string Message { get; set; } = null!;
    public string WaitingTime { get; set; } = null!;
}

public class TimerControllerUpdateParams
{
    public string? Message { get; set; }
    public string? WaitingTime { get; set; }
}

public class TimerControllerReadParams
{
    public string Id { get; set; } = null!;
}

public class TimerControllerDeleteParams
{
    public string Id { get; set; } = null!;
}

public interface ITimerController
{
    static abstract ITimerController GetInstance();
    Task<LocalTimer> Create(TimerControllerCreateParams payload);
    Task<LocalTimer> Update(TimerControllerUpdateParams payload);
    Task<LocalTimer> Read(TimerControllerReadParams payload);
    void Delete(TimerControllerDeleteParams payload);
}