using System.Net.Sockets;
using RashkouProject.Game.Entities;

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
        public void Spawn(CharEntity e, int x, int y)
        {
            Tiles[x,y].AddEntity(e);
            e.OnSpawn();
        }

    }
}