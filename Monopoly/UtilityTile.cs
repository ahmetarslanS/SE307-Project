﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class UtilityTile : Property
    {
        public UtilityTile(TileType tileType, string name, int position, int cost) : base(tileType, name, position, cost)
        {
        }
        public override void PerformAction(Player player)
        {
            if (!IsOwned)
            {
                //want to buy?
                PurchaseProperty(player);
            }
            else
            {
                if (Owner != player)
                {

                    Console.WriteLine($"Somebody else owns this utility. Current rent : {CalculateRent()}");
                    player.PayMoney(CalculateRent(), Owner);
                }
                else //owner is this player
                {
                    Console.WriteLine("You already own this utility.");
                }

            }
        }

        public override void PurchaseProperty(Player player)
        {
            int choice = 0;

            while (choice != 1 && choice != 2)
            {
                Console.WriteLine($"This {Name} is currently ownerless. Do you want to buy this {Name} for {Cost} ?");
                Console.WriteLine("1. Buy");
                Console.WriteLine("2. Skip");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You chose to buy this {Name}.");
                            //check player money
                            if (player.Balance >= this.Cost)
                            {
                                player.PayMoney(this.Cost);
                                player.OwnedProperties.Add(this);
                                Owner = player;
                                Console.WriteLine($"{player.Name} bought {Name}.");
                                player.UtilityBought++;
                                Console.WriteLine("Utilities have: " + player.UtilityBought);
                                IsOwned = true;
                                //unowned tilestan çıkarmam lazım bunu
                            }
                            else
                            {
                                Console.WriteLine("Not enough money.");
                            }
                            break;

                        case 2:
                            Console.WriteLine($"You chose to skip buying this {Name}.");
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

        public override int CalculateRent()
        {
            Random random = new Random();
            int dice = random.Next(1, 7) + random.Next(1, 7);
         //   Console.WriteLine($"Rolled {dice}.");
            if (Owner.UtilityBought == 1)
            {
                return dice * 50;
            }
            else
            {
                return dice * 100;
            }

        }
    }
}