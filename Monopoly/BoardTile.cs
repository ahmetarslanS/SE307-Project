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



        //  public BoardTile(TileType type, int position, int cost = 0, string description = "", List<string> chanceCards = null,
        //                 List<string> communityChestCards = null, int rentAmount = 0, int ownerStations = 0, bool canBuy = false)
        protected BoardTile(TileType tileType, string name, int position)
        {
            Type = tileType;
            Name = name;
            Position = position;
        }

        public abstract void PerformAction(Player player);

       

    }
}