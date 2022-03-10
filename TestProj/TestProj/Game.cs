using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class Game
    {
        public Deck deck = new Deck();
        public Player player = new Player();
        public Dealer dealer = new Dealer();

        // Assemble and shuffle deck
        public void InstantiateDeck()
        {
            deck.AssembleDeck();
            deck.Shuffle();
        }

        // Play method to be overridden
        public virtual void Play()
        {
            
        }

        // Start method to be overridden
        public virtual void StartGame()
        {

        }
    }
}
