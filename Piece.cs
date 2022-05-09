using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class Piece
    {
        internal Player Player { get; private set; }
        protected int IndexOfBoardX { get; private set; }
        protected int IndexOfBoardY { get; private set; }
        
        internal Piece(Player player)
        {
            Player = player;

        }

        internal bool MoveIntoBoard(int indexOfBoardInput)
        {
            //guard close
            //check if the column we want to put the piece in is full if yes then return true
            if (Board.PlayBoard[indexOfBoardInput, 0] != null)
            {
                return false;
            }

            //set the x index of the piece on the board to the 
            IndexOfBoardX = indexOfBoardInput;

            FallDown();
            Board.CheckForRow();
            GameState.Nextplayer();

            return true;
        }

        internal virtual void FallDown()
        {
            //when the piece needs to fall down when it is already in the bord we empty that Pos on the Board
            Board.PlayBoard[IndexOfBoardX, IndexOfBoardY] = null;

            //start the falling of the piece from the current IndexOfBoardY position
            for (int y = IndexOfBoardY; y < Board.PlayBoard.GetLength(1); y++)
            {
                //if we are at the last row of the board then we break out of the loop so we dont go out of bound of the arrey when we check the pos under this piece (y+1)
                if (y == Board.PlayBoard.GetLength(1)-1)
                {
                    IndexOfBoardY = (Board.PlayBoard.GetLength(1) - 1);
                    Board.PlayBoard[IndexOfBoardX, (Board.PlayBoard.GetLength(1) - 1)] = this;
                    break;
                }
                //check the Pos under the y index we currenly are at if there is a Piece then we stop fulling and regester the current Y index
                if (Board.PlayBoard[IndexOfBoardX, y+1] != null )
                {
                    IndexOfBoardY = y;
                    Board.PlayBoard[IndexOfBoardX, y] = this;
                    break;
                }
            }

            Console.WriteLine($"endPosY is: {IndexOfBoardY}");

        }

        internal virtual void ReactToExplosion(Explosion kaboom)
        {
            Board.PlayBoard[IndexOfBoardX, IndexOfBoardY] = null;
        }

        public override string ToString()
        {
            Type objtype = GetType();
            return objtype.Name;
            
        }

    }

}
