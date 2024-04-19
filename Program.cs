/*Conway.Game game = new Conway.Game(30, 50);


while (true) {
    Console.Clear();
    game.Output();
    game.Step();

    Thread.Sleep(60);
}
*/

var demo_options = new List<string>() { 
    "Conways Game of Life",
};


while (true) {
    switch (Inputter.Ask.Choice("Choose Demonstration", demo_options)) {
        case "conwaysgameoflife":
            new Conway.Game(
                Inputter.Ask.IntMinMax("Provide game width.", 5, 10), 
                Inputter.Ask.IntMinMax("Provide game height.", 10, 30)
            ).Loop(
                Inputter.Ask.IntMinMax("Input delay(miliseconds) for each game update.", 30, 1000)
            );
            break;

        
    }
}