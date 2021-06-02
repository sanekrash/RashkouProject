using System.Net.Sockets;
using RashkouProject.Draw;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

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
            Tiles[e.X, e.Y].AddEntity(e);
            e.OnSpawn();
        }

        public void Despawn(CharEntity e)
        {
            Tiles[e.X, e.Y].DeleteEntity(e);
            e.OnDespawn();
        }

        public Matrix Camera(int x, int y)
        {
            var Matrix = new Matrix(79, 25, new Char(' ', Black, Black));
            for (int i = x - 39; i < x + 39; i++)
            {
                for (int z = y - 12; z < y + 12; z++)
                {
                    if (i >= 0 && i < Tiles.GetLength(0) && z >= 0 &&
                        z < Tiles.GetLength(1))
                    {
                        Matrix[i + 39 - x, z + 12 - y] = Tiles[i, z].PrintTile();

                    }
                }
            }

            return Matrix;
        }
    }
}