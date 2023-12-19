using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class MonopolyGame
    {

        public static List<Player> players = new List<Player>();
        private static Board board = new Board();
        public static void Main(string[] args)
        {
            StartGame();

            while (players.Count > 1) //there are at least 2 players still playing
            {
                foreach (Player player in players) //players get their turn in order
                {
                    PlayerTurn(player);

                }
            }


        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Monopoly!");

            int playerCount = GetNumberOfPlayers();

            for (int i = 0; i < playerCount; i++)
            {
                // players.Add(new Player($"Player {i + 1}"));
                Console.WriteLine($"Enter {i + 1}. player name:");
                string name = Console.ReadLine();
                Player p = new Player(name);
                players.Add(p);

            }
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Player: " + players[i].Name);
            }
        }

        private static void PlayerTurn(Player player)
        {
            if (!(player.turnSkipCount > 0))
            {
                int diceRoll = 0;
                //View of the board (Functional requirement 6) 
                Console.WriteLine($"{player.Name}'s turn:");
                while (true)
                {
                    Console.WriteLine("1. Display properties and balances of all players"); //(Functional requirement 7) 
                    Console.WriteLine("2. Roll the dice");
                    Console.Write("Enter your choice (1 or 2): ");
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
                                Console.WriteLine($"{player.Name} rolled {diceRoll}");
                                break;
                            case 3://for testing
                                SetPlayerPosition(player);
                                break;

                            default:
                                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                                continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                    }
                }

                //move player by dice roll
                player.MovePlayer(diceRoll);
                BoardTile currentTile = board.Tiles[player.Position];
                Console.WriteLine($"Landed on {currentTile.Name}");
                currentTile.PerformAction(player);
                //you are in x tile
        //        Console.WriteLine("Press any key to continue"); //delete this and call tile's method
        //        string input2 = Console.ReadLine();
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
                    Console.WriteLine("Invalid input. Please enter a number between 2 and 4.");
                }
            }
        }

        private static int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7) + random.Next(1, 7);
        }



        private static void DisplayPropertiesAndBalances()
        {
            Console.WriteLine("Displaying properties and balances of all players...");
            /* foreach (Player p in players)
             {
                 Console.WriteLine($"Player {p.Name} has {p.Balance} money");
                 foreach (Property property in p.OwnedProperties)
                 {
                     //      Console.WriteLine($"Player {p.Name} has {property.Description}=> Cost: {property.Cost}, Rent: {property.RentAmount}"); hata veriyor suan
                     Console.WriteLine($"Player {p.Name} has {property.Name} located in tile {property.Position}=> Cost: {property.Cost}, Rent: {property.CalculateRent()}, Houses built: {property..HouseCount}");
                 }

             } */
            foreach (Player p in players)
            {
                Console.WriteLine($"Player {p.Name} has {p.Balance} money");
                foreach (Property property in p.OwnedProperties)
                {
                    Console.Write($"Player {p.Name} has {property.Name} located in tile {property.Position}=> Cost: {property.Cost}, Rent: {property.CalculateRent()} ");


                    if (property is RealEstateTile realEstate)
                    {
                        Console.WriteLine($"Houses built: {realEstate.HouseCount}");
                    }

                    else if (property is TrainStationTile trainStation)
                    {
                        Console.WriteLine($"Stations owned: {p.StationsBought}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void SetPlayerPosition(Player pl) //For testing
        {
            // foreach (Player player in players)
            {
                Console.Write($"Enter the new position for {pl.Name}: ");
                if (int.TryParse(Console.ReadLine(), out int newPosition))
                {
                    pl.Position = newPosition % board.TotalTiles;
                    Console.WriteLine($"{pl.Name}'s position set to {pl.Position}. tile");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid position.");
                }
            }
        }

    }
}

