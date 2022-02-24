using System;
using System.Collections.Generic;
using System.Text;

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

        void CheckAnswer()
        {

        }

        

    }
}
