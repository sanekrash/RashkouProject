using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using RashkouProject.Core;
using RashkouProject.Draw;
using RashkouProject.Game;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;


namespace RashkouProject
{
    public class World : _.IState
    {
        int playerX = 20, playerY = 20;
        private Matrix _matrix = new Matrix(79, 25, new Char(' ', White, Black));
        public World()
        {
            Console.Clear();
            WorldDraw();
        }

        public void WorldDraw()
        {
            _matrix.Print(new Matrix(79, 25, new Char(' ', White, Black)), 0, 0);
            _matrix.Print(new Char('@',White,Black),playerX,playerY);
            DrawMatrix.Draw(_matrix.Chars);
        }

        public void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    playerX++;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
            }
            WorldDraw();
        }

        public void Output()
        {
        }
    }
}