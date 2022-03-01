using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class Game
    {
        public Deck deck = new Deck();
        public Player player = new Player();

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
