Conway.Game game = new Conway.Game(30, 50);


while (true) {
    Console.Clear();
    game.Output();
    game.Step();

    Thread.Sleep(60);
}