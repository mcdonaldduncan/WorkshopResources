using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MagicPuppets.Utility;
using static MagicPuppets.DataLoad;
using static MagicPuppets.Display;
using static System.Console;

namespace MagicPuppets
{

    public class Game
    {
        Player player = new Player();
        Supplier supplier = new Supplier();
        Customer customer = new Customer();
        double initialFunds = 20;
        double baseValue = 15;
        bool retry = true;

        List <Puppet> puppets = new List<Puppet>();

        List<string> materialinventory = new List<string>()
        {
            "sock", "googlyeye", "pompom","pipecleaner", "toothpick", "felt", "glitter", "hay", "vynil", "mitten", "pebbles", "string"
        };
        

        List<Puppet> puppetinventory = new List<Puppet>()
        {
            new Puppet{Name = "Legendary Liopleurodon", Value = 25}
        };

        public int SellOption()
        {
            int numberInput;
            Print($"Select the item you wish to sell, enter your response as a number.\nCurrent Funds: ${Math.Round(player.funds, 2)}");
            int index = 0;
            foreach (Item i in puppetinventory)
            {
                Print($"{index}: {i.Name}, ${Math.Round(i.Value, 2)}");
                index++;

            }
            string response = ReadLine();
            numberInput = Convert.ToInt32(response);
            return numberInput;
        }

        public void Sell()
        {
            int numberInput = SellOption();
            Print($"Congratulations! You sold a {puppetinventory[numberInput].Name} for ${Math.Round(puppetinventory[numberInput].Value, 2)}.\nTotal Profit on puppet: ${Math.Round(puppetinventory[numberInput].Value - baseValue, 2)}");
            //profit %
            double profit = puppetinventory[numberInput].Value - baseValue;
            double percentProfit = Math.Round((profit / puppetinventory[numberInput].Value) * 100, 2);
            Print($"\nProfit Margin: {percentProfit}%\n");
            player.funds += puppetinventory[numberInput].Value;
            ReadKey();
            puppetinventory.Remove(puppetinventory[numberInput]);
            
        }

        public int BuyOption()
        {
            int numberInput;
            Print($"Select the item you wish to purchase, enter your response as a number.\nCurrent Funds: ${Math.Round(player.funds, 2)}");
            int index = 0;
            foreach (Item i in supplier.supplies)
            {
                Print($"{index}: {i.Name}, ${i.Value}");
                index++;

            }
            string response = ReadLine();
            numberInput = Convert.ToInt32(response);
            return numberInput;
        }

