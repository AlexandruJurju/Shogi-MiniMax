using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Player
    {
        private String color;
        private Captured captured;
        internal Captured Captured { get => captured; set => captured = value; }

        public Player(String color)
        {
            this.color = color;
            Captured = new Captured(color);
        }

        public String getColor()
        {
            return this.color;
        }

        public void displayCapturedPieces()
        {

        }
    }
}
