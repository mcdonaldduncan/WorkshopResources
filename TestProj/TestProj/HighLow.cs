using System;
using System.Collections.Generic;
using System.Text;
using static TestProj.Utility;

namespace TestProj
{
    class HighLow : Game
    {
        public override void Play()
        {
            InstantiateDeck();
            StartGame();
        }
        
        int GetCardValue(int cardIndex)
        {
            int val = deck.cards[cardIndex].Value;
            return val;
        }

        bool CheckValues()
        {
            return GetCardValue(0) < GetCardValue(1);
        }

        void StartGame()
        {
            Print("Welcome to High-Low");
            Pause();
            RunGame();
        }

        void PrintGame()
        {
            Print($"Your current score is {player.score}");
            Print($"The current card is a {deck.cards[0].Value} of {deck.cards[0].Suit}");
            Print("Is the next card higher or lower?");
        }

        bool PlayerInput()
        {
            string input = Console.ReadLine().ToLower();
            if (input == "h" || input == "high" || input == "higher")
            {
                return true;
            }
            else if (input == "l" || input == "low" || input == "lower")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't catch that, try again");
                return PlayerInput();
            }
        }

        void CheckAnswer()
        {
            bool isHigher = CheckValues();
            bool isGuessHigher = PlayerInput();

            if (isGuessHigher && isHigher || !isGuessHigher && !isHigher)
            {
                player.score++;
                Print("Correct!");
                Pause();
            }
            else
            {
                Print("Incorrect!");
            }
        }

        void RunGame()
        {
            while (deck.cards.Count > 0)
            {
                PrintGame();
                CheckAnswer();
                RemoveFirstCard();
            }
        }

        void RemoveFirstCard()
        {
            deck.cards.RemoveAt(0);
        }
    }
}
