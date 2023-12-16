using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class CommunityChestTile : BoardTile
    {
        public CommunityChestTile(TileType tileType, string name, int position) : base(tileType, name, position)
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
            Console.WriteLine($"Drawing a Chance Card for {player.Name}...");

            // Simulate drawing a random Community Chest Card
            int cardNumber = DrawCard();

            // Implement the actions according to drawn card
            switch (cardNumber)
            {
                case 1:
                    Console.WriteLine("Collect 200Ꝟ.");
                    player.ReceiveMoney(200);
                    break;

                case 2:
                    Console.WriteLine("Collect 100Ꝟ.");
                    player.ReceiveMoney(100);
                    break;

                case 3:
                    Console.WriteLine("Place 100Ꝟ on the board.");
                    // not  sure how to implement this
                    //player.PayMoney(100, receiver: null, board: board);
                    break;

                case 4:
                    Console.WriteLine("Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel.");
                    // Implement logic to place money based on owned houses and hotels
                    break;

                case 5:
                    Console.WriteLine("Travel to the nearest utility. Collect 200Ꝟ if you pass through the beginning tile.");
                    // Implement logic to move to the nearest utility
                    // Check if the player passes the beginning tile and collect 200Ꝟ
                    break;

                case 6:
                    Console.WriteLine("Advance to the beginning tile.");
                    player.SetPosition(0);
                    break;

                case 7:
                    Console.WriteLine("Travel to jail immediately.");
                    // Implement logic to put the player in jail.
                    break;

                case 8:
                    Console.WriteLine("Collect 100Ꝟ from each player.");
                    // burda da yine players private olduğu için inaccesible
                    /*
                    foreach (Player otherPlayer in MonopolyGame.Players)
                    {
                        if (otherPlayer != player)
                        {
                            otherPlayer.PayMoney(100, receiver: player);
                        }
                    }
                    */
                    break;

                default:
                    Console.WriteLine("No specific action for this Community Chest Card.");
                    break;
            }
        }
    }
}
