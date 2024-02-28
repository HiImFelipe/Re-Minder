using System.Text.RegularExpressions;

namespace Timer.Timer.Domain;

public class LocalTimer
{
    public string Message { get; set; }
    public string ExecutionDate { get; private set; }
    
    private readonly string[] _timeUnits = ["h", "m", "s"];

    public LocalTimer(string message, string waitDuration)
    {
        Message = message;
        ExecutionDate = CreateExecutionDate(waitDuration);
    }

    private string CreateExecutionDate(string waitDuration)
    {
        const string unitNotFoundError = "Unknown time unit.";
        
        var timeUnitPairs = TransformInputIntoTimeUnitPairs(waitDuration);
        var executionDate = DateTime.Now;
        
        for (var i = 1; i < timeUnitPairs.Count; i++)
        {
            var (currentTimeAmount, currentTimeUnit) = timeUnitPairs[i];
            var (_, previousTimeUnit) = timeUnitPairs[i-1];

            executionDate = currentTimeUnit switch
            {
                "h" => executionDate.AddHours(currentTimeAmount),
                "m" => executionDate.AddMinutes(currentTimeAmount),
                "s" => executionDate.AddSeconds(currentTimeAmount),
                _ => throw new Exception(unitNotFoundError)
            };
            
            if (i == 0) continue;

            var (success, errorMessage) = CheckForUnitOrder(currentTimeUnit, previousTimeUnit);

            if (!success) throw new Exception(errorMessage);
        }
        
        return executionDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    }

    private (bool, string?) CheckForUnitOrder(string currentTimeUnit, string previousTimeUnit)
    {
        const string errorMessage = "Time unit order is wrong.";
        var indexOfCurrentTimeUnit = Array.FindIndex(
            _timeUnits, 
            (timeUnit) => string.Equals(currentTimeUnit, timeUnit)
        );
            
        var indexOfPreviousTimeUnit = Array.FindIndex(
            _timeUnits, 
            (timeUnit) => string.Equals(previousTimeUnit, timeUnit)
        );
        
        Console.WriteLine("previous {0}, current {1}", indexOfPreviousTimeUnit, indexOfCurrentTimeUnit);

        var timeUnitsOrderedIncorrectly = indexOfPreviousTimeUnit > indexOfCurrentTimeUnit;

        return timeUnitsOrderedIncorrectly ? (false, errorMessage) : (true, null);
    }
    
    private static List<(int, string)> TransformInputIntoTimeUnitPairs(string waitDuration)
    {
        List<(int, string)> timeUnitPairs = [];
            
        const string pattern = @"(\d+)(\w)";
        
        foreach (Match match in Regex.Matches(waitDuration, pattern))
        {
            var amount = int.Parse(match.Groups[1].Value);
            var unitType = match.Groups[2].Value;
           
            timeUnitPairs.Add((amount, unitType));
        }

        return timeUnitPairs;
    }
}