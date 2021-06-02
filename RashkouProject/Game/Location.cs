using System.Net.Sockets;
using RashkouProject.Game.Entities;

namespace RashkouProject.Game
{
    public class Location
    {
        public Tile[,] Tiles;
        public Location(int w, int h)
        {
            Tiles = new Tile[w, h];
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
            {
                Tiles[x, y] = new Tile();
            }
            
        }
        public void Spawn(CharEntity e)
        {
            Tiles[e.X,e.Y].AddEntity(e);
            e.OnSpawn();
        }
        public void Despawn(CharEntity e)
        {
            Tiles[e.X,e.Y].DeleteEntity(e);
            e.OnDespawn();
        }
    }
}