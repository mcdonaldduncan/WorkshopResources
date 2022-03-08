using System;
using System.Collections.Generic;
using System.Text;
using static TestProj.Utility;
using static System.Console;

namespace TestProj
{
    class BlackJack : Game
    {
        public override void Play()
        {
            InstantiateDeck();

        }

        public override void StartGame()
        {
            Print("Welcome to BlackJack");


        }

        void DealHand()
        {
            DealCardFromDeck();
            DealCardFromDeck();
        }

        void DealCardFromDeck()
        {
            hand.Add(deck.cards[0]);
            deck.cards.RemoveAt(0);
        }

        void PrintHand()
        {
            int handSum = 0;
            Print("Current Hand:");
            for (int i = 0; i < hand.Count; i++)
            {
                Print($"{PrintValueName(hand[i].Value)} of {hand[i].Suit}\n");
                handSum += hand[i].Value;
            }
        }

        void CheckForAces(int handSum)
        {
            if (handSum <= 21)
                return;
            for (int i = 0; i < hand.Count; i++)
            {
                if (hand[i].Value == 14)
                {
                    hand[i].Value = 1;
                }
            }
        }

        bool HitOrPass()
        {
            Print("Would you like another card?");
            string playerInput = InputToLower();

            if (playerInput == "y" || playerInput == "yes" || playerInput == "hit")
            {
                return true;
            }
            else if (playerInput == "n" || playerInput == "no" || playerInput == "pass")
            {
                return false;
            }
            else
            {
                Print("I didnt catch that, try again");
                Clear();
                return HitOrPass();
            }

        }
    }
}
