using System;
using System.Collections.Generic;
using System.Text;
using static TestProj.Utility;
using static System.Console;

namespace TestProj
{
    class HighLow : Game
    {
        public override void Play()
        {
            InstantiateDeck();
            StartGame();
        }

        public override void StartGame()
        {
            Print("Welcome to High-Low");
            Pause();
            RunGame();
        }

        // Return value of a specific card by index
        int GetCardValue(int cardIndex)
        {
            int val = deck.cards[cardIndex].Value;
            return val;
        }

        // Return true if card 1 is higher than card 0
        bool CheckValues() => GetCardValue(0) < GetCardValue(1);

        // Print instructions
        void PrintGame()
        {
            Print($"Your current score is {player.Score}");
            Print($"The current card is a {PrintValueName(deck.cards[0].Value)} of {deck.cards[0].Suit}");
            Print("Is the next card higher or lower?");
        }

        // Return true or false based on user input
        bool HigherOrLower()
        {
            string input = InputToLower();
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
                Print("I didn't catch that, try again");
                return HigherOrLower();
            }
        }

        // Check advancement of score based on player guess and card value
        void CheckAnswer()
        {
            bool isHigher = CheckValues();
            bool isGuessHigher = HigherOrLower();

            if (isGuessHigher && isHigher || !isGuessHigher && !isHigher)
            {
                player.Score++;
                Print("Correct!");
                Pause();
            }
            else
            {
                Print("Incorrect!");
            }
        }

        // Run game loop while the deck has cards left
        void RunGame()
        {
            while (deck.cards.Count > 0)
            {
                PrintGame();
                CheckAnswer();
                Pause();
                Clear();
                RemoveFirstCard();
            }
        }

        // Remove the first card in the deck
        void RemoveFirstCard()
        {
            deck.cards.RemoveAt(0);
        }
    }
}
