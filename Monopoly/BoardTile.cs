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

        public virtual void Display()
        {
            Console.Write("[ " + Name + "]" + "  ");   
        }


        public abstract void PerformAction(Player player);
    }
}
