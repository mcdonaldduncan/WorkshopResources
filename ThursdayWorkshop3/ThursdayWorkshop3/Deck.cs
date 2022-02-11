using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayWorkshop3
{
    class Deck
    {
        List<string> suits = new List<string>()
        {
            "Diamonds", "Hearts", "Spades", "Clubs"
        };

        List<int> values = new List<int>()
        {
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
        };

        List<Card> cards = new List<Card>();


        public void BuildDeck()
        {
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    Card card = new Card(suit, value);
                    cards.Add(card);
                }
            }
        }

    }
}
