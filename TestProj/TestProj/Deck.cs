using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TestProj.Utility;

namespace TestProj
{
    class Deck
    {
        private string[] suits = {"Diamonds", "Hearts", "Clubs", "Spades"};
        private int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        public List<Card> cards = new List<Card>();

        // Generate a deck of cards based on suit and values
        public void AssembleDeck()
        {
            for (int i = 0; i < suits.Length; i++)
            {
                for (int n = 0; n < values.Length; n++)
                {
                    cards.Add(new Card(values[n], suits[i]));
                }
            }
        }

        // Print entire deck to console
        public void PrintCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{cards[i].Value} of {cards[i].Suit}");
            }
        }

        // Randomly order cards into a shuffled list
        public void Shuffle()
        {
            cards = cards.OrderBy(x => random.Next()).ToList();
        }

    }
}
