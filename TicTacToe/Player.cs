// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: Player.cs
// Interface to have shared functions that the Human and AI player will share

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    interface Player
    {
        //right now the only shared function is the makemove function which returns the players move.
        int makemove(char[] gameboard);
    }
}
