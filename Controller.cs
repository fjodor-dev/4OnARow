using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    public static class Controller
    {
        public static void MakeTheGame(int boardWidht, int boardHeight, int amountOfPlayers)
        {

            Board.MakeBoard(boardWidht, boardHeight);
            GameState.MakeNewPlayers(amountOfPlayers);

        }

        public static void SelectPiece()
        {
            GameState.TurnOfPlayer.SelectPiece();
            
        }

        public static void AddSelectedPieceToBoard(int indexOfBoard)
        {
            //guard close, check if the index is inbound
            if (indexOfBoard<0  || indexOfBoard >= Board.PlayBoard.GetLength(0))
            {
                return;
            }

            //Console.WriteLine("" + GameState.TurnOfPlayer.PlayerId);//test
            GameState.TurnOfPlayer.AddSelectedPieceToBoard(indexOfBoard);
        }

        static void Main(string[] args)
        {
            MakeTheGame(13,9,4);

            do
            {
                GameState.TurnOfPlayer.SelectPiece();
                Console.WriteLine($"selected piece: {GameState.TurnOfPlayer.SelectedPiece}");
                Console.ReadLine();


                // GameState.TurnOfPlayer.SelectPiece();

                // Console.WriteLine(Board.PrintBoard());

                // Console.WriteLine($"Turn Of Player: {GameState.TurnOfPlayer.PlayerId}");
                // Console.WriteLine($"selected piece: {GameState.TurnOfPlayer.SelectedPiece}");

                // int input = 100;

                // if(int.TryParse(Console.ReadLine(),out input) == false)
                // {
                //     continue;
                // }

                // AddSelectedPieceToBoard(input);

                //Console.Clear();
            }

            while (GameState.WinningPlayer == null);

            Console.WriteLine(Board.PrintBoard());

            Console.WriteLine($"player: {GameState.WinningPlayer.PlayerId} has won the game!");


            Console.ReadKey();

        }






    }
}
