using Timer.Timer.Controllers;
using Timer.Timer.Domain.Types;

var timerController = TimerControllerBuilder.GetInstance();

var timerCreated = await timerController.Create(new TimerControllerCreateParams()
{
    Message = "Remind me of this!", 
    WaitingTime = "2h10m"
});

var timerFound = await timerController.Read(new TimerControllerReadParams()
{
    Id = timerCreated.Id
});

Console.WriteLine(timerFound.ExecutionDate);