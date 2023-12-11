﻿using System;
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
       // public int RentAmount { get; }
        
        public int BuildCost { get; }
        public string Description { get; }

        public List<string> ChanceCards { get; } = new List<string>();
        public List<string> CommunityChestCards { get; } = new List<string>();

        public int OwnerStations { get; }
       // public bool CanBuy { get; }
        public bool isOwned { get; set; }

        public Player Owner { get; private set; }

        public int Position;

        public int HouseCount;

        public int[] RentLevels;

        //  public BoardTile(TileType type, int position, int cost = 0, string description = "", List<string> chanceCards = null,
        //                 List<string> communityChestCards = null, int rentAmount = 0, int ownerStations = 0, bool canBuy = false)
        public BoardTile(TileType type, int position, string description, int cost = 0, int buildCost = 0, int[] rentLevels = null, List<string> chanceCards = null,
                     List<string> communityChestCards = null, int ownerStations = 0, bool canBuy = false)
        {
            Type = type;
            Cost = cost;
            BuildCost = buildCost;
            Description = description;
            ChanceCards = chanceCards ?? new List<string>();
            CommunityChestCards = communityChestCards ?? new List<string>();
       //     RentAmount = rentAmount;
            OwnerStations = ownerStations;
            // CanBuy = canBuy;
            isOwned = false;
            HouseCount = 0;
            RentLevels = rentLevels;
            Position = position;
        }

        public void PerformAction(Player player)
        {
            switch (Type)
            {
                case TileType.Start:
                    //player.ReceiveMoney(200);
                    break;

                case TileType.RealEstate:
                    RealEstateOperations(player);
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

        private void RealEstateOperations(Player player)
        {
            //check if owned first
            //if not ask if want to buy
            //if yes, check if owned by this player
            //if not take rent
            //if owned by same player ask if you want to build house

            if (!isOwned)
            {
                //want to buy?
                int choice = 0;

                while (choice != 1 && choice != 2)
                {
                    Console.WriteLine($"This land is currently ownerless. Do you want to buy this land for {Cost} ?");
                    Console.WriteLine("1. Buy");
                    Console.WriteLine("2. Skip");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("You chose to buy the land.");
                                //check player money
                                if(player.Balance >= this.Cost)
                                {
                                    player.PayMoney(this.Cost);
                                    player.OwnedProperties.Add(this);
                                    Owner = player;
                                    Console.WriteLine($"{player.Name} bought {Description}.");
                                    isOwned = true;
                                    //unowned tilestan çıkarmam lazım bunu
                                }
                                else
                                {
                                    Console.WriteLine("Not enough money.");
                                }
                                break;

                            case 2:
                                Console.WriteLine("You chose to skip buying the land.");
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }
            else
            {
                if (Owner != player) //TEST
                {
                    Console.WriteLine($"Somebody else owns this land with {HouseCount} houses. Current rent : {CalculateRent()}");
                    //get rent
                    player.PayMoney(CalculateRent(),Owner);
                   // Owner.ReceiveMoney(CalculateRent());
                }
                else //owner is this player
                {
                    //ask if he wants to build house
                    if (HouseCount < 5)
                    {
                        Console.WriteLine($"You own this land. Do you want to build a house for {BuildCost}? You currently have {HouseCount} houses on this land.");
                        Console.WriteLine("1. Build a house");
                        Console.WriteLine("2. Skip");

                        int choice;

                        while (true)
                        {
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out choice))
                            {                     
                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("You chose to build a house.");
                                        player.PayMoney(BuildCost);
                                        HouseCount++;
                                        Console.WriteLine($"The rent of this land is {CalculateRent()} now.");
                                        //get house building cost
                                       
                                    
                                        break;

                                    case 2:
                                        Console.WriteLine("You chose to skip buying a house.");
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                                        break;
                                }

                                if (choice == 1 || choice == 2)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }

                        }
                        }

                    }
                //check who owns
                //if players', ask if he wants to build house,
                //if someone elses' than get rent
                
            }

        }

        public int CalculateRent()
        {
            return RentLevels[HouseCount];
            
        }
        private void GoToJail(Player player)
        {
            Console.WriteLine(player.Name + " goes to jail");
            //set player position to jail tile
            player.SkipTurns(2);
        }
    }
}