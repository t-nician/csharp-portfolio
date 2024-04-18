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
            new Conway.Game(10, 30).Loop(60);
            break;

        
    }
}