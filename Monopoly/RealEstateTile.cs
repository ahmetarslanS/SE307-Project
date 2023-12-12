using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class RealEstateTile : Property
    {
    //    public int Cost { get; }
       // public int Rent { get; }
        public int[] RentLevels { get; set; }

    //    public Player Owner { get; private set; }

    //    public bool IsOwned { get; set; }
        public int HouseCount;
        public int BuildCost;

        public RealEstateTile(TileType tileType, string name, int position, int cost,int buildCcost, int[] rentLevels) : base(tileType, name, position, cost)
        {
            RentLevels = rentLevels;
            HouseCount = 0;
            BuildCost = buildCcost;
        }

        /*     public RealEstateTile(TileType tileType, string name, int position,int cost,int buildCost, int[] rentLevels) : base(tileType, name, position)
             {
                 tileType = TileType.RealEstate;
              //   Cost = cost;
                 RentLevels = rentLevels;
                 IsOwned = false;
             //    Owner = null;
                 BuildCost = buildCost;
             } */



        /*  public RealEstateTile(int position, string name, int cost, int buildCost, int[] rentLevels)
           : base(TileType.RealEstate, name, position)
          {
              Cost = cost;
          //    Rent = rent;
              RentLevels = rentLevels;
              isOwned = false;
              Owner = null;
              BuildCost = buildCost;
          }*/

        public override void PerformAction(Player player)
        {
            //check if owned first
            //if not ask if want to buy
            //if yes, check if owned by this player
            //if not take rent
            //if owned by same player ask if you want to build house

            if (!IsOwned)
            {
                //want to buy?
                PurchaseProperty(player);
            }
            else
            {
                if (Owner != player) 
                {
                    Console.WriteLine($"Somebody else owns this land with {HouseCount} houses. Current rent : {CalculateRent()}");
                    player.PayMoney(CalculateRent(), Owner);
                }
                else //owner is this player
                {
                    if (HouseCount < 5)
                    {
                        BuildHouse(player);
                    }

                }

            }


        }

        public void PurchaseProperty(Player player)
        {
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
                            Console.WriteLine("You chose to buy this land.");
                            //check player money
                            if (player.Balance >= this.Cost)
                            {
                                player.PayMoney(this.Cost);
                                player.OwnedProperties.Add(this);
                                Owner = player;
                                Console.WriteLine($"{player.Name} bought {Name}.");
                                IsOwned = true;
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

        public void BuildHouse(Player player)
        {
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

        public override int CalculateRent()
        {
            return RentLevels[HouseCount];
        }
    }
}
