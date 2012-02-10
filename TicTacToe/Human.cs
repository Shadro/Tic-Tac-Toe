// Author: Garrett Goluszka
// Project: Tic-Tac-Toe
// File: Human.cs
// Class for the Human controled player, holds any variables or functions the human player would need to use.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Human : Player
    {
        private char humanmarker;

        //Gets the move of the HumanPlayer and returns it
        public int makemove(char[] gameboard)
        {
            bool bcontinue;
            string moveinput;
            int move;
            bcontinue = true;
            //Run through until the human player enters a valid move
            do
            {
                Console.WriteLine("Enter valid move[0-8]:");
                Console.WriteLine("0 1 2");
                Console.WriteLine("3 4 5");
                Console.WriteLine("6 7 8");
                moveinput = Console.ReadLine();
                //run the try prase to go catch any string strings entered
                if (int.TryParse(moveinput, out move))
                {
                    //If the input is a valid int, then check to see if its in the range
                    if (move < 0 || move > 8) { bcontinue = false; }
                    else if (gameboard[move] != '-') { bcontinue = false; }
                    else bcontinue = true;
                }
                else
                {
                    bcontinue = false;
                }
            }
            while (bcontinue == false);
            return move;
        }

        //Get set of the HumanMarker
        //will either be X or O
        public char HumanMarker
        {
            get { return humanmarker; }
            set { humanmarker = value; }
        }
    }
}
