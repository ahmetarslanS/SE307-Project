using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Property :BoardTile
    {
        
        public int Cost { get; }
        public Player Owner { get;  set; }
        public bool IsOwned { get; set; }
       // public int Rent { get; }

        public Property(TileType tileType, string name, int position, int cost)
         : base(tileType, name, position)
        {
            Cost = cost;
            Owner = null;
            IsOwned = false;
        //    Rent = CalculateRent();//??
        }

        public Property(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
            throw new NotImplementedException();
        }

        public abstract int CalculateRent();
    }
}
