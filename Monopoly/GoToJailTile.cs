using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class GoToJailTile : BoardTile
    {
        Board Board;
        public GoToJailTile(TileType tileType, string name, int position, Board board) : base(tileType, name, position)
        {
            Board = board;
        }

        public override void PerformAction(Player player)
        {
            if(!player.hasJailCard)
            {
                int jailPos = 0;

                foreach (BoardTile tile in Board.Tiles)
                {
                    if (tile.Type == TileType.Jail)
                    {
                        jailPos = tile.Position;
                    }
                }

                player.Position = jailPos;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{player.Name}'s new position is {player.Position}");
                Console.WriteLine($"{player.Name} is in jail and cannot play for two turns.");
                Console.ResetColor();
                player.InJail = true;
                player.turnSkipCount = 2;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{player.Name} has get out of jail free card and will no go to jail.");
                player.hasJailCard = false;
                Console.ResetColor();
            }
            
     
        }
    }
}
