using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class MonopolyGame
    {

        public static List<Player> players = new List<Player>();
        private static Board board = new Board();

        private static Random random = new Random();
        public static void Main(string[] args)
        {
            
                StartGame();
            

            while (players.Count > 1)
            {
                List<Player> playersToRemove = new List<Player>();

                foreach (Player player in players.ToList()) 
                {
                    PlayerTurn(player);
             
                    if (player.IsEliminated)
                    {
                        playersToRemove.Add(player);
                        foreach(Property p in player.OwnedProperties)
                        {
                            p.Owner = null;
                            if(p is RealEstateTile realEstate)
                            {
                                realEstate.HouseCount = 0;
                            }
                   //         p.IsOwned = false;
                        }
                        player.OwnedProperties.Clear();
                        break;
                    }
                    
                }

             
                foreach (Player playerToRemove in playersToRemove) //remove eliminated player after finishing the turn
                {
                    players.Remove(playerToRemove);
                }

                if (players.Count == 1)
                {
                    break; //exit if 1 player left only
                }
            }

            if (players.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player {players[0].Name} won the game!");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Monopoly!");

            int playerCount = GetNumberOfPlayers();

            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Enter {i + 1}. player name:");
                string name = Console.ReadLine();
                ConsoleColor color = GetPlayerColor(i);

                Player p = new Player(name, color);
                players.Add(p);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Players in the game:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Player: {players[i].Name}");
            }
            Console.ResetColor();

            
            DecideWhoStarts();
        }

        private static ConsoleColor GetPlayerColor(int index)
        {
            ConsoleColor[] playerColors = { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow };
            return playerColors[index % playerColors.Length];
        }


        public static void DecideWhoStarts()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rolling the dice to decide who starts...");
            

            int maxRoll = 0;
            Player startingPlayer = null;

            foreach (Player player in players)
            {
           //     int roll = RollDice();
                int roll = random.Next(1, 7);

                Console.WriteLine($"{player.Name} rolled {roll}");

                if (roll > maxRoll || startingPlayer == null)
                {
                    maxRoll = roll;
                    startingPlayer = player;
                }
            }

            Console.WriteLine($"{startingPlayer.Name} starts the game!");
            // Set the starting player to be the first in the list
            players.Remove(startingPlayer);
            players.Insert(0, startingPlayer);
            Console.ResetColor();
        }

        private static void PlayerTurn(Player player)
        {
            if (!(player.turnSkipCount > 0))
            {
                int diceRoll = 0;
                //View of the board (Functional requirement 6) 
                board.DisplayBoardView();
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.ForegroundColor = player.GetColor();
                Console.WriteLine($"{player.Name}'s turn:");
               
                Console.ResetColor();
                
                while (true)
                {
                    Console.ForegroundColor = player.GetColor();
                    Console.WriteLine(" ");                  
                    Console.WriteLine("1. Display properties and balances of all players"); //(Functional requirement 7) 
                    Console.WriteLine("2. Roll the dice");
                    Console.Write("Enter your choice (1 or 2): ");
                    Console.ResetColor();
                    string input1 = Console.ReadLine();

                    if (int.TryParse(input1, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                DisplayPropertiesAndBalances();
                                //   goto case 2;
                                continue;

                            case 2:
                                diceRoll = RollDice();
                                Console.WriteLine("");
                                Console.WriteLine($"{player.Name} rolled {diceRoll}");
                                break;

                         /*   case 3://for testing
                                SetPlayerPosition(player);
                                break; */

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                                Console.ResetColor();
                                continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        Console.ResetColor();
                    }
                }

                //move player by dice roll
                player.MovePlayer(diceRoll);
                BoardTile currentTile = board.Tiles[player.Position];
                Console.WriteLine($"Landed on {currentTile.Name}");
                Console.WriteLine("");
                currentTile.PerformAction(player);
                Console.WriteLine($"End of {player.Name}'s turn.");
                Console.WriteLine("");

            }
            else
            {
                player.turnSkipCount--;
                Console.WriteLine($"{player.Name} is currently in jail. Turn skips left: {player.turnSkipCount}.");
            }

        }

        private static int GetNumberOfPlayers()
        {
            int numberOfPlayers;

            while (true)
            {
                Console.WriteLine("Enter the number of players (2-4): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out numberOfPlayers) && numberOfPlayers >= 2 && numberOfPlayers <= 4)
                {
                    return numberOfPlayers;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number between 2 and 4.");
                    Console.ResetColor();
                }
            }
        }

        private static int RollDice()
        {
       //     Random random = new Random();
            return random.Next(1, 7) + random.Next(1, 7);
        }



        private static void DisplayPropertiesAndBalances()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Displaying properties and balances of all players...");
            Console.ResetColor();
       
            foreach (Player p in players)
            {
                Console.ForegroundColor = p.GetColor();
                Console.WriteLine($"Player {p.Name} has {p.Balance} money");
                foreach (Property property in p.OwnedProperties)
                {
                    Console.Write($"Player {p.Name} has {property.Name} located in tile {property.Position}=> Cost: {property.Cost}, Rent: ");


                    if (property is RealEstateTile realEstate)
                    {
                        Console.Write($"{realEstate.CalculateRent()} ");
                        Console.WriteLine($"Houses built: {realEstate.HouseCount}");
                    }

                    else if (property is TrainStationTile trainStation)
                    {
                        Console.Write($"{trainStation.CalculateRent()} ");
                        Console.WriteLine($"Stations owned: {p.StationsBought}");
                    }
                    else if(property is UtilityTile utility)
                    {
                        Console.WriteLine($"Utilities owned: {p.UtilityBought}");
                    }
                   
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
   /*     private static void SetPlayerPosition(Player pl) //For testing
        {
          
            {
                Console.Write($"Enter the new position for {pl.Name}: ");
                if (int.TryParse(Console.ReadLine(), out int newPosition))
                {
                    pl.Position = newPosition % board.TotalTiles;
                    Console.WriteLine($"{pl.Name}'s position set to {pl.Position}. tile");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid position.");
                    Console.ResetColor();
                }
            }
        } */

    }
}

