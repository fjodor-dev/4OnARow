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
            //if there are no (or less) special Pieces left we select a normal piece or there is no Piece selected
            if (_specialPieces.Count <= 0 || _selectedPiece == null)
            {
                SelectedPiece = new Piece(this);
                return;
            }

            //if there is a normal piece selected we select the first special Piece in the List
            if (SelectedPiece.GetType() == typeof(Piece))
            {
                SelectedPiece = _specialPieces[0];
                return;
            }

            //needed for later
            int indexOfCurrentTypeOfSellectedPiece = 0;

            //get the index of the first type of the current selected piece in the List so in the next loop we start from that index
            for (int i = 0; i < _specialPieces.Count; i++)
            {
                //compare the selected piece Type to the Type of i in the List of pieces
                if (_specialPieces[i].GetType() == SelectedPiece.GetType())
                {
                    indexOfCurrentTypeOfSellectedPiece = i;
                    break;
                }
            }

            //start searching for the next Type of Piece that is in the list of pieces and then select that one
            for (int i = indexOfCurrentTypeOfSellectedPiece; i < _specialPieces.Count; i++)
            {
                //compare the Piece of this index in the list if it is of a difrent subType then we select that Piece
                if (SelectedPiece.GetType() != _specialPieces[i].GetType())
                {
                    SelectedPiece = _specialPieces[i];
                    return;
                }
                //if we are at the end of list then we select a normal Piece
                if (i == _specialPieces.Count - 1)
                {
                    SelectedPiece = new Piece(this);
                    return;
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

            if(_specialPieces.Contains(SelectedPiece))
            {
                _specialPieces.Remove(SelectedPiece);
            }

            //move the piece into the board
            if (SelectedPiece.MoveIntoBoard(indexOfBoard))
            {
                //for the next turn we already select a normal Piece
                SelectedPiece = new Piece(this);
                return true;
            }

            //if it is a valid move we return true so we can use that later for the GUI
            return false;
        }



    }
}
