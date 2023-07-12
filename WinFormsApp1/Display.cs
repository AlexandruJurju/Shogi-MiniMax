using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Display
    {
        private Board board;
        private Indicator indicator;
        private ComboBox depthComboBox;
        private Label depthLabel;

        public Display(Board board, Indicator indicator)
        {
            this.board = board;
            this.indicator = indicator;

            depthComboBox = new ComboBox();
            depthComboBox.Location = new Point(850, 300);
            depthComboBox.Size = new Size(100, 100);
            depthComboBox.Items.Add("Random");
            depthComboBox.Items.Add("1");
            depthComboBox.Items.Add("2");
            depthComboBox.Items.Add("3");
            depthComboBox.Items.Add("4");
            depthComboBox.SelectedItem = "Random";
            depthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            depthLabel = new Label();
            depthLabel.Text = "MinMax depth";
            depthLabel.Size = new Size(150, 150);
            depthLabel.Location = new Point(840, 260);
            depthLabel.Font = new Font("Roboto", 12, FontStyle.Regular);
        }

        public Board getBoard() { return board; }

        public Indicator getIndicator() { return indicator; }

        public ComboBox getDepthComboBox()
        {
            return depthComboBox;
        }

        public Label getDepthLabel()
        {
            return depthLabel;
        }

        public void displayCurrentPlayer(string currentPlayerIndicator)
        {
            indicator.checkPlayer(currentPlayerIndicator);
        }
    }
}
