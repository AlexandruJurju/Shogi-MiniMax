using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Board
    {
        private Cell[,] cells = new Cell[9, 9];
        internal Cell[,] Cells { get => cells; set => cells = value; }

        private Model boardModel;

        // gameForm
        public Board(gameForm form)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell(i, j);
                    cell.Size = new Size(60, 60);
                    cell.Location = new Point(i * 60 + 75, j * 60 + 75);
                    cell.Click += new EventHandler(form.clickOnCell);
                    if (i % 2 == j % 2)
                    {
                        cell.BackColor = Color.FromArgb(255, 102, 68, 58);
                    }
                    else
                    {
                        cell.BackColor = Color.FromArgb(255, 245, 230, 191);
                    }
                    cell.color = cell.BackColor;

                    Cells[j, i] = cell;
                }
            }

        }
        public void updateBoardFromModel(Model model)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].removePiece();
                    Cells[i, j].Image = null;

                    if (!model.getPieceAtPosition(new Tuple<int, int>(i, j)).Equals("X"))
                    {
                        String type = model.getPieceTypeAtPosition(new Tuple<int, int>(i, j));
                        String color = model.getPieceColorAtPosition(new Tuple<int, int>(i, j));
                        bool isPromoted = model.isPiecePromoted(new Tuple<int, int>(i, j));

                        Piece pieceToSet = new Pawn("W");
                        if (isPromoted)
                        {
                            switch (type)
                            {
                                case "PW":
                                    pieceToSet = new PawnP(color);
                                    break;
                                case "BS":
                                    pieceToSet = new BishopP(color);
                                    break;
                                case "RK":
                                    pieceToSet = new RookP(color);
                                    break;
                                case "LN":
                                    pieceToSet = new LanceP(color);
                                    break;
                                case "KN":
                                    pieceToSet = new KnightP(color);
                                    break;
                                case "SG":
                                    pieceToSet = new SilverP(color);
                                    break;
                            }
                        }
                        else
                        {
                            switch (type)
                            {
                                case "PW":
                                    pieceToSet = new Pawn(color);
                                    break;
                                case "BS":
                                    pieceToSet = new Bishop(color);
                                    break;
                                case "RK":
                                    pieceToSet = new Rook(color);
                                    break;
                                case "LN":
                                    pieceToSet = new Lance(color);
                                    break;
                                case "KN":
                                    pieceToSet = new Knight(color);
                                    break;
                                case "SG":
                                    pieceToSet = new Silver(color);
                                    break;
                                case "GG":
                                    pieceToSet = new Gold(color);
                                    break;
                                case "KG":
                                    pieceToSet = new King(color);
                                    break;
                            }
                        }


                        Cells[i, j].setPiece(pieceToSet);
                        if (pieceToSet.Color.Equals("B"))
                        {
                            Cells[i, j].Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        }
                    }
                }
            }
        }

        public void startPieces()
        {
            boardModel = new Model();
            System.Diagnostics.Debug.WriteLine(boardModel.getBoardMatrix().Length);
            for (int i = 0; i < boardModel.getBoardMatrix().GetLength(0); i++)
            {
                for (int j = 0; j < boardModel.getBoardMatrix().GetLength(1); j++)
                {
                    //if there is a piece at that location, check its color
                    if (!boardModel.getBoardMatrix()[i, j].Equals("X"))
                    {
                        char pieceColor = boardModel.getBoardMatrix()[i, j].ElementAt(0);
                        string pieceType = boardModel.getBoardMatrix()[i, j].Substring(1, 2);
                        switch (pieceType)
                        {
                            case "PW":
                                {
                                    Cells[i, j].setPiece(new Pawn(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "LN":
                                {
                                    Cells[i, j].setPiece(new Lance(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "KN":
                                {
                                    Cells[i, j].setPiece(new Knight(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "SG":
                                {
                                    Cells[i, j].setPiece(new Silver(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "GG":
                                {
                                    Cells[i, j].setPiece(new Gold(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "KG":
                                {
                                    Cells[i, j].setPiece(new King(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "RK":
                                {
                                    Cells[i, j].setPiece(new Rook(Char.ToString(pieceColor)));
                                    break;
                                }
                            case "BS":
                                {
                                    Cells[i, j].setPiece(new Bishop(Char.ToString(pieceColor)));
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        if (pieceColor == 'B')
                        {
                            Cells[i, j].Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        }
                    }
                }
            }
        }

        public void addCellsToForm(Form form)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    form.Controls.Add(Cells[i, j]);
                }
            }
        }

        public void resetCellBackColor(Tuple<int, int> cellCoord)
        {
            if (cellCoord.Item1 % 2 == cellCoord.Item2 % 2)
            {
                Cells[cellCoord.Item1, cellCoord.Item2].BackColor = Color.FromArgb(255, 102, 68, 58);
            }
            else
            {
                Cells[cellCoord.Item1, cellCoord.Item2].BackColor = Color.FromArgb(255, 245, 230, 191);
            }
        }

        public void resetCellsBackColor(List<Tuple<int, int>> PossibleMovesCoord)
        {
            foreach (var cellCoord in PossibleMovesCoord)
            {
                resetCellBackColor(cellCoord);
            }
        }

        public void colorAvailableMoves(List<Tuple<int, int>> possibleMovesCoord)
        {
            foreach (var coord in possibleMovesCoord)
            {
                if (Cells[coord.Item1, coord.Item2].getPiece() != null)
                {
                    Cells[coord.Item1, coord.Item2].BackColor = Color.FromArgb(200, 200, 0, 0);
                }
                else
                {
                    Cells[coord.Item1, coord.Item2].BackColor = Color.FromArgb(200, 0, 200, 0);
                }
            }
        }

        public void colorAvailableInverse(List<Tuple<int, int>> possibleMovesCoord)
        {
            foreach (var coord in possibleMovesCoord)
            {
                if (Cells[coord.Item1, coord.Item2].getPiece() != null)
                {
                    Cells[coord.Item1, coord.Item2].BackColor = Color.FromArgb(200, 200, 0, 0);
                }
                else
                {
                    Cells[coord.Item1, coord.Item2].BackColor = Color.FromArgb(200, 0, 200, 0);
                }
            }
        }

        public void colorReachableCells(List<Tuple<int, int>> ReachableCellsCoord)
        {
            foreach (var coord in ReachableCellsCoord)
            {
                Cells[coord.Item1, coord.Item2].BackColor = Color.PaleGreen;
            }
        }

        public Cell getCellFromCoord(Tuple<int, int> coord)
        {
            return cells[coord.Item2, coord.Item1];
        }

    }
}