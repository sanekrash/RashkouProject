using System.Net.Sockets;

namespace RashkouProject.Game
{
    public class Location
    {
        public ContainsEntity[,] Tiles;
        public Location(int w, int h)
        {
            Tiles = new ContainsEntity[w, h];
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
            {
                Tiles[x, y] = new ContainsEntity();
            }
        }


    }
}