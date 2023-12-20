using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class TrainStationTile : Property
    {
      //  int StationCount;
        public TrainStationTile(TileType tileType, string name, int position, int cost) : base(tileType, name, position, cost)
        {
     //       StationCount = 0;
           // Rent = CalculateRent();
        }


        //  public Player Owner { get; private set; }

        //    public bool IsOwned { get; set; }

        public override void PerformAction(Player player)
        {
            //check if owned first
            //if not ask if want to buy
            //if yes, check if owned by this player
            //if not take rent
            //if owned by same player ask if you want to build house

            if (Owner == null)
            {
                //want to buy?
                PurchaseProperty(player);
            }
            else
            {
                if (Owner != player)
                {
                 //   Console.WriteLine($"Somebody else owns this station. Current rent : {CalculateRent()}");
                  //  Console.WriteLine($"Somebody else owns this station. Current rent : {Owner.StationsBought*50}");
                    //Console.WriteLine($"Somebody else owns this station. Current rent : {CalculateRent()}");
                    Console.WriteLine($"Player {Owner.Name} has this station. Stations owned: {Owner.StationsBought}. Current rent: {CalculateRent()}");
                   // player.PayMoney(CalculateRent(), Owner);
                   // player.PayMoney(50*Owner.StationsBought, Owner);
                    player.PayMoney(CalculateRent(), Owner);
                }
                else //owner is this player
                {
                    Console.WriteLine("You already own this station.");
                }

            }

        }

        public override void PurchaseProperty(Player player)
        {
            int choice = 0;

            while (choice != 1 && choice != 2)
            {
                Console.WriteLine($"This station is currently ownerless. Do you want to buy this station for {Cost} ?");
                Console.WriteLine("1. Buy");
                Console.WriteLine("2. Skip");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("You chose to buy this station.");
                            //check player money
                            if (player.Balance > this.Cost)
                            {
                                player.PayMoney(this.Cost);
                                player.OwnedProperties.Add(this);
                                Owner = player;
                                Console.WriteLine($"{player.Name} bought {Name}.");
                                // StationCount++;
                                player.StationsBought++;
                                Console.WriteLine("Stations have: " + player.StationsBought);
                              //  IsOwned = true;
                                //unowned tilestan çıkarmam lazım bunu
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Not enough money.");
                                Console.ResetColor();
                            }
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("You chose to skip buying this station.");
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
        public override int CalculateRent()
        {
            //return 50*StationCount;//ama aynı oyuncunun sahip olması lazım bunu düzelt
            //return 50 * player.StationsBought;
            return 50 * Owner.StationsBought;
        }

    }
}
