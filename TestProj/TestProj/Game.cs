using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class Game
    {
        public Deck deck = new Deck();

        public void InstantiateDeck()
        {
            deck.AssembleDeck();
            deck.Shuffle();
        }

        public virtual void Play()
        {
            
        }
    }
}
