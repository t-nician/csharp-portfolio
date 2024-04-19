namespace NumberGuessing;


public class Game {
    private int _attempts;
    private int _maximum;
    private int _answer;

    private Random _random;

    public Game(int maximum) {
        _random = new Random();
        _maximum = maximum;

        NewAnswer();
    }


    private void NewAnswer() {
        _answer = _random.Next(0, _maximum);
        _attempts = 0;
    }


    public bool Guess(int number) {
        return _answer == number;
    }


    public void Loop() {
        while (true) {
            bool correct = Guess(
                Inputter.Ask.IntMinMax("Guess the number!", 0, _maximum)
            );

            if (correct) {
                Console.WriteLine("The number was " + _answer.ToString() + "!\nIt took " + _attempts.ToString() + " attempt(s)!");
                
                Thread.Sleep(5000);

                if (!Inputter.Ask.YesNo("Continue the guessing game?")) {
                    break;
                }

                NewAnswer();
            } else {
                _attempts += 1;
            }
        }
    }
}