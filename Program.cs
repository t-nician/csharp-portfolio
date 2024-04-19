﻿var demo_options = new List<string>() { 
    "Conways Game of Life",
    "Number Guessing Game",
    "Account Database",
    "Blackjack"
};


while (true) {
    switch (Inputter.Ask.Choice("Choose Demonstration", demo_options)) {
        case "conwaysgameoflife":
            new Conway.Game(
                Inputter.Ask.IntMinMax("Provide game width.", 5, 10), 
                Inputter.Ask.IntMinMax("Provide game height.", 5, 30)
            ).Loop(
                Inputter.Ask.IntMinMax("Input delay(miliseconds) for each game update.", 50, 500)
            );
            break;


        case "numberguessinggame":
            new NumberGuessing.Game(
                Inputter.Ask.IntMinMax("Maximum number for guessing game.", 5, 10)
            ).Loop();
            break;
        
        case "blackjack":
            new Blackjack.Game().Loop();
            break;


        case "accountdatabase":
            
            break;
    }
}