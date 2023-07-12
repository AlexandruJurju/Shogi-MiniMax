using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Knight : Piece
    {
        public Knight(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            //Conditie: 
            //Math.Abs((i - coord.Item2) - (j - coord.Item1)) == 3 || Math.Abs((i - coord.Item2) - (j - coord.Item1)) == 1)
            //&&
            //(i - coord.Item2) == -2 && Math.Abs(j - coord.Item1) == 1)
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            if (this.Color == "W")
            {
                if (coord.Item2 >= 2)
                {
                    if (coord.Item1 + 1 <= 8)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1)))
                        //if (cells[coord.Item2 - 2, coord.Item1 + 1].getPiece() != null)
                        {
                            if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1));
                        }
                    }
                    if (coord.Item1 - 1 >= 0)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1)))
                        //if (cells[coord.Item2 - 2, coord.Item1 - 1].getPiece() != null)
                        {
                            if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1));
                        }
                    }
                }
            }
            else
            {
                if (coord.Item2 <= 6)
                {
                    if (coord.Item1 + 1 <= 8)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1)))
                        //if (cells[coord.Item2 + 2, coord.Item1 + 1].getPiece() != null)
                        {
                            if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1));
                        }
                    }
                    if (coord.Item1 - 1 >= 0)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1)))
                        //if (cells[coord.Item2 + 2, coord.Item1 - 1].getPiece() != null)
                        {
                            if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1));
                        }
                    }
                }
            }
            return possbileMoves;
        }

        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {
            //Conditie: 
            //Math.Abs((i - coord.Item2) - (j - coord.Item1)) == 3 || Math.Abs((i - coord.Item2) - (j - coord.Item1)) == 1)
            //&&
            //(i - coord.Item2) == -2 && Math.Abs(j - coord.Item1) == 1)
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            if (Color == "W")
            {
                if (coord.Item2 >= 2)
                {
                    if (coord.Item1 + 1 <= 8)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1)))
                        //if (cells[coord.Item2 - 2, coord.Item1 + 1].getPiece() != null)
                        {
                            if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 + 1));
                        }
                    }
                    if (coord.Item1 - 1 >= 0)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1)))
                        //if (cells[coord.Item2 - 2, coord.Item1 - 1].getPiece() != null)
                        {
                            if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 2, coord.Item1 - 1));
                        }
                    }
                }
            }
            else
            {
                if (coord.Item2 <= 6)
                {
                    if (coord.Item1 + 1 <= 8)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1)))
                        //if (cells[coord.Item2 + 2, coord.Item1 + 1].getPiece() != null)
                        {
                            if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 + 1));
                        }
                    }
                    if (coord.Item1 - 1 >= 0)
                    {
                        if (boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1)))
                        //if (cells[coord.Item2 + 2, coord.Item1 - 1].getPiece() != null)
                        {
                            if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1))))
                            {
                                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1));
                            }
                        }
                        else
                        {
                            possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 2, coord.Item1 - 1));
                        }
                    }
                }
            }
            return possbileMoves;
        }

    }
}
