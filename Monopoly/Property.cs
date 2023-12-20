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
 

        public Property(TileType tileType, string name, int position, int cost)
         : base(tileType, name, position)
        {
            Cost = cost;
            Owner = null;
       
        }

        public Property(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
        }

        public abstract void PurchaseProperty(Player player);

        public abstract int CalculateRent();
    }
}
