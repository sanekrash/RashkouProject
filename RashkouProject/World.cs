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
        public World()
        {

        }
        

        public override void Input(ConsoleKeyInfo key)
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
        }

        public override void Output()
        {
            _matrix = new Matrix(79, 25, new Char(' ', Black, Black));
            _matrix.Print(new Char('@',White,Black),playerX,playerY); 
            _matrix.MatrixDrawChar();
        }
    }
}