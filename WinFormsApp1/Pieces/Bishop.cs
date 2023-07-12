using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Bishop : Piece
    {
        public Bishop(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            //verificare mutari valide diagonala sus-dreapta
            for (int i = coord.Item2 - 1, j = coord.Item1 + 1; i >= 0 && j < 9; i--, j++)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }

            //verificare mutari valide diagonala sus-stanga
            for (int i = coord.Item2 - 1, j = coord.Item1 - 1; i >= 0 && j >= 0; i--, j--)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }

            //verificare mutari valide diagonala jos-dreapta
            for (int i = coord.Item2 + 1, j = coord.Item1 + 1; i < 9 && j < 9; i++, j++)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }
            //verificare mutari valide diagonala jos-stanga
            for (int i = coord.Item2 + 1, j = coord.Item1 - 1; i < 9 && j >= 0; i++, j--)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }
            return possbileMoves;
        }
        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {

            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            //verificare mutari valide diagonala sus-dreapta
            for (int i = coord.Item2 - 1, j = coord.Item1 + 1; i >= 0 && j < 9; i--, j++)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }

            //verificare mutari valide diagonala sus-stanga
            for (int i = coord.Item2 - 1, j = coord.Item1 - 1; i >= 0 && j >= 0; i--, j--)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }

            //verificare mutari valide diagonala jos-dreapta
            for (int i = coord.Item2 + 1, j = coord.Item1 + 1; i < 9 && j < 9; i++, j++)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }
            //verificare mutari valide diagonala jos-stanga
            for (int i = coord.Item2 + 1, j = coord.Item1 - 1; i < 9 && j >= 0; i++, j--)
            {
                int ok = 1;
                if (Math.Abs(i - coord.Item2) == Math.Abs(j - coord.Item1))
                {
                    if (!boardModel.isPieceAtPosition(new Tuple<int, int>(i, j)))
                    {
                        possbileMoves.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(new Tuple<int, int>(i, j))))
                        {
                            possbileMoves.Add(new Tuple<int, int>(i, j));
                        }
                        ok = 0;
                    }
                }
                if (ok == 0)
                {
                    break;
                }
            }
            return possbileMoves;

        }

    }
}
