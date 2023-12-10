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

    public class BoardTile
    {
        public TileType Type { get; }
        public int Cost { get; }
        public int RentAmount { get; }
        
        public int BuildCost { get; }
        public string Description { get; }

        public List<string> ChanceCards { get; } = new List<string>();
        public List<string> CommunityChestCards { get; } = new List<string>();

        public int OwnerStations { get; }
       // public bool CanBuy { get; }
        public bool isOwned { get; set; }

        public int position;

        //  public BoardTile(TileType type, int position, int cost = 0, string description = "", List<string> chanceCards = null,
        //                 List<string> communityChestCards = null, int rentAmount = 0, int ownerStations = 0, bool canBuy = false)
        public BoardTile(TileType type, int position, string description, int cost = 0, int rentAmount = 0, int buildCost = 0, List<string> chanceCards = null,
                     List<string> communityChestCards = null, int ownerStations = 0, bool canBuy = false)
        {
            Type = type;
            Cost = cost;
            BuildCost = buildCost;
            Description = description;
            ChanceCards = chanceCards ?? new List<string>();
            CommunityChestCards = communityChestCards ?? new List<string>();
            RentAmount = rentAmount;
            OwnerStations = ownerStations;
            // CanBuy = canBuy;
            isOwned = false;
        }

        public void PerformAction(Player player)
        {
            switch (Type)
            {
                case TileType.Start:
                    //player.ReceiveMoney(200);
                    break;

                case TileType.RealEstate:
                    RealEstateOperations();
                    break;

                case TileType.IncomeTax:
                    //player.PayMoney(200);
                    break;

                case TileType.LuxuryTax:
                    //player.PayMoney(150);
                    break;

                case TileType.ChanceCards:
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
                case TileType.GoToJail: //methodları alt alta mı yazacagımızı bilmedigim icin örnek ekledim bir tane
                    GoToJail(player);
                    break;
                case TileType.Jail:
                    //?
                    break;      
                default:
                    throw new InvalidOperationException($"Unexpected tile type: {Type}");

            }
        }

        private void RealEstateOperations()
        {
            //check if owned first
            //if not ask if want to buy
            //if yes, check if owned by this player
            //if not take rent
            //if owned by same player ask if you want to build house

        }

        private void GoToJail(Player player)
        {
            Console.WriteLine(player.Name + " goes to jail");
            //set player position to jail tile
            player.SkipTurns(2);
        }
    }
}