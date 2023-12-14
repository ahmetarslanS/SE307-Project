using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class TaxTile : BoardTile
    {
        private Board Board;
        public TaxTile(TileType tileType, string name, int position,Board board) : base(tileType, name, position)
        {
            Board = board;

        }

        public override void PerformAction(Player player)
        {
            int taxAmount = 0;

            switch (base.Type)
            {
                case TileType.IncomeTax:
                    taxAmount = 100;
                    break;

                case TileType.LuxuryTax:
                    taxAmount = 150;
                    break;

                // Add more cases for other tax types if needed

                default:
                    // Handle other cases if necessary
                    break;
            }

            player.PayMoney(taxAmount, board: Board);
        }
    }
}
