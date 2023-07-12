using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Lance : Piece
    {
        public Lance(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            //Conditie:
            //(y0 == y1) && (i - coord.Item2) < 0
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            if (this.Color == "W")
            {
                for (int i = coord.Item2 - 1; i >= 0; i--)
                {
                    int ok = 1;
                    if ((i - coord.Item2) < 0)
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
                            ok = 0;
                        }
                    }
                    if (ok == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = coord.Item2 + 1; i < 9; i++)
                {
                    int ok = 1;
                    if ((i - coord.Item2) > 0)
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
                            ok = 0;
                        }
                    }
                    if (ok == 0)
                    {
                        break;
                    }
                }
            }
            return possbileMoves;
        }

        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {
            //Conditie:
            //(y0 == y1) && (i - coord.Item2) < 0
            List<Tuple<int, int>> possbileMoves = new List<Tuple<int, int>>();
            if (Color == "W")
            {
                for (int i = coord.Item2 - 1; i >= 0; i--)
                {
                    int ok = 1;
                    if ((i - coord.Item2) < 0)
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
                            ok = 0;
                        }
                    }
                    if (ok == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = coord.Item2 + 1; i < 9; i++)
                {
                    int ok = 1;
                    if ((i - coord.Item2) > 0)
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
                            ok = 0;
                        }
                    }
                    if (ok == 0)
                    {
                        break;
                    }
                }
            }
            return possbileMoves;
        }

    }
}
