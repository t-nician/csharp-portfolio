string response = Input.Ask.Options(
    "Select a demonstration...", 
    new List<string>() 
    { 
        "Number Guessing Game",
    }
);

switch (response) 
{
    case "Number Guessing Game":
        new NumberGuessingGame.GuessingGameSession(0, 11).StartGame(); break;
    
    
}