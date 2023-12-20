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
        public int Balance { get; private set; }

        public List<Property> OwnedProperties { get; } = new List<Property>();

        public int Position { get; set; } = 0;

        public int StationsBought { get; set; }
        public int UtilityBought { get; set; }

        public bool hasJailCard { get; set; }
        public bool InJail;
        public int turnSkipCount;
        public bool IsEliminated;
        public ConsoleColor Color;
    

        public Player(string name, ConsoleColor color) //Start the game with 200 money and in first tile
        {
            Name = name;
            Balance = 200;
            Position = 0;
            StationsBought = 0;
            UtilityBought = 0;
            hasJailCard = false;
            InJail = false;
            turnSkipCount = 0;
            IsEliminated = false;
            Color = color;
        }
        public ConsoleColor GetColor() { return Color; }

        public void ReceiveMoney(int amount, Board board = null)
        {
            Balance += amount;
            if(board!= null)
            {
                Board.BoardBalance -= amount;
            }
            Console.WriteLine(this.Name + " received "+ amount + ". "+ this.Name+"'s new balance: " + Balance + "");
        }

        public void PayMoney(int amount, Player receiver = null, Board board = null)
        {
            if(Balance > amount)
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

            }
            else
            {
                if (receiver != null)
                {
                    receiver.ReceiveMoney(Balance); //give all the money left                 
                    Console.WriteLine($"{Name} paid {Balance} to {receiver.Name}. {Name}'s new balance: 0");
                    Balance -= Balance;
                }
                else if(board != null)
                {
                    Board.BoardBalance += Balance;             
                    Console.WriteLine($"{Name} paid {Balance} to the board. {Name}'s new balance: 0. Board's new balance: {Board.BoardBalance}");
                    Balance -= Balance;
                }
        

                Console.WriteLine($"Player {Name} is eliminated.");
         
                IsEliminated = true;
            }

      
        }

        public void MovePlayer(int amount)
        {
            int previousPosition = Position;
            Position = (Position + amount) % 40;
          

            if ((previousPosition < 20 && Position >= 20 && Position < previousPosition) ||
         (previousPosition > 30 && Position < 10 && Position < previousPosition))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} passed through Start Tile.");
                ReceiveMoney(200);
                Console.ResetColor();
            }
            else if (Position == 0)
            {
                ReceiveMoney(200);

            }
            else if (previousPosition > Position)
            {
                Console.WriteLine($"{Name} moved backward but did not pass through Start Tile.");
            }
         
            Console.WriteLine($"{Name} moved to {Position}. tile");

        }

        public int FindClosestTile(Type tileType,List<BoardTile> tiles) 
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

 

       
    }
}
