using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal static class Board
    {
        private static Piece[,] _playBoard;

        internal static Piece[,] PlayBoard
        {
            get { return _playBoard; }
            private set { _playBoard = value; }
        }

        internal static void MakeBoard(int widht, int height)
        {
            PlayBoard = new Piece[widht, height];
        }

        //checks if there is a row with the lenght needed to win
        //if there is a row detected on the bord then it sets GameState.WinningPlayer
        //very big complex method! 
        internal static void CheckForRow()
        {
            int lenghtToWin = 4;
            // if  lenghtOfDetectedRow == l lenghtToWin then we can stop
            int lenghtOfDetectedRow = 0;
            //to remember the player of the pieces of the detected row
            Player currentPlayerWeAreChecking;

            //cache the height and with of the bord
            int boardWidth = PlayBoard.GetLength(0);
            int boardHeigth = PlayBoard.GetLength(1);

            // inner function that we can use multiple times when we are going to check the rows
            //what it does is that if u put in a piece it checks if it is from the same player as the previes pieces thats put in
            //if you put in 4 Pieces of the same player after eachother then there is 4 on a row and returs true and it sets the winning Player in GameState
            //if you put in a new piece then currentPlayerWeAreChecking is that of the new piece 
            //!when you use this method to check a new row make sure to reset: "lenghtOfDetectedRow = 0;"  !!!!!
            bool CheckThisPos(Piece piece)
            {
                //use try catch in case of a NullReferenceException that we can get if invoke( piece.Player.PlayerId ) we could also use a guard close but i wanted to show that i can also do it with try/catch
                try
                {
                    //the piece that is here here is not of the same player we where checking 4 on a row for reset lenghtOfDetectedRow to 0 and currentPlayerIdWeAreChecking is that of this piece
                    if (currentPlayerWeAreChecking != piece.Player)
                    {
                        currentPlayerWeAreChecking = piece.Player;
                        lenghtOfDetectedRow = 1;
                        return false;
                    }
                    //if we are here then the player id matches and the row we detected grows
                    lenghtOfDetectedRow++;
                    //set the winning player if the lengt of the detected row is of the right lenght
                    if (lenghtOfDetectedRow >= lenghtToWin)
                    {
                        GameState.WinningPlayer = currentPlayerWeAreChecking;
                        return true;
                    }
                    return false;
                }
                catch (NullReferenceException)
                {
                    currentPlayerWeAreChecking = null;
                    lenghtOfDetectedRow = 0;
                    return false;
                }
            }

            //check all the vertical rows that there are
            for (int allVerticalRows = 0; allVerticalRows < boardHeigth; allVerticalRows++)
            {
                //guard close
                //when there is already a winning player detected we return out of this method
                if (GameState.WinningPlayer != null)
                {
                    return;
                }

                currentPlayerWeAreChecking = null;
                lenghtOfDetectedRow = 0;
                int x;
                //check all the horizantal positions for allVerticalRows
                //going from left to right
                for (x = 0; x < boardWidth; x++)
                {
                    if (CheckThisPos(PlayBoard[x, allVerticalRows]))
                    {
                        return;
                    }
                }
                //check all the diaganol positions for allVerticalRows
                //going from north-west towards south-east
                try
                {
                    currentPlayerWeAreChecking = null;
                    lenghtOfDetectedRow = 0;
                    //use the starting position of the vertical index we currently iterate over
                    int y = allVerticalRows;
                    x = 0;
                    //if the winning player is known then the loop stops
                    //and it also stops when we go outside of the board then we get a IndexOutOfRangeException
                    //and we also need to be before the corner of the board where a row simply isnt posible because the corner is to small for a diagonal row that you can win with
                    while (GameState.WinningPlayer == null && allVerticalRows < boardHeigth - (lenghtToWin - 1))
                    {
                        CheckThisPos(PlayBoard[x, y]);
                        x++;
                        y++;
                    }
                }
                catch (IndexOutOfRangeException)
                { }
                //check all the diaganol positions for allVerticalRows
                //going from south-west towards north-east
                try
                {
                    currentPlayerWeAreChecking = null;
                    lenghtOfDetectedRow = 0;
                    //use the starting position of the vertical index we currently iterate over
                    int y = allVerticalRows;
                    x = 0;
                    //if the winning player is known then the loop stops
                    //and it also stops when we go outside of the board then we get a IndexOutOfRangeException
                    //and we also need to be before the corner of the board where a row simply isnt posible because the corner is to small for a diagonal row that you can win with
                    while (GameState.WinningPlayer == null && allVerticalRows >= lenghtToWin-1)
                    {
                        CheckThisPos(PlayBoard[x, y]);
                        x++;
                        y--;
                    }
                }
                catch (IndexOutOfRangeException)
                { }
                //now it goes to the next vertical index
            }

            //check all the Horizantal rows that there are
            for (int allCollumns = 0; allCollumns < boardWidth; allCollumns++)
            {
                //guard close
                //when there is already a winning player detected we return out of this method
                if (GameState.WinningPlayer != null)
                {
                    return;
                }

                currentPlayerWeAreChecking = null;
                lenghtOfDetectedRow = 0;
                int y;
                //check all the vertical positions for allCollumns
                //going from norht to south
                for (y = 0; y < boardHeigth; y++)
                {
                    if (CheckThisPos(PlayBoard[allCollumns, y]))
                    {
                        return;
                    }
                }
                //check all the diaganol positions for allCollumns
                //going from north-west towards south-east
                try
                {
                    currentPlayerWeAreChecking = null;
                    lenghtOfDetectedRow = 0;
                    int x = allCollumns;
                    y = 0;
                    //if the winning player is known then the loop stops
                    //and it also stops when we go outside of the board then we get a IndexOutOfRangeException
                    //and we also need to be before the corner of the board where a row simply isnt posible because the corner is to small for a diagonal row that you can win with
                    while (GameState.WinningPlayer == null && allCollumns < boardWidth - (lenghtToWin - 1))
                    {
                        CheckThisPos(PlayBoard[x, y]);
                        x++;
                        y++;
                    }
                }
                catch (IndexOutOfRangeException)
                { }
                //check all the diaganol positions for allCollumns
                //going from south-west towards norht-east
                try
                {
                    currentPlayerWeAreChecking = null;
                    lenghtOfDetectedRow = 0;
                    int x = allCollumns;
                    //we set y to the under side of the board because we want to start from the buttom to upwards
                    y = (boardHeigth - 1);

                    //if the winning player is known then the loop stops
                    //and it also stops when we go outside of the board then we get a IndexOutOfRangeException
                    //and we also need to be before the corner of the board where a row simply isnt posible because the corner is to small for a diagonal row that you can win with
                   while (GameState.WinningPlayer == null && allCollumns < boardWidth - (lenghtToWin - 1))
                    {
                        CheckThisPos(PlayBoard[x, y]);
                        x++;
                        y--;
                    }
                }
                catch (IndexOutOfRangeException)
                { }
                //now it goes to the next horizantal index ("collumn")
            }
        }//WARNING: Headache imminent!

        //if there has bin a Explosion All Pieces Need To Fall Down
        internal static void LetAllPiecesFallDown()
        {
            //go over evry cullumn starting down going up
            for (int y = PlayBoard.GetLength(1) - 1; y >= 0; y--)
            {
                //go over evry row 
                for (int x = PlayBoard.GetLength(0) - 1; x >= 0; x--)
                {
                    //prevent nullPointerRefrenceExeptoin
                    if (PlayBoard[x, y] != null)
                    {
                        //let the Piece on this pos falldown
                        PlayBoard[x, y].FallDown();
                    }
                }
            }
        }

        //returns a string that represent the bord
        internal static string PrintBoard()
        {
            string result = "   ";

            for (int x = 0; x < PlayBoard.GetLength(0); x++)
            {
                if (x<10)
                {
                    result += $"_0{x}_";
                    continue;
                }
                result += $"_{x}_";
            }
            result += "__\n";

            for (int y = 0; y < _playBoard.GetLength(1); y++)
            {
                if (y < 10)
                {
                    result += $"0{y} ";
                } 
                else 
                {
                    result += $"{y} ";
                }
                
                for (int x = 0; x < _playBoard.GetLength(0); x++)
                {
                    //caching of the Piece that is on this POS
                    Piece pieceOnThisPos = _playBoard[x, y];

                    //if it is null we continue the loop so we dont get a NullReferenceException
                    if (pieceOnThisPos == null)
                    {
                        result += $"| _ ";
                        continue;
                    }

                    //choose the right icon for the piece depending on the Player.playerId of the Piece
                    switch (pieceOnThisPos.Player.PlayerId)
                    {
                        case 1: result += "| A "; continue;
                        case 2: result += "| B "; continue;
                        case 3: result += "| C "; continue;
                        case 4: result += "| D "; continue;
                        default: result += "| ? "; continue;
                    }

                }
                result += "|\n";
            }
            return result;
        }
    }
}
