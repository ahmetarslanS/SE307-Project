using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; }
        public int Balance { get; set; }

        public List<Property> OwnedProperties { get; } = new List<Property>();

        public int Position { get; set; } = 0;

        public int StationsBought { get; set; }
        public int UtilityBought { get; set; }

        public bool hasJailCard { get; set; }
        public bool InJail;
        public int turnSkipCount;

        public Player(string name) //Start the game with 200 money and in first tile
        {
            Name = name;
            Balance = 200;
            Position = 0;
            StationsBought = 0;
            UtilityBought = 0;
            hasJailCard = false;
            InJail = false;
            turnSkipCount = 0;
        }

        public void ReceiveMoney(int amount)
        {
            Balance += amount;
            Console.WriteLine(this.Name + " received "+ amount + ". "+ this.Name+"'s new balance: " + Balance + "");
        }

        public void PayMoney(int amount, Player receiver = null, Board board = null)
        {
            Balance -= amount;

            if (receiver != null)
            {
                receiver.ReceiveMoney(amount);
                Console.WriteLine($"{Name} paid {amount} to {receiver.Name}. {Name}'s new balance: {Balance}");
            }
            else if (board != null)
            {
                Board.BoardBalance += amount;
                Console.WriteLine($"{Name} paid {amount} to the board. {Name}'s new balance: {Balance}. Board's new balance: {Board.BoardBalance}");
            }
            else
            {
                Console.WriteLine($"{Name} paid {amount}. {Name}'s new balance: {Balance}");
            }

            CheckIfLost(); //kaybedince de para ödüyor şuan
        }


        //pay rent method, use CheckIfLost();
        /* public void BuyProperty(BoardTile property)
         {
           //  if (property.CanBuy && Balance >= property.Cost)
             if (!property.isOwned && Balance >= property.Cost)
             {
                 Balance -= property.Cost;
                 OwnedProperties.Add(property);
                Console.WriteLine(this.Name + " bought " + property.Description + " for " + property.Cost + this.Name+"'s new balance: " + Balance + "");

             }
             else
             {
                 Console.WriteLine(this.Name + " cannot buy " + property.Description + ".");
             }
         }*/

        public void SkipTurns(int skipAmount)
        {
            //cant play for skipAmount time
        }

        public void MovePlayer(int amount)
        {
            int previousPosition = Position;
          //  Position = (Position + amount) % board.TotalTiles;
            Position = (Position + amount) % 40;
        /*    if (previousPosition > Position) //geri yürürse de 200 veriyor start tiledan geçmese bile
            {
                Console.WriteLine($"{Name} passed through Start Tile.");
                ReceiveMoney(200);
            } */

            if (previousPosition > Position && Position != 0)
            {
                Console.WriteLine($"{Name} moved backward but did not pass through Start Tile.");
            }
            else if (previousPosition > Position && Position == 0)
            {
                Console.WriteLine($"{Name} passed through Start Tile.");
                ReceiveMoney(200);
            }

            Console.WriteLine($"{Name} moved to {Position}. tile");

        }

        public int FindClosestTile(Type tileType,List<BoardTile> tiles) //daha tamamlamadım
        {
            int closestTileToFind = tiles[0].Position;
            int minDistance = CalculateDistance(Position, closestTileToFind);

            foreach (BoardTile tile in tiles)
            {
                if (tile.GetType() == tileType)
                {
                    int distance = CalculateDistance(Position, tile.Position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTileToFind = tile.Position;
                    }
                }
            }
          
            return closestTileToFind;
        }
        private int CalculateDistance(int currentPosition, int targetPosition)
        {
            // Calculate the shortest distance considering the board as a circular path
            int distanceClockwise = (targetPosition - currentPosition + 40) % 40;
            int distanceCounterClockwise = (currentPosition - targetPosition + 40) % 40;

            return Math.Min(distanceClockwise, distanceCounterClockwise);
        }

        void CheckIfLost()
        {
            if(Balance < 0)
            {
                Console.WriteLine("Player " + this.Name + "lost.");
                //lose
                //return property to system
            }
        }
    }
}
