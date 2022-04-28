using System;
using System.Collections.Generic;

namespace _4OnARow
{
    internal class GameState
    {
        private static List<Player> _players = new List<Player>();

        private static Player _winningPlayer;
        
        private static Player _turnOfPlayer;

        internal static Player TurnOfPlayer 
        {
            get
            {
                return _turnOfPlayer;
            }
            private set
            {
                _turnOfPlayer = value;
            } 
        }

        internal static Player WinningPlayer 
        { 
            get => _winningPlayer; 
            set
            {
                if (_winningPlayer == null)
                {
                    _winningPlayer = value;
                }
            } 
        }

        //give the turn to the next player automaticly
        //cycle trew all the players
        internal static void Nextplayer()
        {
            if (_players.Count == 0)
            { 
                //there are no players
                return;
            }
            if (TurnOfPlayer == null)
            { 
                TurnOfPlayer = _players[0];
                return;
            }
            //if it is no players turn give the turn to the first 
            if (_turnOfPlayer.PlayerId==_players.Count)
            {
                _turnOfPlayer = _players[0];
                return;
            }
            int playerIdOfCurrentTurn = _turnOfPlayer.PlayerId;
            TurnOfPlayer = _players[playerIdOfCurrentTurn++];
            return;
        }

        internal static void MakeNewPlayers(int amountOfPlayers)
        {
            //we need atleast 2 players
            if (amountOfPlayers<2)
            {
                amountOfPlayers = 2;
            }
            //max 4 players
            else if(amountOfPlayers>4)
            {
                amountOfPlayers = 4;
            }
            //delete all the players
            _players.Clear();

            //make the players in this loop
            for (int i = 0; i < amountOfPlayers; i++)
            {
                _players.Add(new Player());
                //Console.WriteLine($"player{_players[i].PlayerId}");
            }
            //set the first turn for player 0
            _turnOfPlayer = _players[0];
        }
    }
}
