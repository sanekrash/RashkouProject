using System;

namespace RashkouProject.Draw
{
    public static class DrawMatrix
    {
        public static void Draw(Char[,] matrix)
        {
            Console.Clear();
            int height = matrix.GetLength(1);
            int width = matrix.GetLength(0);

            for (int y = 0; y < height; y++)
            {
                Console.WriteLine();
                for (int x = 0; x < width; x++)
                {
                    Console.BackgroundColor = matrix[x, y].BackColor;
                    Console.ForegroundColor = matrix[x, y].ForColor;
                    Console.Write(matrix[x, y].Glyph);
                }
            }
        }
    }
}