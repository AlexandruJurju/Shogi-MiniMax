using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Captured
    {
        private List<Tuple<Cell, TextBox>> pieces = new List<Tuple<Cell, TextBox>>();

        internal List<Tuple<Cell, TextBox>> Pieces { get => pieces; set => pieces = value; }

        public Captured(String color)
        {

            int firstIndex;
            if (color.Equals("W"))
            {
                firstIndex = -1;

            }
            else
            {
                firstIndex = -2;
            }
            int iterator = 0;

            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Pawn(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Bishop(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Rook(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Lance(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Knight(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Silver(color), firstIndex, iterator++), new TextBox()));
            Pieces.Add(new Tuple<Cell, TextBox>(new Cell(new Gold(color), firstIndex, iterator++), new TextBox()));



            for (int i = 0; i < Pieces.Count; i++)
            {
                Pieces[i].Item2.Text = "1";
            }
        }

        public void updateCapturedFromModel(Model model, string color)
        {
            if (color.Equals("W"))
            {
                foreach (var captured in model.getWhiteCaptured())
                {
                    string pieceType = captured.getPiece().Substring(1, 2);
                    string count = captured.getCount().ToString();

                    switch (pieceType)
                    {
                        case "PW":
                            pieces[0].Item2.Text = count;
                            break;
                        case "BS":
                            pieces[1].Item2.Text = count;
                            break;
                        case "RK":
                            pieces[2].Item2.Text = count;
                            break;
                        case "LN":
                            pieces[3].Item2.Text = count;
                            break;
                        case "KN":
                            pieces[4].Item2.Text = count;
                            break;
                        case "SG":
                            pieces[5].Item2.Text = count;
                            break;
                        case "GG":
                            pieces[6].Item2.Text = count;
                            break;
                    }
                }
            }
            else
            {

                foreach (var captured in model.getBlackCaptured())
                {
                    string pieceType = captured.getPiece().Substring(1, 2);
                    string count = captured.getCount().ToString();

                    switch (pieceType)
                    {
                        case "PW":
                            pieces[0].Item2.Text = count;
                            break;
                        case "BS":
                            pieces[1].Item2.Text = count;
                            break;
                        case "RK":
                            pieces[2].Item2.Text = count;
                            break;
                        case "LN":
                            pieces[3].Item2.Text = count;
                            break;
                        case "KN":
                            pieces[4].Item2.Text = count;
                            break;
                        case "SG":
                            pieces[5].Item2.Text = count;
                            break;
                        case "GG":
                            pieces[6].Item2.Text = count;
                            break;
                    }
                }
            }
        }

        public void addCellsToForm(Form form)
        {
            for (int i = 0; i < Pieces.Count; i++)
            {
                form.Controls.Add(Pieces[i].Item1 as Cell);
            }
        }

        public void addTextBoxToForm(Form form)
        {
            for (int i = 0; i < Pieces.Count; i++)
            {
                form.Controls.Add(Pieces[i].Item2 as TextBox);
            }
        }

        public void addToForm(Form form)
        {
            addCellsToForm(form);
            addTextBoxToForm(form);
        }

        public void display(gameForm form, int xPoz, int yPoz)
        {
            int dist = 10;
            for (int i = 0; i < Pieces.Count; i++)
            {
                Pieces[i].Item1.Size = new Size(60, 60);
                Pieces[i].Item1.Location = new Point(i * 60 + xPoz + dist, yPoz);
                Pieces[i].Item1.BackColor = Color.Crimson;
                Pieces[i].Item1.Click += new EventHandler(form.clickOnCaptured);

                Pieces[i].Item2.Size = new Size(60, 50);
                Pieces[i].Item2.Location = new Point(i * 60 + xPoz + dist, yPoz + 60);
                Pieces[i].Item2.BackColor = Color.FromArgb(255, 230, 173, 142);
                Pieces[i].Item2.Font = new Font(Pieces[i].Item2.Font.FontFamily, 12);
                Pieces[i].Item2.Enabled = false;
                Pieces[i].Item2.TextAlign = HorizontalAlignment.Center;

                dist += 10;
            }
        }

        public void addToCapturedPices(Piece piece)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].Item1.getPiece().GetType() == piece.demotePiece().GetType())
                {
                    pieces[i].Item2.Text = (Int32.Parse(pieces[i].Item2.Text) + 1).ToString();
                }
            }
        }

        public bool isThePieceCaptured(Piece piece)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].Item1.getPiece() == piece)
                {
                    if (Int32.Parse(pieces[i].Item2.Text) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
