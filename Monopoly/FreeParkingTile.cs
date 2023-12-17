using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class FreeParkingTile : BoardTile
    {
        public FreeParkingTile(TileType tileType, string name, int position) : base(tileType, name, position)
        {
        }

        public override void PerformAction(Player player)
        {
            player.ReceiveMoney(Board.BoardBalance);
        }
    }
}
