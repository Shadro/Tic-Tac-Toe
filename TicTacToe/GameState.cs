// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: GameState.cs
// Class is used to run the game, runs though the turns of the players until an end is reached

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class GameState
    {
        private Human HumanPlayer;
        private AI AIPlayer;
        // 1 = HumanTurn
        // 2 = AITurn
        // 3 = HumanWin
        // 4 = AIWin
        // 0 = Draw
        private int GameStatus;
        private int ReturnStatus;
        private Common util;
        private char[] gameboard;

        //Constructor that sets up default game
        public GameState()
        {
            HumanPlayer = new Human();
            AIPlayer = new AI();
            util = new Common();
            gameboard = new char[9];
            fillboard();
            GameStatus = 1;
            ReturnStatus = 0;
        }


        //Main game loop, runs though players turns until there is a conclusion to the game
        public void MainGameLoop()
        {
            //Setting the player values
            HumanPlayer.HumanMarker = 'X';
            AIPlayer.AIMarker = 'O';

            //run through player turns until there is an ending state
            do
            {
                Console.WriteLine();
                drawboard(gameboard);
                //If it is the HumanPlayers turn
                if (GameStatus == 1)
                {
                    gameboard[HumanPlayer.makemove(gameboard)] = HumanPlayer.HumanMarker;
                    ReturnStatus = util.ValidateGamestate(gameboard, HumanPlayer.HumanMarker);
                    switch (ReturnStatus)
                    {
                        case 1:
                            GameStatus = 3;
                            break;
                        case 0:
                            GameStatus = 0;
                            break;
                        default:
                            GameStatus = 2;
                            break;
                    }
                }
                //If it is not the HumanPlayers turn it is the AIPlayers turn
                else
                {
                    gameboard[AIPlayer.makemove(gameboard)] = AIPlayer.AIMarker;
                    ReturnStatus = util.ValidateGamestate(gameboard, AIPlayer.AIMarker);
                    switch (ReturnStatus)
                    {
                        case 1:
                            GameStatus = 4;
                            break;
                        case 0:
                            GameStatus = 0;
                            break;
                        default:
                            GameStatus = 1;
                            break;
                    }
                }

            }
            while (GameStatus == 1 || GameStatus == 2);

            //When outside of the loop run through a case to see what the ending game status is
            switch (GameStatus)
            {
                case 3:
                    //This should never happen
                    Console.WriteLine();
                    drawboard(gameboard);
                    Console.WriteLine();
                    Console.WriteLine("Human Player Wins!");
                    break;
                case 4:
                    Console.WriteLine();
                    drawboard(gameboard);
                    Console.WriteLine();
                    Console.WriteLine("AI Player Wins!");
                    break;
                case 0:
                    Console.WriteLine();
                    drawboard(gameboard);
                    Console.WriteLine();
                    Console.WriteLine("Draw!");
                    break;
            }

        }

        //Fills board with defined values, can set any type of test with this
        private void fillboard()
        {
            gameboard[0] = '-';
            gameboard[1] = '-';
            gameboard[2] = '-';

            gameboard[3] = '-';
            gameboard[4] = '-';
            gameboard[5] = '-';

            gameboard[6] = '-';
            gameboard[7] = '-';
            gameboard[8] = '-';
        }

        //Print out the current gameboard
        private void drawboard(char[] gameboard)
        {
            Console.WriteLine(gameboard[0] + " " + gameboard[1] + " " + gameboard[2]);
            Console.WriteLine(gameboard[3] + " " + gameboard[4] + " " + gameboard[5]);
            Console.WriteLine(gameboard[6] + " " + gameboard[7] + " " + gameboard[8]);
        }
    }
}
