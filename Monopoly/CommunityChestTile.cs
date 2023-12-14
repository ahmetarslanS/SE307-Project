using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class CommunityChestTile : BoardTile
    {
        public CommunityChestTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
