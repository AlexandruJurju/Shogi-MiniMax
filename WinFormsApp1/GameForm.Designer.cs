namespace WinFormsApp1
{
    partial class gameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonResetGame = new System.Windows.Forms.Button();
            this.buttonUndoMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonResetGame
            // 
            this.buttonResetGame.Location = new System.Drawing.Point(835, 341);
            this.buttonResetGame.Name = "buttonResetGame";
            this.buttonResetGame.Size = new System.Drawing.Size(139, 42);
            this.buttonResetGame.TabIndex = 0;
            this.buttonResetGame.Text = "Reset Game";
            this.buttonResetGame.UseVisualStyleBackColor = true;
            this.buttonResetGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUndoMove
            // 
            this.buttonUndoMove.Location = new System.Drawing.Point(835, 389);
            this.buttonUndoMove.Name = "buttonUndoMove";
            this.buttonUndoMove.Size = new System.Drawing.Size(139, 35);
            this.buttonUndoMove.TabIndex = 1;
            this.buttonUndoMove.Text = "Undo Move";
            this.buttonUndoMove.UseVisualStyleBackColor = true;
            this.buttonUndoMove.Click += new System.EventHandler(this.button2_Click);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 790);
            this.Controls.Add(this.buttonUndoMove);
            this.Controls.Add(this.buttonResetGame);
            this.Name = "gameForm";
            this.Text = "Shogi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonResetGame;
        private Button buttonUndoMove;
    }
}