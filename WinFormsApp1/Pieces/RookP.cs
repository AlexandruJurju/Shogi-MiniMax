using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class RookP : Piece
    {
        public RookP(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();

            //verificare mutari valide sus
            for (int i = coord.Item2 - 1; i >= 0; i--)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, coord.Item1)))
                {
                    possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                }
                else
                {
                    if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, coord.Item1))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                    }
                    break;
                }
            }
            //verificare mutari valide jos
            for (int i = coord.Item2 + 1; i < 9; i++)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, coord.Item1)))
                {
                    possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                }
                else
                {
                    if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, coord.Item1))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                    }
                    break;
                }
            }
            //verificare mutari valide stanga
            for (int j = coord.Item1 - 1; j >= 0; j--)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2, j)))
                {
                    possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                }
                else
                {
                    if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2, j))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                    }
                    break;
                }
            }
            //verificare mutari valide dreapta
            for (int j = coord.Item1 + 1; j < 9; j++)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2, j)))
                {
                    possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                }
                else
                {
                    if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2, j))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                    }
                    break;
                }
            }

            //1-block-away bishop moves
            if (coord.Item2 - 1 >= 0 && coord.Item1 - 1 >= 0)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 1, coord.Item1 - 1));
            }
            if (coord.Item2 + 1 <= 8 && coord.Item1 - 1 >= 0)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 1, coord.Item1 - 1));
            }
            if (coord.Item2 - 1 >= 0 && coord.Item1 + 1 <= 8)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 1, coord.Item1 + 1));
            }
            if (coord.Item2 + 1 <= 8 && coord.Item1 + 1 <= 8)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 1, coord.Item1 + 1));
            }
            return possbileMoves;
        }

        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();

            //verificare mutari valide sus
            for (int i = coord.Item2 - 1; i >= 0; i--)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, coord.Item1)))
                {
                    possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                }
                else
                {
                    if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, coord.Item1))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                    }
                    break;
                }
            }
            //verificare mutari valide jos
            for (int i = coord.Item2 + 1; i < 9; i++)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, coord.Item1)))
                {
                    possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                }
                else
                {
                    if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, coord.Item1))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, coord.Item1));
                    }
                    break;
                }
            }
            //verificare mutari valide stanga
            for (int j = coord.Item1 - 1; j >= 0; j--)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2, j)))
                {
                    possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                }
                else
                {
                    if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2, j))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                    }
                    break;
                }
            }
            //verificare mutari valide dreapta
            for (int j = coord.Item1 + 1; j < 9; j++)
            {
                if (!boardModel.isPieceAtPosition(new Tuple<int, int>(coord.Item2, j)))
                {
                    possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                }
                else
                {
                    if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(coord.Item2, j))))
                    {
                        possbileMoves.Add(new Tuple<int, int>(coord.Item2, j));
                    }
                    break;
                }
            }

            //1-block-away bishop moves
            if (coord.Item2 - 1 >= 0 && coord.Item1 - 1 >= 0)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 1, coord.Item1 - 1));
            }
            if (coord.Item2 + 1 <= 8 && coord.Item1 - 1 >= 0)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 1, coord.Item1 - 1));
            }
            if (coord.Item2 - 1 >= 0 && coord.Item1 + 1 <= 8)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 - 1, coord.Item1 + 1));
            }
            if (coord.Item2 + 1 <= 8 && coord.Item1 + 1 <= 8)
            {
                possbileMoves.Add(new Tuple<int, int>(coord.Item2 + 1, coord.Item1 + 1));
            }
            return possbileMoves;
        }

    }
}