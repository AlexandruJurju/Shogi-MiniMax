using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsApp1
{
    internal class Pawn : Piece
    {

        public Pawn(String color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }

        public override List<Tuple<int, int>> getPosibileMoves2(Tuple<int, int> coord, Model boardModel)
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            Tuple<int, int> newCoord;
            if (this.Color == "W")
            {
                if (coord.Item2 - 1 >= 0)
                {
                    newCoord = new Tuple<int, int>(coord.Item2 - 1, coord.Item1);
                    if (!boardModel.isPieceAtPosition(newCoord))
                    {

                        possibleMoves.Add(newCoord);
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(newCoord)))
                        {
                            possibleMoves.Add(newCoord);
                        }
                    }
                }
            }
            else
            {
                if (coord.Item2 + 1 <= 8)
                {
                    newCoord = new Tuple<int, int>(coord.Item2 + 1, coord.Item1);
                    if (!boardModel.isPieceAtPosition(newCoord))
                    {
                        possibleMoves.Add(newCoord);
                    }
                    else
                    {
                        if (!this.Color.Equals(boardModel.getPieceColorAtPosition(newCoord)))
                        {
                            possibleMoves.Add(newCoord);
                        }
                    }
                }
            }
            return possibleMoves;
        }

        public static List<Tuple<int, int>> getPossibleMovesStatic(Tuple<int, int> coord, Model boardModel, String Color)
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            Tuple<int, int> newCoord;
            if (Color == "W")
            {
                if (coord.Item2 - 1 >= 0)
                {
                    newCoord = new Tuple<int, int>(coord.Item2 - 1, coord.Item1);
                    if (!boardModel.isPieceAtPosition(newCoord))
                    {

                        possibleMoves.Add(newCoord);
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(newCoord)))
                        {
                            possibleMoves.Add(newCoord);
                        }
                    }
                }
            }
            else
            {
                if (coord.Item2 + 1 <= 8)
                {
                    newCoord = new Tuple<int, int>(coord.Item2 + 1, coord.Item1);
                    if (!boardModel.isPieceAtPosition(newCoord))
                    {
                        possibleMoves.Add(newCoord);
                    }
                    else
                    {
                        if (!Color.Equals(boardModel.getPieceColorAtPosition(newCoord)))
                        {
                            possibleMoves.Add(newCoord);
                        }
                    }
                }
            }
            return possibleMoves;
        }

    }
}
