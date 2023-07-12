using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Silver : Piece
    {
        public Silver(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            //Conditie:
            // Math.abs(x1 - x0) == 1) && (Math.abs(y1 - y0) == 1) 
            // ||
            // Math.abs((x1 - x0) - (y1 - y0)) == 1 && (x1 - x0) == -1   --- diagonale jos
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            int iMin = coord.Item2;
            if (iMin < 8)
            {
                iMin++;
            }
            int iMax = coord.Item2;
            if (iMax > 0)
            {
                iMax--;
            }
            int jMin = coord.Item1;
            if (jMin < 8)
            {
                jMin++;
            }
            int jMax = coord.Item1;
            if (jMax > 0)
            {
                jMax--;
            }
            if (this.Color == "W")
            {
                for (int i = iMax; i <= iMin; i++)
                {
                    for (int j = jMax; j <= jMin; j++)
                    {
                        bool valid = true;
                        if (i == coord.Item2 && j == coord.Item1)
                        {
                            valid = false;
                        }
                        if ((i == coord.Item2 && j == jMin) || (i == coord.Item2 && j == jMax) || (i == iMin && j == coord.Item1))
                        {
                            valid = false;
                        }
                        if (valid == true)
                        {
                            if (boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                            {
                                if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                                {
                                    possbileMoves.Add(new Tuple<int, int>(i, j));
                                }
                            }
                            else
                            {
                                possbileMoves.Add(new Tuple<int, int>(i, j));
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = iMax; i <= iMin; i++)
                {
                    for (int j = jMax; j <= jMin; j++)
                    {
                        bool valid = true;
                        if (i == coord.Item2 && j == coord.Item1)
                        {
                            valid = false;
                        }
                        if ((i == coord.Item2 && j == jMin) || (i == coord.Item2 && j == jMax) || (i == iMax && j == coord.Item1))
                        {
                            valid = false;
                        }
                        if (valid == true)
                        {
                            if (boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                            {
                                if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                                {
                                    possbileMoves.Add(new Tuple<int, int>(i, j));
                                }
                            }
                            else
                            {
                                possbileMoves.Add(new Tuple<int, int>(i, j));
                            }
                        }
                    }
                }
            }
            return possbileMoves;
        }

        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {
            //Conditie:
            // Math.abs(x1 - x0) == 1) && (Math.abs(y1 - y0) == 1) 
            // ||
            // Math.abs((x1 - x0) - (y1 - y0)) == 1 && (x1 - x0) == -1   --- diagonale jos
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            int iMin = coord.Item2;
            if (iMin < 8)
            {
                iMin++;
            }
            int iMax = coord.Item2;
            if (iMax > 0)
            {
                iMax--;
            }
            int jMin = coord.Item1;
            if (jMin < 8)
            {
                jMin++;
            }
            int jMax = coord.Item1;
            if (jMax > 0)
            {
                jMax--;
            }
            if (Color == "W")
            {
                for (int i = iMax; i <= iMin; i++)
                {
                    for (int j = jMax; j <= jMin; j++)
                    {
                        bool valid = true;
                        if (i == coord.Item2 && j == coord.Item1)
                        {
                            valid = false;
                        }
                        if ((i == coord.Item2 && j == jMin) || (i == coord.Item2 && j == jMax) || (i == iMin && j == coord.Item1))
                        {
                            valid = false;
                        }
                        if (valid == true)
                        {
                            if (boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                            {
                                if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                                {
                                    possbileMoves.Add(new Tuple<int, int>(i, j));
                                }
                            }
                            else
                            {
                                possbileMoves.Add(new Tuple<int, int>(i, j));
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = iMax; i <= iMin; i++)
                {
                    for (int j = jMax; j <= jMin; j++)
                    {
                        bool valid = true;
                        if (i == coord.Item2 && j == coord.Item1)
                        {
                            valid = false;
                        }
                        if ((i == coord.Item2 && j == jMin) || (i == coord.Item2 && j == jMax) || (i == iMax && j == coord.Item1))
                        {
                            valid = false;
                        }
                        if (valid == true)
                        {
                            if (boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                            {
                                if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                                {
                                    possbileMoves.Add(new Tuple<int, int>(i, j));
                                }
                            }
                            else
                            {
                                possbileMoves.Add(new Tuple<int, int>(i, j));
                            }
                        }
                    }
                }
            }
            return possbileMoves;
        }

    }
}
