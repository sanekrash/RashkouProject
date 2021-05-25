using System;

namespace RashkouProject.Draw
{
    public class Matrix
    {
        public Char[,] Chars;

        public int Widht
        {
            get { return (Chars.GetLength(0)); }
        }

        public int Height
        {
            get { return (Chars.GetLength(1)); }
        }

        public Matrix(int w, int h, Char @char)
        {
            Chars = new Char[w, h];
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
            {
                Print(@char, x, y);
            }
        }

        public void Print(Char ch, int x, int y) // изменение произвольного символа в матрице
        {
            Chars[x, y] = ch;
        }

        public void PrintLine(string line, int x, int y, ConsoleColor forColor, ConsoleColor background)
        {
            var w = Widht;
            var sw = line.Length;
            for (int ix = Math.Max(0, x), sx = x - ix;
                ix < w && sx < sw;
                ix++, sx++
            )
            {
                Print(new Char(line[sx], forColor, background), ix, y);
            }
        }

        public void Print(Matrix matrix, int x, int y)
        {
            var w = Widht;
            var h = Height;
            var mw = matrix.Widht;
            var mh = matrix.Height;
            for (int ix = Math.Max(0, x), mx = x - ix;
                ix < w && mx < mw;
                ix++, mx++
            )
            {
                for (int iy = Math.Max(0, y), my = y - iy;
                    iy < h && my < mh;
                    iy++, my++
                )
                {
                    Print(matrix[mx, my], ix, iy);
                }
            }
        }

        public Char this[int x, int y]
        {
            get { return Chars[x, y]; }
            set { Chars[x, y] = value; }
        }
    }
}