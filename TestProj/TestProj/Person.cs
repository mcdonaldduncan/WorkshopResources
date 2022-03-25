using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class Person
    {
        private string name;
        private int score;

        public Queue<Card> queue = new Queue<Card>();

        public Stack<Card> stack = new Stack<Card>();

        public List<Card> hand = new List<Card>();

        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
    }
}
