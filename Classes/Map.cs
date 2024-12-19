using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace P230611988.Classes
{
    internal class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile[,] Tiles { get; set; }

        public Map(int height, int width)
        {
            Width = 18;
            Height = 6;
            Tiles = new Tile[height, width];

            // 初始化地图格子
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Tiles[i, j] = new Tile(i, j, true); // 设为可通行
                }
            }
        }

        public bool IsWalkable(int x, int y)
        {
            if (x >= 0 && x < Height && y >= 0 && y <Width)
            {
                return Tiles[x, y].IsWalkable;
            }
            else return false;
        }

    }




    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWalkable { get; set; }
        
        public Tile(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
        }
    }



}


