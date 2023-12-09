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

        public List<BoardTile> OwnedProperties { get; } = new List<BoardTile>();

        public int Position { get; set; } = 0;

      /*  public Player()
        {

        } */

        public Player(string name) //Start the game with 200 money and in first tile
        {
            Name = name;
            Balance = 200;
            Position = 0;
        }

        public void ReceiveMoney(int amount)
        {
            Balance += amount;
            Console.WriteLine(this.Name + " received "+ amount + "Ꝟ. New balance: " + Balance + "Ꝟ");
        }

        public void PayMoney(int amount)
        {
            Balance -= amount;
            Console.WriteLine(this.Name + " paid " + amount + "Ꝟ. New balance: " + Balance + "Ꝟ");
            CheckIfLost();
        }

        //pay rent method, use CheckIfLost();
        public void BuyProperty(BoardTile property)
        {
            if (property.CanBuy && Balance >= property.Cost)
            {
                Balance -= property.Cost;
                OwnedProperties.Add(property);
               Console.WriteLine(this.Name + " bought " + property.Description + " for " + property.Cost + "Ꝟ. New balance: " + Balance + "Ꝟ");

            }
            else
            {
                Console.WriteLine(this.Name + " cannot buy " + property.Description + ".");
            }
        }

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
