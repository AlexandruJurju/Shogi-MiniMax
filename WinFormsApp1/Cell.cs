using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Cell : PictureBox
    {
        public Piece Piece;
        public Color color;
        public int xCoord;
        public int yCoord;

        public Cell()
        {

        }

        public Cell(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.Paint += new PaintEventHandler(paintCellByColor);
        }

        public Cell(Piece piece)
        {
            this.Piece = piece;
            this.Image = piece.Image;
            this.SizeMode = PictureBoxSizeMode.CenterImage;
            if (piece.Color.Equals("B"))
            {
                piece.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }

        public Cell(Piece piece, int xCoord, int yCoord)
        {
            this.Piece = piece;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.Image = piece.Image;
            this.SizeMode = PictureBoxSizeMode.CenterImage;
            if (piece.Color.Equals("B"))
            {
                piece.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }

        public void setPiece(Piece piece)
        {
            this.Piece = piece;
            this.Image = piece.Image;
            this.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public Piece getPiece()
        {
            return this.Piece;
        }

        public void removePiece()
        {
            this.Piece = null;
        }

        public Tuple<int, int> getCoord()
        {
            return new Tuple<int, int>(xCoord, yCoord);
        }

        public void paintCellByColor(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (this.Piece != null)
            {
                if (this.Piece.Color.Equals("W"))
                {
                    g.FillEllipse(Brushes.White, 7, 7, 10, 10);
                }
                else
                {
                    g.FillEllipse(Brushes.Black, 45, 45, 10, 10);
                }
            }
        }

    }
}
