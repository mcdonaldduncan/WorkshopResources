using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Skunk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            WriteTurn();
            AssignTotals();
            WriteGameType();
        }

        
        Game game = new Game();

        public void PrintDice()
        {
            game.RollDice();
            die1block.Text = $"{game.die1}";
            die2block.Text = $"{game.die2}";
        }

        public void WriteScore(string output)
        {
            roundscoreblock.Text = output;

        }

        private void RolldiceButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDice();
            WriteScore(game.CheckScore());            
            if (game.gametype)
            {
                WriteSkunks(game.CheckSkunks());
            }
            else
            {
                WriteMaxScore(game.CheckMaxScore());   
            }
            WriteTurn();
            AssignTotals();
            Win();
        }

        private void EndturnButton_Click(object sender, RoutedEventArgs e)
        {
            game.NextTurn();
            AssignTotals();
            Win();
            WriteTurn();


        }

        public void AssignTotals()
        {
            player1total.Text = game.player1.Totalscore.ToString();
            player2total.Text = game.player2.Totalscore.ToString();
        }

        public void Win()
        {
            
            if (game.player1.Totalscore >= 100)
            {
                roundscoreblock.Text = "Player1 Wins!";
                EndGame.Visibility = Visibility.Visible;
                WinnerBlock.Visibility = Visibility.Visible;
                WinnerBlock.Text = "Player1 Wins!";
            }
            if (game.player2.Totalscore >= 100)
            {
                roundscoreblock.Text = "Player2 Wins!";
                EndGame.Visibility = Visibility.Visible;
                WinnerBlock.Visibility = Visibility.Visible;
                WinnerBlock.Text = "Player2 Wins!";

            }
            
        }

        public void WriteSkunks(bool b)
        {
            if (b)
            {
                roundscoreblock.Text = "Three skunks, next turn!";
                
            }
        }

        public void WriteTurn()
        {
            if (game.playerturn)
            {
                playerturnblock.Text = "Player1 Turn";
            }
            else
            {
                playerturnblock.Text = "Player2 Turn";
            }
            
        }

        public void WriteMaxScore(bool b)
        {
            if (b)
            {
                roundscoreblock.Text = "Maximum round score reached, next turn.";
            }
        }

        

        public void WriteGameType()
        {
            if (game.gametype)
            {
                GameTypeBlock.Text = "Currently Playing: Three Skunks";
            }
            else
            {
                GameTypeBlock.Text = "Currently Playing: Max Round";
            }
            

        }

        private void GameChange_Click(object sender, RoutedEventArgs e)
        {
            game.GameChange();
            WriteGameType();

        }
    }
}
