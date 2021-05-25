using System;
using System.Runtime.CompilerServices;

namespace RashkouProject.Core
{
    public static class _
    {
        public interface IState 
        {
            void Input(ConsoleKeyInfo key);
            void Output();
        }

        public static IState State;
    }
}
