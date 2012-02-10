// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: AI.cs
// Class for the computer player holds all variables and functions used
// main process being the min and max functions that return the best move for the computer
// so a game will either end in a draw or a win for the computer


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class AI : Player
    {
        // bestmove struct which is the return value of min and max
        // this returns the score of the game board (human win, computer win, or draw)
        // and the position that was chosen at the end.
        struct bestmove
        {
            private int score;
            private int position;

            public int Score
            {
                get { return score; }
                set { score = value; }
            }

            public int Position
            {
                get { return position; }
                set { position = value; }
            }
        }

        private char aimarker;
        private char humanmarker;
        bestmove returnmove = new bestmove();
        //Common object is created for validating the gameboard
        Common util = new Common();

        public int makemove(char[] gameboard)
        {
            // get the humanmarker, or enemy marker
            humanmarker = GetEnemyPlayer(aimarker);
            // call the max function to start the minmax process to get the best move
            returnmove = max(gameboard);
            return returnmove.Position;
        }

        //function returs the marker of the enemy player
        private char GetEnemyPlayer(char AIPlayer)
        {
            if (AIPlayer == 'X') return 'O';
            else return 'X';
        }

        //The max part of minmax, looks for the best move for the computer
        private bestmove max(char[] gameboard)
        {
            //Create variables used in the function
            //bestscore is for the best score bestposition for the position
            //move is used for the responce of min and what is returned
            //gamestate is used to store the current state of the gameboard
            //validmoves is an array of the moves open to the computer
            int bestscore;
            int bestposition;
            bestmove move = new bestmove();
            int gamestate;
            int[] validmoves;

            //setting default values
            bestscore = -1;
            move.Score = -2;
            bestposition = -1;

            //get an array of the moves the player needs to run though
            validmoves = GenerateValidMoves(gameboard);

            foreach (int i in validmoves)
            {
                //make the move
                gameboard[i] = aimarker;
                //check gamestate
                gamestate = util.ValidateGamestate(gameboard, aimarker);
                //if game is still on going call min
                if (gamestate == 3)
                {
                    move = min(gameboard);

                    //If the reutrn score from min is better than the current bestscore
                    //set teh return value to the best score and the position to the max function made
                    if (move.Score > bestscore)
                    {
                        bestscore = move.Score;
                        bestposition = i;
                    }
                }
                //else the max player won, set the bestscore to the gamestate and the bestposition to
                //the value currently played
                else
                {
                    if (gamestate > bestscore)
                    {
                        bestscore = gamestate;
                        bestposition = i;
                    }
                }

                //Undo the move made to go through and make the next move
                gameboard[i] = '-';
            }
            //set the move struct with the bestscore and position and return it
            move.Score = bestscore;
            move.Position = bestposition;
            return move;
        }

        //The min part of minmax, works about the same as max expect it looks for the best move of the enemy
        private bestmove min(char[] gameboard)
        {
            int bestscore;
            int bestposition;
            bestmove move = new bestmove();
            int gamestate;
            int[] validmoves;

            bestscore = 2;
            move.Score = -2;
            bestposition = 2;

            validmoves = GenerateValidMoves(gameboard);

            foreach (int i in validmoves)
            {
                gameboard[i] = humanmarker;
                gamestate = util.ValidateGamestate(gameboard, humanmarker);

                if (gamestate == 1) gamestate = -1;
                if (gamestate == 3)
                {
                    move = max(gameboard);
                    if (move.Score < bestscore)
                    {
                        bestscore = move.Score;
                        bestposition = i;
                    }
                }
                else
                {
                    if (gamestate < bestscore)
                    {
                        bestscore = gamestate;
                        bestposition = i;
                    }
                }

                gameboard[i] = '-';
            }

            move.Score = bestscore;
            move.Position = bestposition;
            return move;
        }

        //function to get an array of the valid moves for either max or min to run through
        private int[] GenerateValidMoves(char[] board)
        {
            List<int> ValidMoves = new List<int>();
            int i;
            //int v;
            //v = 0;
            for (i = 0; i < 9; i++)
            {
                if (board[i] == '-')
                {
                    ValidMoves.Add(i);
                }
            }

            return ValidMoves.ToArray();
        }

        //get set of the AIMarker so it can be set
        public char AIMarker 
        { 
            get { return aimarker; }
            set { aimarker = value; }
        }

        }
    }
//}
