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

        public void SetPosition(int newPosition)
        {
            Position = newPosition;
            Console.WriteLine($"{Name} moved to position {Position}.");
        }

        /*  public Player()
          {

          } */

        public Player(string name) //Start the game with 200 money and in first tile
        {
            Name = name;
            Balance = 200;
            Position = 0;
            StationsBought = 0;
            UtilityBought = 0;
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
