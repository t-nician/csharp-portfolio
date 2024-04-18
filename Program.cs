using Conway;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Game game = new Game(10, 10);

Console.WriteLine(game.CountNeighbors(9, 9).ToString());
game.Step();