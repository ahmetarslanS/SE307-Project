using System;
using System.Collections.Generic;

namespace Monopoly
{
    public enum TileType
    {
        Start,
        IncomeTax,
        LuxuryTax,
        ChanceCards,
        CommunityChest,
        FreeParking,
        TrainStation,
        Utility,
        RealEstate,
        GoToJail,
        Jail
    }

    public abstract class BoardTile
    {
        public TileType Type { get; }
        public string Name { get; }
        public int Position { get; }

        protected List<int> CardPool { get; set; }

        protected BoardTile(TileType tileType, string name, int position)
        {
            Type = tileType;
            Name = name;
            Position = position;
        }

        //// Subclasses can override this method to provide their own implementation.
        protected virtual void InitializeCardPool() { }

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

        public abstract void PerformAction(Player player);
    }
}
