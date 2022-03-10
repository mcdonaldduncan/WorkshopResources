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
        void DealInitialHands()
        {
            DealCardFromDeck(player);
            DealCardFromDeck(dealer);
            DealCardFromDeck(player);
            DealCardFromDeck(dealer);
        }

        // Deal the first card in the deck to the player hand
        void DealCardFromDeck(Person subject)
        {
            subject.hand.Add(deck.cards[0]);
            deck.cards.RemoveAt(0);
        }

        // Sum the values of all cards in hand
        int SumHand(Person subject)
        {
            int handSum = 0;
            for (int i = 0; i < subject.hand.Count; i++)
            {
                handSum += subject.hand[i].Value;
            }
            return handSum;
        }

        // print all cards in hand to console
        void PrintPlayerHand()
        {
            Print("Current Hand:");
            for (int i = 0; i < player.hand.Count; i++)
            {
                Print($"{PrintValueName(player.hand[i].Value)} of {player.hand[i].Suit}\n");
            }
            Print($"Hand value is {SumHand(player)}");
        }

        // If the hand sum is over 21, convert any aces to be low
        void CheckForAces(Person subject, int handSum)
        {
            if (handSum <= 21)
                return;
            for (int i = 0; i < subject.hand.Count; i++)
            {
                if (subject.hand[i].Value == 14)
                {
                    subject.hand[i].Value = 1;
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
                Clear();
                Print("I didnt catch that, try again");
                return HitOrPass();
            }

        }
    }
}
