using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Board
    {
        public List<BoardTile> Tiles { get; }

        public int TotalTiles => Tiles.Count;

        public static int BoardBalance { get; set; } = 0;

        public Board()
        {        
            Tiles = new List<BoardTile>
            {
 
                new StartTile(TileType.Start, "Start Tile", 0),
                new RealEstateTile(TileType.RealEstate, "Tier 1 Land", 1, 60, 50, new int[]{4,20,60,180,320,450}),
                new CommunityChestTile(TileType.CommunityChest, "Community Chest", 2,this),
                new RealEstateTile(TileType.RealEstate, "Tier 1 Land", 3, 60, 50, new int[]{4,20,60,180,320,450}),
                new TaxTile(TileType.IncomeTax, "Income Tax", 4,this),
                new TrainStationTile(TileType.TrainStation, "Train Station", 5, 100),
                new RealEstateTile(TileType.RealEstate, "Tier 2 Land", 6, 120, 50, new int[]{8,40,100,300,450,600}),
                new ChanceCardsTile(TileType.ChanceCards, "Chance Cards", 7,this),
                new RealEstateTile(TileType.RealEstate, "Tier 2 Land", 8, 120, 50, new int[]{8,40,100,300,450,600}),
                new RealEstateTile(TileType.RealEstate, "Tier 2 Land", 9, 120, 50, new int[]{8,40,100,300,450,600}),
                new JailTile(TileType.Jail, "Jail", 10),
                new RealEstateTile(TileType.RealEstate, "Tier 3 Land", 11, 160, 100, new int[]{12,60,180,500,700,900}),
                new UtilityTile(TileType.Utility, "Electric Company", 12, 150),
                new RealEstateTile(TileType.RealEstate, "Tier 3 Land", 13, 160, 100, new int[]{12,60,180,500,700,900}),
                new RealEstateTile(TileType.RealEstate, "Tier 3 Land", 14, 160, 100, new int[]{12,60,180,500,700,900}),
                new TrainStationTile(TileType.TrainStation, "Train Station", 15, 100),
                new RealEstateTile(TileType.RealEstate, "Tier 4 Land", 16, 200, 100, new int[]{16,80,220,600,800,1000}),
                new CommunityChestTile(TileType.CommunityChest, "Community Chest", 17, this),
                new RealEstateTile(TileType.RealEstate, "Tier 4 Land", 18, 200, 100, new int[]{16,80,220,600,800,1000}),
                new RealEstateTile(TileType.RealEstate, "Tier 4 Land", 19, 200, 100, new int[]{16,80,220,600,800,1000}),
                new FreeParkingTile(TileType.FreeParking, "Free Parking", 20,this),
                new RealEstateTile(TileType.RealEstate, "Tier 5 Land", 21, 240, 150, new int[]{20,100,300,750,925,1100}),
                new ChanceCardsTile(TileType.ChanceCards, "Chance Cards", 22,this),
                new RealEstateTile(TileType.RealEstate, "Tier 5 Land", 23, 240, 150, new int[]{20,100,300,750,925,1100}),
                new RealEstateTile(TileType.RealEstate, "Tier 5 Land", 24, 240, 150, new int[]{20,100,300,750,925,1100}),
                new TrainStationTile(TileType.TrainStation, "Train Station", 25, 100),
                new RealEstateTile(TileType.RealEstate, "Tier 6 Land", 26, 280, 150, new int[]{24,120,360,850,1025,1200}),
                new RealEstateTile(TileType.RealEstate, "Tier 6 Land", 27, 280, 150, new int[]{24,120,360,850,1025,1200}),
                new UtilityTile(TileType.Utility, "Water Works", 28, 150),
                new RealEstateTile(TileType.RealEstate, "Tier 6 Land", 29, 280, 150, new int[]{24,120,360,850,1025,1200}),
                new GoToJailTile(TileType.GoToJail, "Go To Jail", 30,this),
                new RealEstateTile(TileType.RealEstate, "Tier 7 Land", 31, 320, 200, new int[]{28,150,450,1000,1200,1400}),
                new RealEstateTile(TileType.RealEstate, "Tier 7 Land", 32, 320, 200, new int[]{28,150,450,1000,1200,1400}),
                new CommunityChestTile(TileType.CommunityChest, "Community Chest", 33, this),
                new RealEstateTile(TileType.RealEstate, "Tier 7 Land", 34, 320, 200, new int[]{28, 150, 450, 1000, 1200, 1400}),
                new TrainStationTile(TileType.TrainStation, "Train Station", 35, 100),
                new ChanceCardsTile(TileType.ChanceCards, "Chance Cards", 36, this),
                new RealEstateTile(TileType.RealEstate, "Tier 8 Land", 37, 400, 200, new int[]{50,200,600,1400,1700,2000}),
                new TaxTile(TileType.LuxuryTax, "Luxury Tax", 38,this),
                new RealEstateTile(TileType.RealEstate, "Tier 8 Land", 39, 400, 200, new int[]{50,200,600,1400,1700,2000})
            };  

         
        

        }
        public void DisplayBoardView()
        {
            foreach (BoardTile tile in Tiles)
            {
                foreach (Player player in MonopolyGame.players)
                {
                    int tilePosition = Tiles.IndexOf(tile);
                    if (player.Position == tilePosition)
                    {
                        Console.ForegroundColor = player.Color;
                    }

                }
                tile.Display();
                Console.ResetColor();
            }
        }
    }
}
