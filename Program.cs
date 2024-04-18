using Conway;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Game game = new Game(30, 30);


while (true) {
    game.Output();
    game.Step();

    Thread.Sleep(60);
}