using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class Player
    {

        private List<Piece> _specialPieces = new List<Piece>();
        private Piece _selectedPiece;
        private static int _playersCreated;
        private int _playerId;

        public int PlayerId { get => _playerId; }
        internal Piece SelectedPiece { get => _selectedPiece; private set => _selectedPiece = value; }

        //constructor
        internal Player()
        {
            _playersCreated++;
            _playerId = _playersCreated;
            InitializeSpecialPieces();
            SelectedPiece = new Piece(this);
        }

        //make all the specail pieces this player needs
        //add all the specail pieces the player can use
        private void InitializeSpecialPieces()
        {
            _specialPieces.Add(new HBom(this));
            _specialPieces.Add(new HBom(this));
            _specialPieces.Add(new VBom(this));
            _specialPieces.Add(new VBom(this));
            _specialPieces.Add(new Bunker(this));
            _specialPieces.Add(new Bunker(this));

        }

        //cycle trew list of pieces
        //select the next piece in the list that is of difrent subtype
        //if we are at the end of the list select normal piece
        internal void SelectPiece()
        {
            for (int i = 0; i < _specialPieces.Count; i++)
            {
                //resets to 0 so we can cycle trew it once more
                if (i == _specialPieces.Count - 1)
                {
                    SelectedPiece = new Piece(this);
                }

            }

            for (int i = 0; i < _specialPieces.Count; i++)
            {
                //resets to 0 so we can cycle trew it once more
                if (i == _specialPieces.Count-1)
                {
                    SelectedPiece = new Piece(this);
                }
                
            }
        }

        internal bool AddSelectedPieceToBoard(int indexOfBoard)
        {
            //if there is no piece selected select a standart piece
            if (SelectedPiece == null)
            {
                SelectedPiece = new Piece(this);
            }

            //move the piece into the board
            if (SelectedPiece.MoveIntoBoard(indexOfBoard))
            {
                return true;
            }

            //for the next turn we already select a normal Piece
            SelectedPiece = new Piece(this);
            //if it is a valid move we return true so we can use that later for the GUI
            return false;
        }



    }
}
