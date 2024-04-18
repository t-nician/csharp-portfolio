/*Conway.Game game = new Conway.Game(30, 50);


while (true) {
    Console.Clear();
    game.Output();
    game.Step();

    Thread.Sleep(60);
}
*/

while (true) {
    var demo_options = new List<string>() { 
        "Conways Game of Life",
    };

    switch (Inputter.Ask.Choice("Choose Demonstration", demo_options)) {
        case "conwaysgameoflife":
            var game = new Conway.Game(10, 30);

            while (true) {
                game.Step();
                game.Output();

                Thread.Sleep(60);
            }

            break;
        
        
    }
}