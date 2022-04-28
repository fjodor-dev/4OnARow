using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class Piece
    {

        private Player _player;
        private int _indexOfBoardX;
        private int _indexOfBoardY;

        internal Player Player { get => _player; private set => _player = value; }

        internal Piece(Player player)
        {
            Player = player;

        }

        internal virtual bool MoveIntoBoard(int indexOfBoardInput)
        {
            //guard close
            //check if the column we want to put the piece in is full if yes then return true
            if (Board.PlayBoard[indexOfBoardInput, 0] != null)
            {
                return false;
            }

            //set the x index of the piece on the board to the 
            _indexOfBoardX = indexOfBoardInput;

            FallDown();
            Board.CheckForRow();
            GameState.Nextplayer();

            return true;
        }

        protected virtual void FallDown()
        {
            int endPosY = 0;

            for (int i = 0; i < Board.PlayBoard.GetLength(1); i++)
            {
                if (Board.PlayBoard[_indexOfBoardX, i] == null)
                {
                    endPosY = i;
                }
            }

            _indexOfBoardY = endPosY;
            Board.PlayBoard[_indexOfBoardX, endPosY] = this;
        }

        public override string ToString()
        {
            Type objtype = GetType();
            return objtype.Name;
            
        }

    }

}
