using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class ChanceCardsTile : BoardTile
    {
        private List<int> chanceCardPool;

        public ChanceCardsTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
            InitializeChanceCardPool();
        }

        private void InitializeChanceCardPool()
        {
            // Create list of chance card numbers
            chanceCardPool = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Shuffle the cards at the beginning
            ShuffleChanceCardPool();
        }

        private void ShuffleChanceCardPool()
        {
            Random random = new Random();
            int n = chanceCardPool.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = chanceCardPool[k];
                chanceCardPool[k] = chanceCardPool[n];
                chanceCardPool[n] = value;
            }
        }

        private int DrawChanceCard()
        {
            // Check if the card pool is depleted and shuffle if needed
            if (chanceCardPool.Count == 0)
            {
                Console.WriteLine("Chance Card pool is depleted. Reshuffling...");
                InitializeChanceCardPool();
            }

            // Draw a card and remove it from the pool
            int drawnCard = chanceCardPool[0];
            chanceCardPool.RemoveAt(0);

            return drawnCard;
        }


        public override void PerformAction(Player player)
        {
            Console.WriteLine($"Drawing a Chance Card for {player.Name}...");

            // Simulate drawing a random Chance Card
            int cardNumber = GetRandomCardNumber();

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

        private int GetRandomCardNumber()
        {
            // Simulate drawing a random card from 1 to 8
            Random random = new Random();
            return random.Next(1, 9);
        }
    }
}
