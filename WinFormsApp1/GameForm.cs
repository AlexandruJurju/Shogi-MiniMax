

namespace WinFormsApp1
{
    public partial class gameForm : Form
    {
        private Display display;
        private MoveController moveController;
        private PlayerController playerController;
        private Model model;

        private ComboBox depthComboBox;

        public gameForm()
        {
            InitializeComponent();
            display = new Display(new Board(this), new Indicator());

            this.Controls.Add(display.getDepthComboBox());
            this.Controls.Add(display.getDepthLabel());

            display.getIndicator().getPlayerIndicator().Visible = false;

            Player player1;
            Player player2;

            player1 = new Player("W");
            player1.Captured.addToForm(this);
            player1.Captured.display(this, 650, 500);

            player2 = new Player("B");
            player2.Captured.addToForm(this);
            player2.Captured.display(this, 650, 100);

            playerController = new PlayerController(player1, player2, player1, true, false);
            model = new Model();
            moveController = new MoveController(display, playerController, model);
            player1.Captured.updateCapturedFromModel(model, "W");
            player2.Captured.updateCapturedFromModel(model, "B");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1250, 750);
            this.Location = new Point(0, 0);

            this.CenterToScreen();

            display.getBoard().startPieces();
            display.getBoard().addCellsToForm(this);

            this.Controls.Add(display.getIndicator().getPlayerIndicator());
            display.displayCurrentPlayer("P1");
        }

        public void clickOnCell(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            moveController.move(cell);
        }

        public void clickOnCaptured(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            moveController.selectCapturedPiece(cell);
        }


        internal Display getDisplay()
        {
            return display;
        }

        internal MoveController getMoveController()
        {
            return moveController;
        }

        internal PlayerController getPlayerController()
        {
            return playerController;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveController.resetGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveController.undoMove();
        }
    }
}