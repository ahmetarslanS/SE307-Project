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

        public int BoardBalance = 0;

        public Board()
        {
            Tiles = new List<BoardTile>
            {
                //  List<BoardTile> Tiles = new List<BoardTile>();

                new BoardTile(TileType.Start, 0, "Start"),
                new BoardTile(TileType.RealEstate, 1, "Tier 1 Land", 60, 4, 50),
                new BoardTile(TileType.CommunityChest, 2, "Community Chest"),
                new BoardTile(TileType.RealEstate, 3, "Tier 1 Land", 60, 4, 50),
                new BoardTile(TileType.IncomeTax, 4, "Income Tax"),
                new BoardTile(TileType.TrainStation, 5, "Train Station", 100, 50),
                new BoardTile(TileType.RealEstate, 6, "Tier 2 Land", 120, 8, 50),
                new BoardTile(TileType.ChanceCards, 7, "Chance Cards"),
                new BoardTile(TileType.RealEstate, 8, "Tier 2 Land", 120, 8, 50),
                new BoardTile(TileType.RealEstate, 9, "Tier 2 Land", 120, 8, 50),
                new BoardTile(TileType.Jail, 10, "Jail"),
                new BoardTile(TileType.RealEstate, 11, "Tier 3 Land", 160, 12, 100),
                new BoardTile(TileType.Utility, 12, "Electric Company", 150, 50),
                new BoardTile(TileType.RealEstate, 13, "Tier 3 Land", 160, 12, 100),
                new BoardTile(TileType.RealEstate, 14, "Tier 3 Land", 160, 12, 100),
                new BoardTile(TileType.TrainStation, 15, "Train Station", 100, 50),
                new BoardTile(TileType.RealEstate, 16, "Tier 4 Land", 200, 16, 100),
                new BoardTile(TileType.CommunityChest, 17, "Community Chest"),
                new BoardTile(TileType.RealEstate, 18, "Tier 4 Land", 200, 16, 100),
                new BoardTile(TileType.RealEstate, 19, "Tier 4 Land", 200, 16, 100),
                new BoardTile(TileType.FreeParking, 20, "Free Parking"),
                new BoardTile(TileType.RealEstate, 21, "Tier 5 Land", 240, 20, 150),
                new BoardTile(TileType.ChanceCards, 22, "Chance Cards"),
                new BoardTile(TileType.RealEstate, 23, "Tier 5 Land", 240, 20, 150),
                new BoardTile(TileType.RealEstate, 24, "Tier 5 Land", 240, 20, 150),
                new BoardTile(TileType.TrainStation, 25, "Train Station", 100, 50),
                new BoardTile(TileType.RealEstate, 26, "Tier 6 Land", 280, 24, 150),
                new BoardTile(TileType.RealEstate, 27, "Tier 6 Land", 280, 24, 150),
                new BoardTile(TileType.Utility, 28, "Water Works", 150, 50),
                new BoardTile(TileType.RealEstate, 29, "Tier 6 Land", 280, 24, 150),
                new BoardTile(TileType.GoToJail, 30, "Go To Jail"),
                new BoardTile(TileType.RealEstate, 31, "Tier 7 Land", 320, 28, 200),
                new BoardTile(TileType.RealEstate, 32, "Tier 7 Land", 320, 28, 200),
                new BoardTile(TileType.CommunityChest, 33, "Community Chest"),
                new BoardTile(TileType.RealEstate, 34, "Tier 7 Land", 320, 28, 200),
                new BoardTile(TileType.TrainStation, 35, "Train Station", 100, 50),
                new BoardTile(TileType.ChanceCards, 36, "Chance Cards"),
                new BoardTile(TileType.RealEstate, 37, "Tier 8 Land", 400, 50, 200),
                new BoardTile(TileType.LuxuryTax, 38, "Luxury Tax"),
                new BoardTile(TileType.RealEstate, 39, "Tier 8 Land", 400, 50, 200)
            };


            /*  new BoardTile(TileType.Start, 0, "Start");
              new BoardTile(TileType.RealEstate, 1, "Tier 1 Land",60,4,50);
              new BoardTile(TileType.CommunityChest,2,"Community Chest");
              new BoardTile(TileType.RealEstate, 3, "Tier 1 Land",60,4,50);
              new BoardTile(TileType.IncomeTax, 4, "Income Tax");
              new BoardTile(TileType.TrainStation, 5, "Train Station",100,50);
              new BoardTile(TileType.RealEstate, 6, "Tier 2 Land",120,8,50);
              new BoardTile(TileType.ChanceCards,7,"Chance Cards");
              new BoardTile(TileType.RealEstate, 8, "Tier 2 Land",120,8,50);
              new BoardTile(TileType.RealEstate, 9, "Tier 2 Land",120,8,50);
              new BoardTile(TileType.Jail,10,"Jail");
              new BoardTile(TileType.RealEstate,11,"Tier 3 Land",160,12,100);
              new BoardTile(TileType.Utility, 12, "Electric Company",150,50);
              new BoardTile(TileType.RealEstate,13,"Tier 3 Land",160,12,100);
              new BoardTile(TileType.RealEstate,14,"Tier 3 Land",160,12,100);
              new BoardTile(TileType.TrainStation,15,"Train Station",100,50);
              new BoardTile(TileType.RealEstate,16,"Tier 4 Land",200,16,100);
              new BoardTile(TileType.CommunityChest, 17, "Community Chest");
              new BoardTile(TileType.RealEstate,18,"Tier 4 Land",200,16,100);
              new BoardTile(TileType.RealEstate,19,"Tier 4 Land",200,16,100);
              new BoardTile(TileType.FreeParking, 20, "Free Parking");
              new BoardTile(TileType.RealEstate, 21, "Tier 5 Land",240,20,150);
              new BoardTile(TileType.ChanceCards, 22, "Chance Cards");
              new BoardTile(TileType.RealEstate, 23, "Tier 5 Land",240,20,150);
              new BoardTile(TileType.RealEstate, 24, "Tier 5 Land",240,20,150);
              new BoardTile(TileType.TrainStation, 25, "Train Station", 100, 50);
              new BoardTile(TileType.RealEstate, 26, "Tier 6 Land", 280, 24, 150);
              new BoardTile(TileType.RealEstate, 27, "Tier 6 Land", 280, 24, 150);
              new BoardTile(TileType.Utility, 28, "Water Works", 150, 50);
              new BoardTile(TileType.RealEstate, 29, "Tier 6 Land", 280, 24, 150);
              new BoardTile(TileType.GoToJail, 30, "Go To Jail");
              new BoardTile(TileType.RealEstate, 31, "Tier 7 Land", 320, 28, 200);
              new BoardTile(TileType.RealEstate, 32, "Tier 7 Land", 320, 28, 200);
              new BoardTile(TileType.CommunityChest, 33, "Community Chest");
              new BoardTile(TileType.RealEstate, 34, "Tier 7 Land", 320, 28, 200);
              new BoardTile(TileType.TrainStation, 35, "Train Station", 100, 50);
              new BoardTile(TileType.ChanceCards, 36, "Chance Cards");
              new BoardTile(TileType.RealEstate, 37, "Tier 8 Land", 400, 50, 200);
              new BoardTile(TileType.LuxuryTax,38,"Luxury Tax");
              new BoardTile(TileType.RealEstate, 39, "Tier 8 Land", 400, 50, 200); */










        }
    }
}
