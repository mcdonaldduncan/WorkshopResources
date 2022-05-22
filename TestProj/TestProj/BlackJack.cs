using System;
using System.Collections.Generic;
using System.Text;
using static TestProj.Utility;
using static System.Console;

namespace TestProj
{
    class BlackJack : Game
    {
        int aceValueHigh = 11;
        int aceValueLow = 1;
        int faceValue = 10;

        public override void Play()
        {
            InstantiateDeck();
            RunGame();
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

        // Sum the corrected values of all cards in hand
        int SumHand(Person subject)
        {
            CheckForAces(subject, SumHand(subject));
            int handSum = 0;
            for (int i = 0; i < subject.hand.Count; i++)
            {
                if (subject.hand[i].Value == 14)
                {
                    handSum += aceValueHigh;
                }
                else if (subject.hand[i].Value > 10)
                {
                    handSum += faceValue;
                }
                else
                {
                    handSum += subject.hand[i].Value;
                }
            }
            return handSum;
        }

        void PrintHandSum(Person subject)
        {
            Print($"The value of your hand is {SumHand(subject)}");
        }

        // Print all cards in hand to console
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
                    subject.hand[i].Value = aceValueLow;
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
            else if (playerInput == "n" || playerInput == "no" || playerInput == "pass" || playerInput == "stand")
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

        //bool CheckDealerNatural()
        //{
        //    if (dealer.hand[0].Value >= faceValue)
        //    {

        //    }
        //}

        //void CheckDealerHit()
        //{
        //    if (dealer.hand[0].Value )
        //    {

        //    }
        //}

        void RunGame()
        {
            DealInitialHands();
        }

        void BlackJackHand()
        {

        }

        void Bust()
        {

        }

        void PlayerTurn()
        {
            // While hand is less than 21 print hand and check for hit. On pass, exit loop
            while (SumHand(player) < 21)
            {
                // Print the cards in the hand
                PrintPlayerHand();

                Pause();

                // Request a hit or pass, 
                if (HitOrPass())
                {
                    DealCardFromDeck(player);
                }
                else
                {
                    break;
                }
            }

            // If player hand equals 21 player has blackjack, else player busts
            if (SumHand(player) == 21)
            {
                PrintPlayerHand();
                BlackJackHand();
            }
            else if (SumHand(player) > 21)
            {
                PrintPlayerHand();
                Bust();
            }
        }
    }
}
