using System;
using System.Collections.Generic;

namespace Monopoly
{

    public enum TileType
    {
        Start,
        IncomeTax,
        LuxuryTax,
        Chance,
        CommunityChest,
        FreeParking,
        TrainStation,
        Utility,
        RealEstate,
        GoToJail,
        Jail
    }

    public class BoardTile
    {
        public TileType Type { get; }
        public int Cost { get; }
        public string Description { get; }

        public List<string> ChanceCards { get; } = new List<string>();
        public List<string> CommunityChestCards { get; } = new List<string>();
        public int RentAmount { get; }
        public int OwnerStations { get; }
        public bool CanBuy { get; }

        public BoardTile(TileType type, int cost = 0, string description = "", List<string> chanceCards = null,
                         List<string> communityChestCards = null, int rentAmount = 0, int ownerStations = 0, bool canBuy = false)
        {
            Type = type;
            Cost = cost;
            Description = description;
            ChanceCards = chanceCards ?? new List<string>();
            CommunityChestCards = communityChestCards ?? new List<string>();
            RentAmount = rentAmount;
            OwnerStations = ownerStations;
            CanBuy = canBuy;
        }

        public void PerformAction(/*Player player, int diceRoll = 0*/)
        {
            switch (Type)
            {
                case TileType.Start:
                    //player.ReceiveMoney(200);
                    break;

                case TileType.IncomeTax:
                    //player.PayMoney(200);
                    break;

                case TileType.LuxuryTax:
                    //player.PayMoney(150);
                    break;

                case TileType.Chance:
                    //DrawChanceCard(player);
                    break;

                case TileType.CommunityChest:
                    //DrawCommunityChestCard(player);
                    break;

                case TileType.FreeParking:
                    //player.CollectMoneyOnBoard();
                    break;

                case TileType.TrainStation:
                    //HandleTrainStation(player);
                    break;

                case TileType.Utility:
                    //HandleUtility(player, diceRoll);
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected tile type: {Type}");
                    break;
            }
        }
    }
}