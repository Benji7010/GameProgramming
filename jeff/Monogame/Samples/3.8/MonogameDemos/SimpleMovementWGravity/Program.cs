﻿using System;

namespace SimpleMovementWGravity
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1(2))
                game.Run();
        }
    }
}
