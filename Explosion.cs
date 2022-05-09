using System;

namespace _4OnARow
{
    internal class Explosion
    {
        internal bool ExplosionOngoing { get; set; }
        internal int IndexOfBoardX { get; private set; }
        internal int IndexOfBoardY { get; private set; }
        public Explosion(int indexOfBoardX, int indexOfBoardY)
        {
            IndexOfBoardX = indexOfBoardX;
            IndexOfBoardY = indexOfBoardY;
        }

        internal void HExplosion()
        {
            try
            {
                ExplosionOngoing = true;
                int x = IndexOfBoardX;
                while (ExplosionOngoing)
                {
                    x++;
                    Piece piece = Board.PlayBoard[x, IndexOfBoardY];
                    TryToBlowUpThisPieceIfNotNull(piece);
                }
            }
            catch (IndexOutOfRangeException)
            {}
            ExplosionOngoing = false;

            try
            {
                ExplosionOngoing = true;
                int x = IndexOfBoardX;
                while (ExplosionOngoing)
                {
                    x--;
                    Piece piece = Board.PlayBoard[x, IndexOfBoardY];
                    TryToBlowUpThisPieceIfNotNull(piece);
                }
            }
            catch (IndexOutOfRangeException)
            { }
            ExplosionOngoing = false;
            Board.LetAllPiecesFallDown();
        }

        internal void VExplosion()
        {
            try
            {
                ExplosionOngoing = true;
                int y = IndexOfBoardY;
                while (ExplosionOngoing)
                {
                    y++;
                    Piece piece = Board.PlayBoard[IndexOfBoardX, y];
                    TryToBlowUpThisPieceIfNotNull(piece);
                }
            }
            catch (IndexOutOfRangeException)
            {}
            ExplosionOngoing = false;

            try
            {
                ExplosionOngoing = true;
                int y = IndexOfBoardY;
                while (ExplosionOngoing)
                {
                    y--;
                    Piece piece = Board.PlayBoard[IndexOfBoardX, y];
                    TryToBlowUpThisPieceIfNotNull(piece);
                }
            }
            catch (IndexOutOfRangeException)
            { }
            ExplosionOngoing = false;
        }
        private void TryToBlowUpThisPieceIfNotNull(Piece piece)
        {
            if (piece != null)
            {
                piece.ReactToExplosion(this);
            }
        }

    }
}