// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: Program.cs
// Start point of the tic-tac-toe program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState MainGame;
            MainGame = new GameState();
            MainGame.MainGameLoop();
        }
    }
}
