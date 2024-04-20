namespace NumberGuessingGame;


public class GuessingGameSession {
    private int _minimumNumber;
    private int _maximumNumber;

    private int _answerNumber;
    private int _attempts;


    public GuessingGameSession(int minimum, int maximum)
    {
        _minimumNumber = minimum;
        _maximumNumber = maximum;

        NewAnswer();
    }


    private void NewAnswer()
    {
        _answerNumber = Random.Shared.Next(_minimumNumber, _maximumNumber);
        _attempts = 0;
    }


    public void StartGame() 
    {
        while (true)
        {
            int guessedNumber = Input.Ask.IntRange("Guess the number!", _minimumNumber, _maximumNumber - 1);

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