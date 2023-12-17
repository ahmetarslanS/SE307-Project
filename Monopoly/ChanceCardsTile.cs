using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class ChanceCardsTile : CardTile
    {
      //  Board Board;
        public ChanceCardsTile(TileType tileType, string name, int position,Board board) : base(tileType, name, position,board)
        {
            InitializeCardPool();
      //      Board = board;
        }

        protected override void InitializeCardPool()
        {
            // Create list of chance card numbers
            CardPool = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Shuffle the cards at the beginning
            ShuffleCardPool();
        }


        public override void PerformAction(Player player)
        {
            Console.WriteLine($"Drawing a Chance Card for {player.Name}...");

            // Simulate drawing a random Chance Card
            int cardNumber = DrawCard();

            // Implement the actions according to drawn card
            switch (cardNumber)
            {
                case 1:
                    Console.WriteLine("Collect 150.");
                    player.ReceiveMoney(150);
                    break;

                case 2:
                    Console.WriteLine("Collect 50.");
                    player.ReceiveMoney(50);
                    break;

                case 3:
                    Console.WriteLine("Place 150Ꝟ on the board.");
                    player.PayMoney(150, board: Board);
                    break;

                case 4:
                    Console.WriteLine("Place on the board 25 for each owned house, and 100 for each owned hotel."); //tek ev için çalıştı ama detaylı test etmedim
                    int houseCount = 0;
                    foreach(RealEstateTile realEstate in player.OwnedProperties)
                    {
                        // int houseCount = realEstate.HouseCount;
                        houseCount += realEstate.HouseCount;
                        player.PayMoney(houseCount*25,board: Board);                                                              
                    }

                    if (houseCount == 0)
                    {
                        Console.WriteLine($"{player.Name} doesn't own any house");
                    }
                    break;

                case 5:
                    Console.WriteLine("Travel to the nearest train station. Collect 200Ꝟ if you pass through the beginning tile.");
                    int trainStationPos = player.FindClosestTile(typeof (TrainStationTile),Board.Tiles);
                    int distanceToMove = trainStationPos - player.Position;
                    Console.WriteLine($"Closest station is in {trainStationPos}. tile");
                    player.MovePlayer(distanceToMove);
                    BoardTile currentTile = Board.Tiles[player.Position];
                    Console.WriteLine($"Landed on {currentTile.Name}");
                    currentTile.PerformAction(player);

                    // Implement logic to move to the nearest train station
                    // Check if the player passes the beginning tile and collect 200Ꝟ
                    break;

                case 6: 
                    Console.WriteLine("Go back 3 tiles.");
                    int newPos = player.Position - 3;
                    int distance = newPos - player.Position;
                    // alttaki method private olduğu için inaccesible, public veya internal yapabiliriz belki
                    player.MovePlayer(distance);
                    currentTile = Board.Tiles[player.Position];
                    Console.WriteLine($"Landed on {currentTile.Name}");
                    currentTile.PerformAction(player);
                    break;

                case 7:
                    Console.WriteLine("Get out of jail immediately, if in jail.");
                    player.hasJailCard = true;
                    //player will get out of jail if they encounter jail
                    break;

                case 8:
                    Console.WriteLine("Pay each player 50Ꝟ.");
                    // burda da yine players private olduğu için inaccesible
                    
                    foreach (Player otherPlayer in MonopolyGame.players)
                    {
                        if (otherPlayer != player)
                        {
                            player.PayMoney(50, receiver: otherPlayer);
                        }
                    }
                    
                    break;

                default:
                    Console.WriteLine("No specific action for this Chance Card.");
                    break;
            }
        }

    /*    protected override void ExecuteCardAction(int cardNumber, Player player)
        {
            throw new NotImplementedException();
        } */
    }
}
