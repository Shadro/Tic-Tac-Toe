// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: AI.cs
// Class is used to hold functions that would need to be called by more than one object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Common
    {

        //Validates the current status of the game and returns the results
        //1 returns a win
        //3 returns an ongoing game
        //0 returns a draw
        public int ValidateGamestate(char[] gameboard, char player)
        {
            // Horizontal Wins
            if (gameboard[0] == player && gameboard[1] == player && gameboard[2] == player ||
                gameboard[3] == player && gameboard[4] == player && gameboard[5] == player ||
                gameboard[6] == player && gameboard[7] == player && gameboard[8] == player ||
                // Vertical Wins
                gameboard[0] == player && gameboard[3] == player && gameboard[6] == player ||
                gameboard[1] == player && gameboard[4] == player && gameboard[7] == player ||
                gameboard[2] == player && gameboard[5] == player && gameboard[8] == player ||
                // Digional Wins
                gameboard[0] == player && gameboard[4] == player && gameboard[8] == player ||
                gameboard[2] == player && gameboard[4] == player && gameboard[6] == player)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    //If there is an open move return 3, this will be known as a playing state
                    if (gameboard[i] == '-')
                    {
                        return 3;
                    }
                    //If all moves are filled in return draw
                    if (i == 8)
                    {
                        return 0;
                    }
                }
            }

            //If code hits here return a 4 which will be an error
            return 3;
        }
    }
}
