using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Model
    {

        public struct capturedPiece
        {
            public string piece;
            public int count;

            public capturedPiece(string piece, int count)
            {
                this.piece = piece;
                this.count = count;
            }

            public string getPiece()
            {
                return piece;
            }
            public int getCount()
            {
                return count;
            }
        }

        private string[,] boardMatrix { get; set; }

        private capturedPiece[] whiteCaptured = new capturedPiece[7];
        private capturedPiece[] blackCaptured = new capturedPiece[7];

        public capturedPiece[] getWhiteCaptured()
        {
            return whiteCaptured;
        }

        public capturedPiece[] getBlackCaptured()
        {
            return blackCaptured;
        }

        public Model()
        {
            this.boardMatrix =
                new string[,]{
                    { "BLN", "BKN", "BSG", "BGG", "BKG", "BGG", "BSG", "BKN", "BLN" },
                    { "X", "BRK", "X", "X", "X", "X", "X", "BBS", "X" },
                    { "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW" },
                    { "X", "WBS", "X", "X", "X", "X", "X", "WRK", "X" },
                    { "WLN", "WKN", "WSG", "WGG", "WKG", "WGG", "WSG", "WKN", "WLN" }
                };

            this.whiteCaptured[0] = (new capturedPiece("WPW", 0));
            this.whiteCaptured[1] = (new capturedPiece("WBS", 0));
            this.whiteCaptured[2] = (new capturedPiece("WRK", 0));
            this.whiteCaptured[3] = (new capturedPiece("WLN", 0));
            this.whiteCaptured[4] = (new capturedPiece("WKN", 0));
            this.whiteCaptured[5] = (new capturedPiece("WSG", 0));
            this.whiteCaptured[6] = (new capturedPiece("WGG", 0));

            this.blackCaptured[0] = (new capturedPiece("BPW", 0));
            this.blackCaptured[1] = (new capturedPiece("BBS", 0));
            this.blackCaptured[2] = (new capturedPiece("BRK", 0));
            this.blackCaptured[3] = (new capturedPiece("BLN", 0));
            this.blackCaptured[4] = (new capturedPiece("BKN", 0));
            this.blackCaptured[5] = (new capturedPiece("BSG", 0));
            this.blackCaptured[6] = (new capturedPiece("BGG", 0));
        }

        public List<Tuple<int, int>> getCapturedPiecesForPlayer(string color)
        {
            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            if (color.Equals("W"))
            {
                for (int i = 0; i < whiteCaptured.Length; i++)
                {
                    if (whiteCaptured[i].count > 0)
                    {
                        output.Add(new Tuple<int, int>(-1, i));
                    }
                }
            }
            else
            {
                for (int i = 0; i < whiteCaptured.Length; i++)
                {
                    if (blackCaptured[i].count > 0)
                    {
                        output.Add(new Tuple<int, int>(-2, i));
                    }
                }
            }
            return output;
        }

        public List<Tuple<int, int>> getPossibleMovesForCaptured(Tuple<int, int> coords)
        {

            List<Tuple<int, int>> capturedPossibleMoves = new List<Tuple<int, int>>();


            string pieceType;
            string playerColor;
            if (coords.Item1 == -1)
            {
                pieceType = whiteCaptured[coords.Item2].getPiece().Substring(1, 2);
                playerColor = "W";
                int count = whiteCaptured[coords.Item2].getCount();

                if (count == 0)
                {
                    return capturedPossibleMoves;
                }
            }
            else
            {
                pieceType = blackCaptured[coords.Item2].getPiece().Substring(1, 2);
                playerColor = "B";
                int count = blackCaptured[coords.Item2].getCount();

                if (count == 0)
                {
                    return capturedPossibleMoves;
                }

            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (getPieceAtPosition(new Tuple<int, int>(i, j)).Equals("X"))
                    {
                        capturedPossibleMoves.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            if (pieceType.Equals("KN"))
            {
                if (playerColor.Equals("W"))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            capturedPossibleMoves.Remove(new Tuple<int, int>(i, j));
                        }
                    }
                }
                else
                {
                    for (int i = 7; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            capturedPossibleMoves.Remove(new Tuple<int, int>(i, j));
                        }
                    }
                }
            }

            if (pieceType.Equals("PW"))
            {
                for (int j = 0; j < 9; j++)
                {
                    bool isFriendlyPawnOnColumn = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (!getPieceAtPosition(new Tuple<int, int>(i, j)).Equals("X"))
                        {
                            if (getPieceTypeAtPosition(new Tuple<int, int>(i, j)).Equals("PW") && getPieceColorAtPosition(new Tuple<int, int>(i, j)).Equals(playerColor))
                            {
                                isFriendlyPawnOnColumn = true;
                            }
                        }
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        if (isFriendlyPawnOnColumn)
                        {
                            capturedPossibleMoves.Remove(new Tuple<int, int>(i, j));
                        }
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (!getPieceAtPosition(new Tuple<int, int>(i, j)).Equals("X"))
                        {
                            if (getPieceTypeAtPosition(new Tuple<int, int>(i, j)).Equals("KG") && !getPieceColorAtPosition(new Tuple<int, int>(i, j)).Equals(playerColor))
                            {
                                if (playerColor.Equals("W"))
                                {
                                    capturedPossibleMoves.Remove(new Tuple<int, int>(i + 1, j));
                                }
                                else
                                {
                                    capturedPossibleMoves.Remove(new Tuple<int, int>(i - 1, j));
                                }
                            }
                        }
                    }
                }
            }


            return capturedPossibleMoves;
        }

        public Model(string[,] boardMatrix)
        {
            this.boardMatrix = boardMatrix;
        }

        public string[,] getBoardMatrix()
        {
            return boardMatrix;
        }

        public List<Tuple<int, int>> getPossibleMovesForPiece(Tuple<int, int> coord)
        {
            String type = getPieceTypeAtPosition(coord);
            String color = getPieceColorAtPosition(coord);
            bool isPromoted = isPiecePromoted(coord);

            Tuple<int, int> inverseCoord = new Tuple<int, int>(coord.Item2, coord.Item1);

            if (isPromoted)
            {
                switch (type)
                {
                    case "PW":
                        return Gold.getPossibleMovesStatic(inverseCoord, this, color);
                    case "BS":
                        return BishopP.getPossibleMovesStatic(inverseCoord, this, color);
                    case "RK":
                        return RookP.getPossibleMovesStatic(inverseCoord, this, color);
                    case "LN":
                        return Gold.getPossibleMovesStatic(inverseCoord, this, color);
                    case "KN":
                        return Gold.getPossibleMovesStatic(inverseCoord, this, color);
                    case "SG":
                        return Gold.getPossibleMovesStatic(inverseCoord, this, color);
                }
            }
            else
            {
                switch (type)
                {
                    case "PW":
                        return Pawn.getPossibleMovesStatic(inverseCoord, this, color);
                    case "BS":
                        return Bishop.getPossibleMovesStatic(inverseCoord, this, color);
                    case "RK":
                        return Rook.getPossibleMovesStatic(inverseCoord, this, color);
                    case "LN":
                        return Lance.getPossibleMovesStatic(inverseCoord, this, color);
                    case "KN":
                        return Knight.getPossibleMovesStatic(inverseCoord, this, color);
                    case "SG":
                        return Silver.getPossibleMovesStatic(inverseCoord, this, color);
                    case "GG":
                        return Gold.getPossibleMovesStatic(inverseCoord, this, color);
                    case "KG":
                        return King.getPossibleMovesStatic(inverseCoord, this, color);
                }
            }

            return null;

        }

        public void makeRandomMove(string player)
        {
            List<Tuple<int, int>> possiblePieces = getPossiblePiecesForPlayer("B");

            List<pieceWithMove> randomPieceWithMove = new List<pieceWithMove>();

            for (int i = 0; i < possiblePieces.Count; i++)
            {
                foreach (var move in getPossibleMovesForPiece(possiblePieces[i]))
                {
                    randomPieceWithMove.Add(new pieceWithMove(possiblePieces[i], move));
                }
            }


            Random rngGenerator = new Random();
            int randomIndex = rngGenerator.Next(0, randomPieceWithMove.Count);

            movePiece(randomPieceWithMove[randomIndex].Piece, randomPieceWithMove[randomIndex].Move);
        }

        public List<Tuple<int, int>> getPossiblePiecesForPlayer(String color)
        {
            List<Tuple<int, int>> posiblePieces = new List<Tuple<int, int>>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Tuple<int, int> coords = new Tuple<int, int>(i, j);
                    if (!getPieceAtPosition(coords).Equals("X"))
                    {
                        if (getPieceColorAtPosition(coords).Equals(color))
                        {
                            if (getPossibleMovesForPiece(coords).Count > 0)
                            {
                                posiblePieces.Add(coords);
                            }
                        }
                    }
                }
            }

            return posiblePieces;
        }

        public Model deepCopyBoard(Model modelToCopy)
        {
            Model modelCopy = new Model();

            for (int i = 0; i < boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < boardMatrix.GetLength(1); j++)
                {
                    modelCopy.getBoardMatrix()[i, j] = modelToCopy.getBoardMatrix()[i, j];
                }
            }

            return modelCopy;
        }

        public void printModel()
        {
            for (int i = 0; i < boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < boardMatrix.GetLength(1); j++)
                {
                    if (boardMatrix[i, j].Equals("X"))
                    {
                        System.Diagnostics.Debug.Write(" X  ");
                    }
                    else
                    {
                        System.Diagnostics.Debug.Write(boardMatrix[i, j] + " ");
                    }
                }
                System.Diagnostics.Debug.Write("\n");
            }
            System.Diagnostics.Debug.Write("\n");
        }

        public void setBoardMatrix(string[,] boardMatrix)
        {
            this.boardMatrix = boardMatrix;
        }

        public bool isPieceAtPosition(Tuple<int, int> position)
        {
            if (getPieceColorAtPosition(position).Equals("X"))
            {
                return false;
            }
            return true;
        }

        public string getPieceAtPosition(Tuple<int, int> position)
        {
            return boardMatrix[position.Item1, position.Item2];
        }

        public string getPieceColorAtPosition(Tuple<int, int> position)
        {
            return Char.ToString(boardMatrix[position.Item1, position.Item2].ElementAt(0));
        }

        public string getPieceTypeAtPosition(Tuple<int, int> position)
        {
            return boardMatrix[position.Item1, position.Item2].Substring(1, 2);
        }

        public void updateModelFromAnotherModel(Model another)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardMatrix[i, j] = "X";
                    boardMatrix[i, j] = another.boardMatrix[i, j];

                }
            }
        }

        public void movePiece(Tuple<int, int> oldPosition, Tuple<int, int> newPosition)
        {
            if (oldPosition.Item1 >= 0)
            {


                Tuple<int, int> capturedPieceCoords = newPosition;
                string capturedPiece = boardMatrix[newPosition.Item1, newPosition.Item2];

                boardMatrix[newPosition.Item1, newPosition.Item2] = boardMatrix[oldPosition.Item1, oldPosition.Item2];
                boardMatrix[oldPosition.Item1, oldPosition.Item2] = "X";


                if (!capturedPiece.Equals("X"))
                {
                    string capturedColor = capturedPiece.Substring(0, 1);
                    string capturedType = capturedPiece.Substring(1, 2);

                    if (capturedColor.Equals("W"))
                    {
                        switch (capturedType)
                        {
                            case "PW":
                                blackCaptured[0].count++;
                                break;
                            case "BS":
                                blackCaptured[1].count++;
                                break;
                            case "RK":
                                blackCaptured[2].count++;
                                break;
                            case "LN":
                                blackCaptured[3].count++;
                                break;
                            case "KN":
                                blackCaptured[4].count++;
                                break;
                            case "SG":
                                blackCaptured[5].count++;
                                break;
                            case "GG":
                                blackCaptured[6].count++;
                                break;
                        }
                    }
                    else
                    {
                        switch (capturedType)
                        {
                            case "PW":
                                whiteCaptured[0].count++;
                                break;
                            case "BS":
                                whiteCaptured[1].count++;
                                break;
                            case "RK":
                                whiteCaptured[2].count++;
                                break;
                            case "LN":
                                whiteCaptured[3].count++;
                                break;
                            case "KN":
                                whiteCaptured[4].count++;
                                break;
                            case "SG":
                                whiteCaptured[5].count++;
                                break;
                            case "GG":
                                whiteCaptured[6].count++;
                                break;
                        }
                    }
                }

            }
            else
            {
                if (oldPosition.Item1 == -1)
                {
                    boardMatrix[newPosition.Item1, newPosition.Item2] = whiteCaptured[oldPosition.Item2].getPiece();
                    whiteCaptured[oldPosition.Item2].count = whiteCaptured[oldPosition.Item2].count - 1;
                }
                else
                {
                    boardMatrix[newPosition.Item1, newPosition.Item2] = blackCaptured[oldPosition.Item2].getPiece();
                    blackCaptured[oldPosition.Item2].count = whiteCaptured[oldPosition.Item2].count - 1;
                }
            }
        }

        public int evaluateBoard()
        {
            int score = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Tuple<int, int> coords = new Tuple<int, int>(i, j);

                    if (!getPieceAtPosition(coords).Equals("X"))
                    {
                        int scoreToAdd = 0;
                        if (isPiecePromoted(coords))
                        {
                            switch (getPieceTypeAtPosition(coords))
                            {
                                case "PW":
                                    scoreToAdd = 10;
                                    break;
                                case "LN":
                                    scoreToAdd = 10;
                                    break;
                                case "KN":
                                    scoreToAdd = 10;
                                    break;
                                case "SG":
                                    scoreToAdd = 10;
                                    break;
                                case "BS":
                                    scoreToAdd = 15;
                                    break;
                                case "RK":
                                    scoreToAdd = 17;
                                    break;
                            }
                        }
                        else
                        {
                            switch (getPieceTypeAtPosition(coords))
                            {
                                case "PW":
                                    scoreToAdd = 1;
                                    break;
                                case "LN":
                                    scoreToAdd = 5;
                                    break;
                                case "KN":
                                    scoreToAdd = 6;
                                    break;
                                case "SG":
                                    scoreToAdd = 8;
                                    break;
                                case "BS":
                                    scoreToAdd = 13;
                                    break;
                                case "RK":
                                    scoreToAdd = 15;
                                    break;
                                case "GG":
                                    scoreToAdd = 9;
                                    break;
                                case "KG":
                                    scoreToAdd = 10000;
                                    break;
                            }
                        }
                        if (getPieceColorAtPosition(coords).Equals("B"))
                        {
                            score = score - scoreToAdd;
                        }
                        else
                        {
                            score = score + scoreToAdd;
                        }
                    }
                }
            }
            return score;
        }
        public bool isPiecePromoted(Tuple<int, int> position)
        {
            if (boardMatrix[position.Item1, position.Item2].Length == 3)
            {
                return false;
            }
            return true;
        }

        public bool canPieceBePromoted(Tuple<int, int> position)
        {
            if (isPiecePromoted(position))
            {
                return false;
            }

            string color = getPieceColorAtPosition(position);

            if (color.Equals("W"))
            {
                if (position.Item1 >= 0 && position.Item1 <= 2)
                {
                    return true;
                }
            }
            else
            {
                if (position.Item1 >= 6 && position.Item1 <= 8)
                {
                    return true;
                }
            }
            return false;
        }

        public void movePieceAndPromoteIfPossible(Tuple<int, int> oldPosition, Tuple<int, int> newPosition)
        {
            movePiece(oldPosition, newPosition);
            if (canPieceBePromoted(newPosition))
            {
                promotePiece(newPosition);
            }
        }

        public void promotePiece(Tuple<int, int> position)
        {
            boardMatrix[position.Item1, position.Item2] = boardMatrix[position.Item1, position.Item2] + "P";
        }

        public void resetModel()
        {
            this.boardMatrix =
                new string[,]{
                    { "BLN", "BKN", "BSG", "BGG", "BKG", "BGG", "BSG", "BKN", "BLN" },
                    { "X", "BRK", "X", "X", "X", "X", "X", "BBS", "X" },
                    { "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW", "BPW" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "X", "X", "X", "X", "X", "X", "X", "X", "X" },
                    { "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW", "WPW" },
                    { "X", "WBS", "X", "X", "X", "X", "X", "WRK", "X" },
                    { "WLN", "WKN", "WSG", "WGG", "WKG", "WGG", "WSG", "WKN", "WLN" }
                };


            this.whiteCaptured[0] = (new capturedPiece("WPW", 0));
            this.whiteCaptured[1] = (new capturedPiece("WBS", 0));
            this.whiteCaptured[2] = (new capturedPiece("WRK", 0));
            this.whiteCaptured[3] = (new capturedPiece("WLN", 0));
            this.whiteCaptured[4] = (new capturedPiece("WKN", 0));
            this.whiteCaptured[5] = (new capturedPiece("WSG", 0));
            this.whiteCaptured[6] = (new capturedPiece("WGG", 0));

            this.blackCaptured[0] = (new capturedPiece("BPW", 0));
            this.blackCaptured[1] = (new capturedPiece("BBS", 0));
            this.blackCaptured[2] = (new capturedPiece("BRK", 0));
            this.blackCaptured[3] = (new capturedPiece("BLN", 0));
            this.blackCaptured[4] = (new capturedPiece("BKN", 0));
            this.blackCaptured[5] = (new capturedPiece("BSG", 0));
            this.blackCaptured[6] = (new capturedPiece("BGG", 0));


        }

        struct pieceWithMove
        {
            Tuple<int, int> piece;
            Tuple<int, int> move;

            public Tuple<int, int> Piece { get => piece; set => piece = value; }
            public Tuple<int, int> Move { get => move; set => move = value; }

            public pieceWithMove(Tuple<int, int> piece, Tuple<int, int> move) : this()
            {
                Piece = piece;
                Move = move;
            }
        }


        List<Tuple<pieceWithMove, double>> bestPossible = new List<Tuple<pieceWithMove, double>>();

        int maxDepth;

        public Tuple<Model, double> minValue(Model modelMini, int depth)
        {
            if (depth == 0)
            {
                return new Tuple<Model, double>(modelMini, modelMini.evaluateBoard());
            }

            Tuple<Model, double> min = new Tuple<Model, double>(modelMini, double.MaxValue);

            List<Tuple<int, int>> possiblePieces = modelMini.getPossiblePiecesForPlayer("B");

            Random rng = new Random();

            possiblePieces = possiblePieces.OrderBy(a => rng.Next()).ToList();

            Tuple<Model, double> score;

            for (int i = 0; i < possiblePieces.Count; i++)
            {
                foreach (var move in modelMini.getPossibleMovesForPiece(possiblePieces[i]))
                {

                    System.Diagnostics.Debug.WriteLine("min" + " " + possiblePieces[i].Item1 + " " + possiblePieces[i].Item2 + " " + move.Item1 + " " + move.Item2);

                    Model modelMiniAfterMove = modelMini.deepCopyBoard(modelMini);
                    modelMiniAfterMove.movePiece(possiblePieces[i], move);

                    score = maxValue(modelMiniAfterMove, depth - 1);

                    if (score.Item2 < min.Item2)
                    {
                        min = score;
                        if (depth == maxDepth)
                        {
                            bestPossible.Add(new Tuple<pieceWithMove, double>(new pieceWithMove(possiblePieces[i], move), min.Item2));
                        }
                    }
                }
            }

            return min;
        }

        public Tuple<Model, double> maxValue(Model modelMaxi, int depth)
        {
            if (depth == 0)
            {
                return new Tuple<Model, double>(modelMaxi, modelMaxi.evaluateBoard());
            }

            Tuple<Model, double> max = new Tuple<Model, double>(modelMaxi, double.MinValue);

            List<Tuple<int, int>> possiblePieces = modelMaxi.getPossiblePiecesForPlayer("W");

            Tuple<Model, double> score;

            for (int i = 0; i < possiblePieces.Count; i++)
            {
                foreach (var move in modelMaxi.getPossibleMovesForPiece(possiblePieces[i]))
                {
                    System.Diagnostics.Debug.WriteLine("max" + " " + possiblePieces[i].Item1 + " " + possiblePieces[i].Item2 + " " + move.Item1 + " " + move.Item2);

                    Model modelMaxiAftetMove = modelMaxi.deepCopyBoard(modelMaxi);
                    modelMaxiAftetMove.movePiece(possiblePieces[i], move);

                    score = minValue(modelMaxiAftetMove, depth - 1);

                    if (score.Item2 > max.Item2)
                    {
                        max = score;
                    }
                }
            }

            return max;
        }

        public List<Tuple<int, int>> doMinimax(int depth)
        {
            bestPossible = new List<Tuple<pieceWithMove, double>>();

            maxDepth = depth;

            Model result = minValue(this, maxDepth).Item1;

            double min = double.MaxValue;
            for (int i = 0; i < bestPossible.Count(); i++)
            {
                if (bestPossible[i].Item2 < min)
                {
                    min = bestPossible[i].Item2;
                }
            }

            Tuple<int, int> bestPiece = new Tuple<int, int>(0, 0);
            Tuple<int, int> bestMove = new Tuple<int, int>(0, 0);

            for (int i = 0; i < bestPossible.Count(); i++)
            {
                if (bestPossible[i].Item2 == min)
                {
                    bestPiece = bestPossible[i].Item1.Piece;
                    bestMove = bestPossible[i].Item1.Move;
                }
            }

            System.Diagnostics.Debug.WriteLine(bestPiece.Item1 + " " + bestPiece.Item2 + " " + bestMove.Item1 + " " + bestMove.Item2);

            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            output.Add(bestPiece);
            output.Add(bestMove);

            return output;
        }
    }
}
