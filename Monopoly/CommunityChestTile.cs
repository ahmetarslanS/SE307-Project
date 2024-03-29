﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class CommunityChestTile : CardTile
    {

        public CommunityChestTile(TileType tileType, string name, int position, Board board) : base(tileType, name, position, board)
        {
            InitializeCardPool();

        }

        protected override void InitializeCardPool()
        {
            // Create list of community chest card numbers
            CardPool = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Shuffle the cards at the beginning
            ShuffleCardPool();
        }


        public override void PerformAction(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Drawing a Chance Card for {player.Name}...");
            Console.ResetColor();
            // Simulate drawing a random Community Chest Card
            int cardNumber = DrawCard();

            // Implement the actions according to drawn card
            switch (cardNumber)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Collect 200Ꝟ.");
                    Console.ResetColor();
                    player.ReceiveMoney(200);
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Collect 100Ꝟ.");
                    Console.ResetColor();
                    player.ReceiveMoney(100);
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Place 100Ꝟ on the board.");
                    Console.ResetColor();
                    player.PayMoney(100, board: Board);
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel.");
                    Console.ResetColor();
                    int houseCount = 0;
                    foreach (RealEstateTile realEstate in player.OwnedProperties)
                    {
                        // int houseCount = realEstate.HouseCount;
                        houseCount += realEstate.HouseCount;
                        player.PayMoney(houseCount * 40, board: Board);
                    }

                    if (houseCount == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{player.Name} doesn't own any house");
                        Console.ResetColor();
                    }
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Travel to the nearest utility. Collect 200Ꝟ if you pass through the beginning tile.");
                    int utilityPos = player.FindClosestTile(typeof(UtilityTile), Board.Tiles);
                    int distanceToMove = utilityPos - player.Position;
                    Console.WriteLine($"Closest utility is in {utilityPos}. tile");
                    player.MovePlayer(distanceToMove);
                    BoardTile currentTile = Board.Tiles[player.Position];
                    Console.WriteLine($"Landed on {currentTile.Name}");
                    Console.ResetColor();
                    currentTile.PerformAction(player);
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Advance to the beginning tile.");
                    Console.ResetColor();
                    player.MovePlayer(Board.Tiles[0].Position-player.Position);
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Travel to jail immediately.");
                    int jailPos = 0;

                    foreach (BoardTile tile in Board.Tiles)
                    {
                        if (tile.Type == TileType.Jail)
                        {
                            jailPos = tile.Position;
                        }
                    }

                    player.Position = jailPos; //player won't get 200 
                    Console.WriteLine($"{player.Name}'s new position is {player.Position}");
                    Console.ResetColor();
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Collect 100Ꝟ from each player.");
                    Console.ResetColor();


                    foreach (Player otherPlayer in MonopolyGame.players)
                    {
                        if (otherPlayer != player)
                        {
                            otherPlayer.PayMoney(100, receiver: player);
                        }
                    }

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No specific action for this Community Chest Card.");
                    Console.ResetColor();
                    break;
            }
        }

    }
}
