using System;
using System.Drawing;
using System.Windows.Forms;

namespace chisla
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel gamePanel;
        private Button newGameButton;
        private Label movesLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.BackgroundImage = Image.FromFile(@"..\..\Assets\bgimage.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.gamePanel = new TableLayoutPanel();
            this.newGameButton = new Button();
            this.movesLabel = new Label();

            this.gamePanel.Size = new Size(360, 360);
            this.gamePanel.Location = new Point(12, 40);
            this.gamePanel.BackColor = Color.Transparent;

            this.gamePanel.RowCount = 4;
            this.gamePanel.ColumnCount = 4;

            this.gamePanel.AutoSize = false;
            this.gamePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            for (int i = 0; i < 4; i++)
            {
                this.gamePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
                this.gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            }

            this.gamePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            for (int i = 0; i < 4; i++)
            {
                this.gamePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
                this.gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            }

            this.newGameButton.Text = "New Game";
            this.newGameButton.Location = new Point(12, 415);
            this.newGameButton.Size = new Size(100, 30);
            this.newGameButton.Click += new EventHandler(this.newGameButton_Click);

            this.movesLabel.Text = "Moves: 0";
            this.movesLabel.Location = new Point(270, 12);
            this.movesLabel.Size = new Size(100, 20);
            this.movesLabel.Font = new Font("Arial", 10);

            this.Text = "Fifteen Puzzle";
            this.Size = new Size(400, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.gamePanel);
        }
    }
}