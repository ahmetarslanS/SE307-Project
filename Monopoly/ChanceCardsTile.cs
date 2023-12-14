using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class ChanceCardsTile : BoardTile
    {
        public ChanceCardsTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
