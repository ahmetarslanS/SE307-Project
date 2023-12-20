using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class RealEstateTile : Property
    {

        public int[] RentLevels { get; set; }
        public int HouseCount;
        public int BuildCost;
        public bool HotelBuilt;

        public RealEstateTile(TileType tileType, string name, int position, int cost,int buildCcost, int[] rentLevels) : base(tileType, name, position, cost)
        {
            RentLevels = rentLevels;
            HouseCount = 0;
            BuildCost = buildCcost;
            HotelBuilt = false;
        }

      

        public override void PerformAction(Player player)
        {
            //check if owned first
            //if not ask if want to buy
            //if yes, check if owned by this player
            //if not take rent
            //if owned by same player ask if you want to build house

            if (Owner==null)
            {
                //want to buy?
                PurchaseProperty(player);
            }
            else
            {
                if (Owner != player) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{Owner.Name} owns this land with {HouseCount} houses. Current rent : {CalculateRent()}");
                    player.PayMoney(CalculateRent(), Owner);
                    Console.ResetColor();
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

        public override void PurchaseProperty(Player player)
        {
            int choice = 0;

            while (choice != 1 && choice != 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"This land is currently ownerless. Do you want to buy this land for {Cost} ?");
                Console.WriteLine("1. Buy");
                Console.WriteLine("2. Skip");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("You chose to buy this land.");
                            //check player money
                            if (player.Balance > this.Cost)
                            {
                                player.PayMoney(this.Cost);
                                player.OwnedProperties.Add(this);
                                Owner = player;
                                Console.WriteLine($"{player.Name} bought {Name}.");
                          
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Not enough money.");
                                Console.ResetColor();
                            }
                            Console.ResetColor();
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("You chose to skip buying the land.");
                            Console.ResetColor();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }
        }

        public void BuildHouse(Player player)
        {
            if (!HotelBuilt)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You own this land. Do you want to build a house for {BuildCost}? You currently have {HouseCount} houses on this land.");
                Console.WriteLine("1. Build a house");
                Console.WriteLine("2. Skip");
                Console.ResetColor();
                int choice;

                while (true)
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("You chose to build a house.");
                                player.PayMoney(BuildCost);
                                HouseCount++;
                                if (HouseCount == 5)
                                {
                                    Console.WriteLine("You built a hotel!");
                                    HotelBuilt = true;
                                }
                                else
                                {
                                    Console.WriteLine($"{player.Name} has {HouseCount} houses in this land.");
                                }
                              
                                Console.WriteLine($"The rent of this land is {CalculateRent()} now.");
                                Console.ResetColor();
                                
                                //get house building cost


                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("You chose to skip buying a house.");
                                Console.ResetColor();
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                                Console.ResetColor();
                                break;
                        }

                        if (choice == 1 || choice == 2)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.ResetColor();
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
