using System;
using System.Collections.Generic;
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
        public bool[,] VisionMap;
        public List<CharEntity> CharEntities = new List<CharEntity>();
        public List<BulletEntity> BulletEntities = new List<BulletEntity>();
        public List<MapEntity> MapEntities = new List<MapEntity>();

        public int LenghtX, LenghtY;

        public Location(int w, int h)
        {
            Tiles = new Tile[w, h];
            VisionMap = new bool[w, h];
            LenghtX = w;
            LenghtY = h;
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
            {
                Tiles[x, y] = new Tile();
            }
        }

        public void Spawn(CharEntity e)
        {
            CharEntities.Add(e);
            Tiles[e.X, e.Y].AddEntity(e);
            e.OnSpawn();
        }
        public void Spawn(MapEntity e)
        {
            MapEntities.Add(e);
            Tiles[e.X, e.Y].AddEntity(e);
            e.OnSpawn();
        }
        public void Spawn(BulletEntity e)
        {
            BulletEntities.Add(e);
            Tiles[e.X, e.Y].AddEntity(e);
            e.OnSpawn();
        }

        public void Despawn(CharEntity e)
        {
            CharEntities.Remove(e);
            Tiles[e.X, e.Y].DeleteEntity(e);
            e.OnDespawn();
        }
        public void Despawn(MapEntity e)
        {
            MapEntities.Remove(e);
            Tiles[e.X, e.Y].DeleteEntity(e);
            e.OnDespawn();
        }
        public void Despawn(BulletEntity e)
        {
            BulletEntities.Remove(e);
            Tiles[e.X, e.Y].DeleteEntity(e);
            e.OnDespawn();
        }

        public void CastRay(int x, int y, int range, float vectorX, float vectorY)
        {
            var ox = x + 0.5f;
            var oy = y + 0.5f;
            VisionMap[x, y] = true;
            ox = ox + vectorX;
            oy = oy + vectorY;
            for (int j = 1; j < range; j++)
            {
                if (0 > ox || ox > World.CurrentLocation.Tiles.GetLength(0))
                    return;
                if (0 > oy || oy > World.CurrentLocation.Tiles.GetLength(1))
                    return;
                VisionMap[(int) ox, (int) oy] = true;
                if (Tiles[(int) ox,(int) oy].IsTransparent() == false)
                    return;
                ox = ox + vectorX;
                oy = oy + vectorY;
            }
        }
        public void ViewMap(int x, int y, int range)
        {
            for (int i = 0; i < LenghtX; i++)
            for (int j = 0; j < LenghtY; j++)
            {
                VisionMap[i, j] = false;
            }
            float vectorX, vectorY;
            for (int i = 0; i < 360; i++)
            {
                vectorX=(float) Math.Cos(i*0.01745f);
                vectorY=(float) Math.Sin(i*0.01745f);
                CastRay(x,y,range,vectorX,vectorY);
            }
        }


        public Matrix Camera(int x, int y)
        {
            var Matrix = new Matrix(79, 25, new Char(' ', Black, Black));
            for (int i = x - 39; i < x + 39; i++)
            {
                for (int z = y - 12; z < y + 12; z++)
                {
                    if (i >= 0 && i < Tiles.GetLength(0) && z >= 0 &&
                        z < Tiles.GetLength(1) && VisionMap[i,z])
                    {
                        Matrix[i + 39 - x, z + 12 - y] = Tiles[i, z].PrintTile();
                    }
                }
            }

            return Matrix;
        }


    }
}