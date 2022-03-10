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

        // Deal initial hand by dealing two cards from deck
        void DealHand()
        {
            DealCardFromDeck();
            DealCardFromDeck();
        }

        // Deal the first card in the deck to the player hand
        void DealCardFromDeck()
        {
            hand.Add(deck.cards[0]);
            deck.cards.RemoveAt(0);
        }

        // Sum the values of all cards in hand
        int SumHand()
        {
            int handSum = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                handSum += hand[i].Value;
            }
            return handSum;
        }

        // print all cards in hand to console
        void PrintHand()
        {
            Print("Current Hand:");
            for (int i = 0; i < hand.Count; i++)
            {
                Print($"{PrintValueName(hand[i].Value)} of {hand[i].Suit}\n");
            }
            Print($"Hand value is {SumHand()}");
        }

        // If the hand sum is over 21, convert any aces to be low
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

        // Take player input and return true/false based on answer
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
                Pause();
                Clear();
                return HitOrPass();
            }

        }
    }
}
