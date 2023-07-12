using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Indicator
    {
        private Label playerIndicator;

        public Indicator()
        {
            playerIndicator = new Label();
            playerIndicator.Visible = true;
            playerIndicator.Location = new Point(850, 300);
            playerIndicator.Size = new Size(100, 100);
            playerIndicator.BackColor = Color.Green;
            playerIndicator.Font = new Font("Times New Roman", 45);
            playerIndicator.TextAlign = ContentAlignment.MiddleCenter;
        }

        public Label getPlayerIndicator()
        {
            return playerIndicator;
        }

        public void checkPlayer(string currentPlayerIndicator)
        {
            playerIndicator.Text = currentPlayerIndicator;
            if (currentPlayerIndicator.Equals("P1"))
            {
                playerIndicator.ForeColor = Color.White;
            }
            else
            {
                playerIndicator.ForeColor = Color.Black;
            }
        }
    }
}
