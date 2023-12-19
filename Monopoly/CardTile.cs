using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal abstract class CardTile : BoardTile
    {
        protected Board Board;
        public CardTile(TileType tileType, string name, int position, Board board) : base(tileType, name, position)
        {
            Board = board;
            InitializeCardPool();
        }
        protected abstract void InitializeCardPool();
        /*    public override void PerformAction(Player player)
            {
                Console.WriteLine($"Drawing a Card for {player.Name}...");

                // Simulate drawing a random Card
                int cardNumber = DrawCard();

                // Implement the actions according to drawn card
                ExecuteCardAction(cardNumber, player);
            } */

        //         protected virtual void InitializeCardPool() { }
        //    protected abstract void ExecuteCardAction(int cardNumber, Player player);

        protected void ShuffleCardPool()
        {
            Random random = new Random();
            int n = CardPool.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = CardPool[k];
                CardPool[k] = CardPool[n];
                CardPool[n] = value;
            }
        }

        protected int DrawCard()
        {
            // Check if the card pool is depleted and shuffle if needed
            if (CardPool.Count == 0)
            {
                Console.WriteLine($"{Type} Card pool is depleted. Reshuffling...");
                InitializeCardPool();
            }

            // Draw a card and remove it from the pool
            int drawnCard = CardPool[0];
            CardPool.RemoveAt(0);

            return drawnCard;
        }

    }
}