using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class ChanceCardsTile : BoardTile
    {
        public ChanceCardsTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
            InitializeCardPool();
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
                    Console.WriteLine("Collect 150Ꝟ.");
                    player.ReceiveMoney(150);
                    break;

                case 2:
                    Console.WriteLine("Collect 50Ꝟ.");
                    player.ReceiveMoney(50);
                    break;

                case 3:
                    Console.WriteLine("Place 150Ꝟ on the board.");
                    // not  sure how to implement this
                    //player.PayMoney(50, receiver: null, board: board);
                    break;

                case 4:
                    Console.WriteLine("Place on the board 25Ꝟ for each owned house, and 100Ꝟ for each owned hotel.");
                    // Implement logic to place money based on owned houses and hotels
                    break;

                case 5:
                    Console.WriteLine("Travel to the nearest train station. Collect 200Ꝟ if you pass through the beginning tile.");
                    // Implement logic to move to the nearest train station
                    // Check if the player passes the beginning tile and collect 200Ꝟ
                    break;

                case 6:
                    Console.WriteLine("Go back 3 tiles.");
                    // alttaki method private olduğu için inaccesible, public veya internal yapabiliriz belki
                    //MonopolyGame.MovePlayer(player, -3);
                    break;

                case 7:
                    Console.WriteLine("Get out of jail immediately, if in jail.");
                    // Implement logic to release the player from jail
                    break;

                case 8:
                    Console.WriteLine("Pay each player 50Ꝟ.");
                    // burda da yine players private olduğu için inaccesible
                    /*
                    foreach (Player otherPlayer in MonopolyGame.players)
                    {
                        if (otherPlayer != player)
                        {
                            player.PayMoney(50, receiver: otherPlayer);
                        }
                    }
                    */
                    break;

                default:
                    Console.WriteLine("No specific action for this Chance Card.");
                    break;
            }
        }
    }
}
