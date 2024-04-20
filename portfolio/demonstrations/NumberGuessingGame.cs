namespace NumberGuessingGame;


public class GuessingGameSession {
    const int MINIMUM = 0;
    const int MAXIMUM = 11;

    private int _answerNumber;
    private int _attempts;


    public GuessingGameSession()
    {
        NewAnswer();
    }


    private void NewAnswer()
    {
        _answerNumber = Random.Shared.Next(MINIMUM, MAXIMUM);
        _attempts = 0;
    }


    public void StartGame() 
    {
        while (true)
        {
            int guessedNumber = Input.Ask.IntRange("Guess the number!", MINIMUM, MAXIMUM - 1);

            if (guessedNumber == _answerNumber)
            {
                Console.Clear();
                Console.WriteLine("Correct! The number was " + _answerNumber.ToString() + "!\nIt took you " + _attempts.ToString() + " attempt(s)!");
                Thread.Sleep(2000);

                NewAnswer();
            } else {
                _attempts += 1;
            }
        }
    }
}