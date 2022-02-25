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


        }
        
        int GetCardValue(int cardIndex)
        {
            int val;

            val = deck.cards[cardIndex].Value;

            return val;
        }

        bool CheckAnswer()
        {
            return GetCardValue(0) > GetCardValue(1);
        }

        void PrintGame()
        {
            Print($"You have pulled a {deck.cards[0].Value} of {deck.cards[0].Suit}");
            Print("Is the next card higher or lower?");
        }

        bool PlayerInput()
        {

            
            
            return true;
        }
    }
}
