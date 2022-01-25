using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Skunk.Utility;

namespace Skunk
{
    public class Game
    {        
        public Player player1 = new Player();
        public Player player2 = new Player();
        public int roundscore = 0;
        public int skunkcount = 0;
        public int die1;
        public int die2;
        public bool playerturn = true;        
        public bool gametype = true;
        public bool overskunks;

        public void RollDice()
        {
            die1 = R.Next(1, 7);
            die2 = R.Next(1, 7);            
        }

        public string CheckScore()
        {
            string output;
            if (die1 == 1 && die2 == 1)
            {
                roundscore = 0;
                skunkcount += 1;
                if (playerturn)
                {
                    player1.Totalscore = 0;
                }
                else
                {
                    player2.Totalscore = 0;
                }
                output = $"You rolled two skunks, your round score and total score are now 0!";
            }
            else if (die1 == 1 || die2 == 1)
            {
                roundscore = 0;
                skunkcount += 1;
                output = $"You rolled a skunk, your round score is now 0!";
            }
            else
            {
                roundscore += (die1 + die2);
                output = $"You rolled {die1} and {die2}, your round score is now {roundscore}";
            }
            return output;
        }

        public bool CheckSkunks()
        {
            if (skunkcount >= 3)
            {
                NextTurn();
                skunkcount = 0;
                return true;
            }
            return false;
        }
            
        public bool CheckMaxScore()
        {
            if (roundscore >= 12)
            {
                roundscore = 12;
                NextTurn();
                return true;
            }
            return false;
        }

        public void NextTurn()
        {
            if (playerturn)
            {
                player1.Totalscore += roundscore;
                roundscore = 0;
                playerturn = false;
            }
            else
            {
                player2.Totalscore += roundscore;
                roundscore = 0;
                playerturn = true;
            }
        }       

        public void GameChange()
        {
            skunkcount = 0;
            if (gametype)
            {
                gametype = false;
            }
            else
            {
                gametype = true;
            }
        }
    }
}
