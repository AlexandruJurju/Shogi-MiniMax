using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class PlayerController
    {
        Player player1;
        Player player2;
        Player currentPlayer;
        private bool turnPlayer1;
        private bool turnPlayer2;

        public PlayerController(Player player1, Player player2, Player currentPlayer, bool turnPlayer1, bool turnPlayer2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = currentPlayer;
            this.turnPlayer1 = turnPlayer1;
            this.turnPlayer2 = turnPlayer2;
        }

        public void changeTurn()
        {
            if (turnPlayer1 == true)
            {
                turnPlayer1 = false;
                turnPlayer2 = true;
                currentPlayer = player2;
            }
            else
            {
                turnPlayer2 = false;
                turnPlayer1 = true;
                currentPlayer = player1;
            }
        }

        public bool getTurnPlayer1()
        {
            return turnPlayer1;
        }

        public bool getTurnPlayer2()
        {
            return turnPlayer2;
        }

        public Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        public Player getPlayer1()
        {
            return player1;
        }

        public Player getPlayer2()
        {
            return player2;
        }

        public string getCurrentPlayerIndicator()
        {
            if (currentPlayer == player1)
            {
                return "P1";
            }
            else
            {
                return "P2";
            }
        }
    }
}
