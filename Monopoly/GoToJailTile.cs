using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class GoToJailTile : BoardTile
    {
        public GoToJailTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
