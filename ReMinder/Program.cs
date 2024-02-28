using Timer.Timer.Domain;

var timer = new LocalTimer("Remind me of this!", "2h10m");

Console.WriteLine(timer.ExecutionDate);