using Timer.Timer.Domain;
using Timer.Timer.Domain.Types;
using Timer.Timer.Infrastructure.Repositories;

namespace Timer.Timer.Services;

public sealed class TimerServiceBuilder : ITimerService
{
     private static TimerServiceBuilder? _instance;
     private readonly ITimerRepository _timerRepository;

     private TimerServiceBuilder()
     {
          _timerRepository = InMemoryTimerRepository.GetInstance();
     }

     public static ITimerService GetInstance()
     {
          return _instance ??= new TimerServiceBuilder();
     }
     
     public async Task<LocalTimer> Create(TimerServiceCreateParams payload)
     {
          var timerService = new CreateTimerService(_timerRepository);

          return await timerService.Execute(payload);
     }
     
     public async Task<LocalTimer> Read(TimerServiceReadParams payload)
     {
          var timerService = new ReadTimerService(_timerRepository);

          return await timerService.Execute(payload);
     }
     
     public Task<LocalTimer> Update(TimerServiceUpdateParams payload)
     {
          throw new Exception("Not implemented.");
     }
     
     public void Delete(TimerServiceDeleteParams payload)
     {
          throw new Exception("Not implemented.");
     }
}