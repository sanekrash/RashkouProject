using System;
using System.Runtime.CompilerServices;
using RashkouProject.Draw;

namespace RashkouProject.Core
{
    public static class _
    {
        public abstract class IState
        {
            public abstract void Input(ConsoleKeyInfo key);
            public abstract void Output();
            public Matrix GameMatrix;
        }

        public static IState State;
    }
}