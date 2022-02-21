using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class Card
    {
        private int value;
        private string suit;

        public int Value { get => value; set => this.value = value; }
        public string Suit { get => suit; set => suit = value; }

        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
        }

    }
}