        public bool CanBuy(int numberInput)
        {
            if (player.funds >= supplier.supplies[numberInput].Value)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void Purchase()
        {
            int numberInput = BuyOption();
            if (CanBuy(numberInput))
            {
                Print($"Congrats, you purchased a {supplier.supplies[numberInput].Name}");
                ReadKey();
                materialinventory.Add(supplier.supplies[numberInput].Name);
                supplier.supplies.Remove(supplier.supplies[numberInput]);
                player.funds = player.funds - supplier.supplies[numberInput].Value;
            }
            else
            {
                Print("You do not have the necessary funds.");
                ReadKey();  
            }
        }

        public int BuildChoice()
        {
            int index = 0;
            Print("Which puppet would you like to make today?");
            foreach (Puppet puppet in puppets)
            {
       
                Print($"{index} " + puppet.Name + Environment.NewLine);
                index++;

            }
            try
            {
                string puppetResponse = ReadLine();
                puppetResponse = puppetResponse.ToLower();
                int numberInput = Convert.ToInt32(puppetResponse);
                return numberInput;
            }
            catch (Exception)
            {
                Print("Please input your response as a number.");
                Console.ReadKey();
                Print("Which puppet would you like to make today?");
                index = 0;
                foreach (Puppet puppet in puppets)
                {

                    Print($"{index} " + puppet.Name + Environment.NewLine);
                    index++;

                }
                string puppetResponse = Console.ReadLine();
                puppetResponse = puppetResponse.ToLower();
                int numberInput = Convert.ToInt32(puppetResponse);
                return numberInput;
            }
            
        }

        public Boolean CanBuild(int numberInput)
        {
            Print($"You have chosen {puppets[numberInput].Name}");
            Console.ReadKey();
            if (materialinventory.Contains(puppets[numberInput].Material1) && materialinventory.Contains(puppets[numberInput].Material2) && materialinventory.Contains(puppets[numberInput].Material3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Assemble(int numberInput)
        {
            if (CanBuild(numberInput))
            {
                puppetinventory.Add(puppets[numberInput]);
                materialinventory.Remove(puppets[numberInput].Material1);
                materialinventory.Remove(puppets[numberInput].Material2);
                materialinventory.Remove(puppets[numberInput].Material3);
                int rarityModifier = RandomNumber.Next(1,10);
                if (rarityModifier > 3)
                {
                    puppets[numberInput].Rarity = "common";
                    puppets[numberInput].Value = puppets[numberInput].Value * 1.1f;
                }
                else if (rarityModifier == 2 || rarityModifier == 3)
                {
                    puppets[numberInput].Rarity = "uncommon";
                    puppets[numberInput].Value = puppets[numberInput].Value * 1.2f;
                }
                else
                {
                    puppets[numberInput].Rarity = "rare";
                    puppets[numberInput].Value = puppets[numberInput].Value * 1.5f;
                }

                Print($"You have built a {puppets[numberInput].Name}!");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Print($"You cannot build a {puppets[numberInput].Name}, you are missing required materials!");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public void MainMenu()
        {
            Print = PrintCommandLine;
            puppets = LoadXML("../../Data/puppets.xml");
            string menuInput = "";
            Print($"Welcome Player!");
            ReadKey();
            Clear();

            while (retry)
            {
                retry = true;
                Print("Make your selection\n");
                Print("A: View Inventory\nB: View Recipes\nC: Make Puppets\nD: Sell Puppets\nE: Shop Materials\nF: Exit");
                menuInput = ReadLine();
                menuInput = menuInput.ToLower();
                Clear();
                switch (menuInput)
                {
                    case "a":
                        Inventory();
                        ReadKey();
                        Clear();
                        break;
                    case "b":
                        Print(ViewRecipes());
                        ReadKey();
                        Clear();
                        break;
                    case "c":
                        Assemble(BuildChoice());
                        break;
                    case "f":
                        retry = false;
                        break;
                    case "e":
                        Purchase();
                        Clear();
                        break;
                    case "d":
                        Sell();
                        Clear();
                        break;
                    default:
                        Print("I'm sorry, maybe the directions weren't clear. Read carefully and try again!");
                        retry = true;
                        break;
                }

            }


        }

        public string ViewRecipes()
        {
            string recipelist = "";
            foreach (Puppet puppet in puppets)
            {
                recipelist += $"{puppet.Name} Recipe: {puppet.Material1}, {puppet.Material2}, {puppet.Material3}\n";

            }
            return recipelist;
        }

        public void Inventory()
        {
            Print($"Current Funds: ${player.funds}\nTotal Profit/Loss: ${player.funds - initialFunds}");
            Print("Puppets\n");
            foreach (Puppet i in puppetinventory)
            {
                Print($"{i.Name} : {i.Rarity}");
            }
            Print("\nMaterials\n");
            foreach (string n in materialinventory)
            {
                Print($"{n}");
            }
        }




        // - supplier.supplies.[supplier.supplies.IndexOf(supplier.supplies.Name, puppetinventory[numberInput].material1)].value

        /*public void Continue()
        {
            while (retry)
            {

            }
            string exitInput;
            Print("A: Return to main menu\nB: Exit");
            exitInput = Console.ReadLine();
            exitInput = exitInput.ToLower();
            switch (exitInput)
            {
                case "a":
                    break;
                case "b":
                    break;
                default:
                    break;
            }
        }*/

        //// new Puppet{Name = "Zebra", material1 = "sock", material2 = "googlyeye", material3 = "pompom", value = 15},
        //new Puppet{Name = "Crocodile", material1 = "pipecleaner", material2 = "toothpick", material3 = "felt", value = 15},
        //    new Puppet{Name = "Lion", material1 = "glitter", material2 = "hay", material3 = "vynil", value = 15},
        //    new Puppet { Name = "Hippo", material1 = "mitten", material2 = "pebbles", material3 = "string", value = 15 }
    }
}