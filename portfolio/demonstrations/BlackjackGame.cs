namespace Blackjack;


public enum CardType {
    Normal,
    Ace
}


public class Card {
    private CardType _type;
    private int _value;

    public Card(CardType type, int value) {
        _type = type;
        _value = value;
    }


    public CardType GetCardType() {
        return _type;
    }

    public int GetCardValue() {
        return _value;
    }
}


public class Hand {
    private Random _random;
    private List<Card> _cards;
    private int _min_hand_value;
    private int _max_hand_value;


    public Hand() {
        _random = new Random();
        _cards = new List<Card>();

        _min_hand_value = 0;
        _max_hand_value = 0;
    }


    public Card AddCard() {
        Card card;

        if (_random.Next(0, 16) == 1) {
            card = new Card(CardType.Ace, 1);
        } else {
            card = new Card(CardType.Normal, _random.Next(1, 11));
        }

        _cards.Add(card);

        UpdateHandValue();

        return card;
    }


    public (int, int) GetHandValue() {
        return (_min_hand_value, _max_hand_value);
    }


    private void UpdateHandValue() {
        var (min_value, max_value) = (0, 0);

        foreach (Card card in _cards) {
            if (card.GetCardType() == CardType.Normal) {
                min_value += card.GetCardValue();
                max_value += card.GetCardValue();
            } else {
                min_value += 1;
                max_value += 11;
            }
        }

        _min_hand_value = min_value;
        _max_hand_value = max_value;
    }
}


class DealerAI {
    private Hand _dealer_hand;
    private Hand _player_hand;

    public DealerAI(Hand dealer_hand, Hand player_hand) {
        _dealer_hand = dealer_hand;
        _player_hand = player_hand;
    }


    public bool Play() {

        return false;
    }
}


public class Game {
    private Hand _player_hand;
    private Hand _dealer_hand;
    private DealerAI _dealer_ai;


    public Game() {
        _player_hand = new Hand();
        _dealer_hand = new Hand();

        _dealer_ai = new DealerAI(_dealer_hand, _player_hand);
    }


    public void Loop() {
        while (true) {
            var (min, max) = _player_hand.GetHandValue();

            Console.Clear();
            Console.WriteLine("Current Hand\nMinimum Value: " + min.ToString() + "\nMaximum Value: " + max.ToString());

            var hit = Inputter.Ask.Choice(
                "[Your Hand]\nMinimum Value: " + min.ToString() + "\nMaximum Value: " + max.ToString() + "\n\nChoose your move.\n", new List<string>() { "Hit", "Stand" });

            if (hit == "hit") {
                _player_hand.AddCard();

                (min, _) = _player_hand.GetHandValue();

                if (min > 21) {
                    Console.Clear();
                    Console.WriteLine("Bust! You went over 21 points.\nYou had: " + min.ToString());

                    Thread.Sleep(5000);

                    break;
                }
            } else if (hit == "stand") {
                _dealer_ai.Play();
            }
            
        }
    }
}