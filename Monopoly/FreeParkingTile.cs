using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class FreeParkingTile : BoardTile
    {
        Board Board;
        public FreeParkingTile(TileType tileType, string name, int position,Board board) : base(tileType, name, position)
        {
            Board = board;
        }

        public override void PerformAction(Player player)
        {
            Console.WriteLine($"Player {player.Name} collects the money placed on the board. Board balance: {Board.BoardBalance}");
            player.ReceiveMoney(Board.BoardBalance,Board);
         //   Console.WriteLine($"Board's new balance: {Board.BoardBalance}");
        }
    }
}
