using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class Board
    {
        public List<BoardTile> Tiles { get; }

        public int TotalTiles => Tiles.Count;

        public Board()
        {
            Tiles = new List<BoardTile>
        {
            new BoardTile(TileType.Start, 0, "Start"),
            new BoardTile(TileType.IncomeTax, 0, "Income Tax"),
            new BoardTile(TileType.LuxuryTax, 0, "Luxury Tax"),
            new BoardTile(TileType.Chance, 0, "Chance"),
            new BoardTile(TileType.CommunityChest, 0, "Community Chest"),
            new BoardTile(TileType.FreeParking, 0, "Free Parking"),
            new BoardTile(TileType.TrainStation, 100, "Train Station", canBuy: true),
            new BoardTile(TileType.Utility, 150, "Electric Company", canBuy: true),
            new BoardTile(TileType.Utility, 150, "Water Works", canBuy: true),
            new BoardTile(TileType.RealEstate, 60, "Property Tier 1", canBuy: true),
            new BoardTile(TileType.RealEstate, 120, "Property Tier 2", canBuy: true),
            new BoardTile(TileType.RealEstate, 160, "Property Tier 3", canBuy: true),
            new BoardTile(TileType.RealEstate, 200, "Property Tier 4", canBuy: true),
            new BoardTile(TileType.RealEstate, 240, "Property Tier 5", canBuy: true),
            new BoardTile(TileType.RealEstate, 280, "Property Tier 6", canBuy: true),
            new BoardTile(TileType.RealEstate, 320, "Property Tier 7", canBuy: true),
            new BoardTile(TileType.RealEstate, 400, "Property Tier 8", canBuy: true),
            new BoardTile(TileType.GoToJail, 0, "Go To Jail"),
            new BoardTile(TileType.Jail, 0, "Jail"),
        };
        }
    }
}
