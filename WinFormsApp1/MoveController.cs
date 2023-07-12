using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class MoveController
    {


        private Display view;
        private PlayerController playerController;
        private Model model;


        //possible (reachable) moves for the chosen piece
        private List<Tuple<int, int>> possibleMovesCoord;
        public List<Tuple<int, int>> PossibleMovesCoord { get => possibleMovesCoord; set => possibleMovesCoord = value; }

        private bool pieceSelected;
        private bool capturedPieceSelected;

        private Cell boardCell;
        private Cell capturedCell;

        private Tuple<int, int> boardCell2;
        private Tuple<int, int> capturedCell2;

        private bool sameColorPiece;

        public Tuple<int, int>[] lastMove = new Tuple<int, int>[2];
        private bool moveWasExecuted;

        public MoveController(Display display, PlayerController playerController, Model model)
        {
            this.view = display;
            this.playerController = playerController;
            this.model = model;
            pieceSelected = true;
        }

        public void move(Cell cell)
        {
            if (pieceSelected)
            {
                int i = cell.getCoord().Item2;
                int j = cell.getCoord().Item1;
                //check if there is a piece at the click position
                if (model.isPieceAtPosition(new Tuple<int, int>(i, j)))
                {
                    bool correctPieceChoice = isSelectedPieceColorSameAsPlayer2(i, j);
                    if (correctPieceChoice)
                    {
                        boardCell2 = new Tuple<int, int>(i, j);

                    }
                }
                if (cell.getPiece() != null)
                {
                    //check if the player chose one of his pieces, and not one of his opponent's
                    bool correctPieceChoice = isSelectedPieceColorSameAsPlayer(cell);
                    //if true, the piece will be selected
                    if (correctPieceChoice)
                    {
                        //set the selected cell
                        boardCell = cell;
                        //get the possible moves for the piece that's in that cell

                        PossibleMovesCoord = cell.getPiece().getPosibileMoves2(cell.getCoord(), model);

                        //PossibleMovesCoord = cell.getPiece().getPosibileMoves(cell.getCoord(), view.getBoard().Cells);
                        //if this piece can be moved (there are possible moves)
                        //then color these possible new locations (cells)
                        if (PossibleMovesCoord.Count != 0)
                        {
                            view.getBoard().colorAvailableMoves(PossibleMovesCoord);
                            //now that a piece was selected, we can go on and choose the new location
                            //to indicate this, we set this variable to false
                            pieceSelected = false;
                        }
                    }
                }
                moveWasExecuted = false;
            }
            else
            {
                //if the piece selected is not from the 'captured panel'
                //it means that this piece is a 'board piece'
                if (!capturedPieceSelected)
                {
                    //check if the player chose another piece
                    //if not, it means he chose a new location for the already selected piece
                    sameColorPiece = clickedOnSameColorPiece(boardCell, cell);
                    //check if the piece can be moved to the new location
                    if (sameColorPiece == false && possibleMovesCoord.Contains(new Tuple<int, int>(cell.getCoord().Item2, cell.getCoord().Item1)))
                    {
                        //execute the move
                        pieceSelected = processTheMove(boardCell, cell, playerController.getCurrentPlayer());

                        //update the 'all possible moves' array
                        //used to determine the 'check' game state
                        //not usefull right now, maybe later
                        //getReachableCellsCoord();

                        moveWasExecuted = true;
                    }
                }
                if (capturedPieceSelected && clickedOnSameColorPiece(capturedCell, cell))
                {
                    capturedPieceSelected = false;
                    capturedCell.BackColor = Color.Crimson;
                }
                if (capturedPieceSelected)
                {
                    moveCapturedPiece(cell);
                }
            }
        }

        private void moveCapturedPiece(Cell cell)
        {
            //check which captured piece was selected
            foreach (var capturedPiece in playerController.getCurrentPlayer().Captured.Pieces)
            {
                if (capturedPiece.Item1.getPiece() == capturedCell.getPiece())
                {
                    //check if there are indeed captured pieces (one or more) of that type
                    if (Int32.Parse(capturedPiece.Item2.Text) > 0)
                    {
                        //check if the captured piece can be placed at the location selected on the board
                        //each captured piece has it's own rule of replacement
                        if (possibleMovesCoord.Contains(new Tuple<int, int>(cell.getCoord().Item2, cell.getCoord().Item1)))
                        {
                            model.movePiece(new Tuple<int, int>(capturedCell.getCoord().Item1, capturedCell.getCoord().Item2), new Tuple<int, int>(cell.getCoord().Item2, cell.getCoord().Item1));
                            view.getBoard().updateBoardFromModel(model);

                            capturedPieceSelected = false;
                            pieceSelected = true;

                            view.getBoard().resetCellsBackColor(PossibleMovesCoord);
                            capturedCell.BackColor = Color.Crimson;

                            playerController.getPlayer1().Captured.updateCapturedFromModel(model, "W");
                            playerController.getPlayer2().Captured.updateCapturedFromModel(model, "B");


                            makeAIMove();
                        }
                    }
                }
            }
        }

        private bool isSelectedPieceColorSameAsPlayer2(int i, int j)
        {
            if ((playerController.getTurnPlayer1() == true && model.getPieceColorAtPosition(new Tuple<int, int>(i, j)) != playerController.getCurrentPlayer().getColor())
                ||
                ((playerController.getTurnPlayer2() == true && model.getPieceColorAtPosition(new Tuple<int, int>(i, j)) != playerController.getCurrentPlayer().getColor())))
            {
                DialogResult dr = MessageBox.Show("That's not your piece!", "Wrong choice", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private bool isSelectedPieceColorSameAsPlayer(Cell cell)
        {
            if ((playerController.getTurnPlayer1() == true && cell.getPiece().Color != playerController.getCurrentPlayer().getColor()) || (playerController.getTurnPlayer2() == true && cell.getPiece().Color != playerController.getCurrentPlayer().getColor()))
            {
                DialogResult dr = MessageBox.Show("That's not your piece!", "Wrong choice", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }


        private void makeAIMove()
        {

            string depthString = view.getDepthComboBox().Text;

            if (depthString.Equals("Random"))
            {
                model.makeRandomMove("B");
                view.getBoard().updateBoardFromModel(model);
            }
            else
            {

                int depth = int.Parse(depthString);
                List<Tuple<int, int>> minimaxResult = model.doMinimax(depth);
                model.movePieceAndPromoteIfPossible(minimaxResult[0], minimaxResult[1]);

                playerController.getPlayer1().Captured.updateCapturedFromModel(model, "W");
                playerController.getPlayer2().Captured.updateCapturedFromModel(model, "B");

                view.getBoard().updateBoardFromModel(model);
            }

        }

        private bool clickedOnSameColorPiece(Cell oldCell, Cell newCell)
        {
            if (newCell.getPiece() != null)
            {
                //check if a new piece was chosen
                if (oldCell.getPiece().Color == newCell.getPiece().Color)
                {
                    view.getBoard().resetCellsBackColor(PossibleMovesCoord);
                    PossibleMovesCoord = newCell.getPiece().getPosibileMoves2(newCell.getCoord(), model);
                    //PossibleMovesCoord = newCell.getPiece().getPosibileMoves(newCell.getCoord(), view.getBoard().Cells);
                    view.getBoard().colorAvailableMoves(PossibleMovesCoord);
                    boardCell = newCell;
                    return true;
                }
            }
            return false;
        }

        private bool processTheMove(Cell oldCell, Cell newCell, Player player)
        {
            //the move was not executed
            bool isMoveExecutedSuccessfully = false;

            //check if the move can be executed
            if (oldCell != newCell && PossibleMovesCoord.Contains(new Tuple<int, int>(newCell.getCoord().Item2, newCell.getCoord().Item1)))
            {
                //check if a piece is captured
                checkIfCaptured(newCell, player);
                //set the move details (to be sent to the other player)
                setLastMove(oldCell, newCell);
                //execute the move
                executeTheMove(ref oldCell, ref newCell);
                //for the piece selected, the possible new locations (cells) were 'highlighted' on the board
                //now, these cells' backcolor has to be reset to the original color
                view.getBoard().resetCellsBackColor(PossibleMovesCoord);
                //check if the moved piece can be promoted
                checkIfPromoted(newCell);

                //the move was executed
                isMoveExecutedSuccessfully = true;
            }
            return isMoveExecutedSuccessfully;
        }

        private void checkIfPromoted(Cell newCell)
        {
            if (!newCell.getPiece().isPromoted())
            {
                if (isInPromotionZone(newCell))
                {
                    DialogResult dr = MessageBox.Show(" Evolve selected piece ? ", "Evolution Pannel", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        newCell.setPiece(newCell.getPiece().promotePiece());
                        model.promotePiece(new Tuple<int, int>(newCell.getCoord().Item2, newCell.getCoord().Item1));
                    }
                }
            }
        }

        private void setLastMove(Cell oldCell, Cell newCell)
        {
            //send move to the other player
            //mirrored
            lastMove[0] = new Tuple<int, int>(8 - oldCell.getCoord().Item2, 8 - oldCell.getCoord().Item1);
            lastMove[1] = new Tuple<int, int>(8 - newCell.getCoord().Item2, 8 - newCell.getCoord().Item1);
        }

        private void checkIfCaptured(Cell newCell, Player player)
        {
            //check if a piece was captured
            if (newCell.getPiece() != null)
            {
                player.Captured.addToCapturedPices(newCell.getPiece());
            }
        }

        public void executeTheMove(ref Cell oldCell, ref Cell newCell)
        {
            newCell.setPiece(oldCell.getPiece());
            oldCell.removePiece();
            oldCell.Image = null;
            //update model
            model.movePiece(
                new Tuple<int, int>(oldCell.getCoord().Item2, oldCell.getCoord().Item1),
                new Tuple<int, int>(newCell.getCoord().Item2, newCell.getCoord().Item1));

            //after the move execution, player's turn must be switched
            makeAIMove();
        }

        public void selectCapturedPiece(Cell cell)
        {

            if (capturedPieceSelected)
            {
                capturedCell.BackColor = Color.Crimson;
                view.getBoard().resetCellsBackColor(PossibleMovesCoord);
            }
            if (playerController.getCurrentPlayer().Captured.isThePieceCaptured(cell.getPiece()))
            {
                capturedCell = cell;
                cell.BackColor = Color.PaleGreen;
                capturedPieceSelected = true;
                pieceSelected = false;

                Tuple<int, int> capturedCoords = new Tuple<int, int>(cell.getCoord().Item1, cell.getCoord().Item2);
                PossibleMovesCoord = model.getPossibleMovesForCaptured(capturedCoords);

                if (PossibleMovesCoord.Count != 0)
                {
                    view.getBoard().colorAvailableMoves(PossibleMovesCoord);
                }

            }
            else
            {
                DialogResult dr = MessageBox.Show("There's no captured piece of this type!", "Wrong choice", MessageBoxButtons.OK);
            }

        }

        public bool isInPromotionZone(Cell cell)
        {

            if (cell.getPiece().Color.Equals("W"))
            {
                if ((cell.getCoord().Item2 >= 0 && cell.getCoord().Item2 <= 2))
                {
                    return true;
                }
            }

            if (cell.getPiece().Color.Equals("B"))
            {
                if (cell.getCoord().Item2 <= 7 && cell.getCoord().Item2 >= 6)
                {
                    return true;
                }
            }

            return false;
        }

        public void resetGame()
        {
            model.resetModel();
            playerController.getPlayer1().Captured.updateCapturedFromModel(model, "W");
            playerController.getPlayer2().Captured.updateCapturedFromModel(model, "B");
            view.getBoard().updateBoardFromModel(model);
        }

        public void undoMove()
        {

        }

    }
}
