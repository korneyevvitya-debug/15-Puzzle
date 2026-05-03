using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chisla
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[4, 4];
        private int emptyRow, emptyCol;
        private int moveCounter = 0;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(2),
                        Padding = new Padding(0),
                        Font = new Font("Neuland", 30, FontStyle.Bold),
                        ForeColor = Color.Black,
                        BackColor = Color.DarkGoldenrod,
                        Tag = new Point(i, j),
                        FlatStyle = FlatStyle.Flat,
                        UseVisualStyleBackColor = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    buttons[i, j].FlatAppearance.BorderSize = 2;
                    buttons[i, j].FlatAppearance.BorderColor = Color.DarkGoldenrod;
                    buttons[i, j].Click += Button_Click;
                    gamePanel.Controls.Add(buttons[i, j], j, i);
                }
            }
            StartNewGame();
        }

        private void StartNewGame()
        {
            int number = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 3)
                    {
                        buttons[i, j].Text = "";
                    }
                    else
                    {
                        buttons[i, j].Text = number.ToString();
                        number++;
                    }
                }
            }
            emptyRow = 3;
            emptyCol = 3;
            ShuffleButtons();
            moveCounter = 0;
            UpdateMoves();
        }

        private void ShuffleButtons()
        {
            for (int i = 0; i < 1000; i++)
            {
                var possibleMoves = GetPossibleMoves(emptyRow, emptyCol);
                if (possibleMoves.Count > 0)
                {
                    var move = possibleMoves[random.Next(possibleMoves.Count)];
                    SwapButtons(move.X, move.Y, emptyRow, emptyCol);
                    emptyRow = move.X;
                    emptyCol = move.Y;
                }
            }
        }

        private List<Point> GetPossibleMoves(int row, int col)
        {
            var moves = new List<Point>();
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (newRow >= 0 && newRow < 4 && newCol >= 0 && newCol < 4)
                {
                    moves.Add(new Point(newRow, newCol));
                }
            }
            return moves;
        }

        private void SwapButtons(int row1, int col1, int row2, int col2)
        {
            string tempText = buttons[row1, col1].Text;
            buttons[row1, col1].Text = buttons[row2, col2].Text;
            buttons[row2, col2].Text = tempText;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point position = (Point)clickedButton.Tag;
            int row = position.X;
            int col = position.Y;
            if (IsNearby(row, col, emptyRow, emptyCol))
            {
                SwapButtons(row, col, emptyRow, emptyCol);

                emptyRow = row;
                emptyCol = col;

                moveCounter++;
                UpdateMoves();

                if (CheckWin())
                {
                    using (var winForm = new WinForm(moveCounter))
                    {
                        winForm.ShowDialog();
                    }
                    StartNewGame();
                }
            }
        }

        private bool IsNearby(int row1, int col1, int row2, int col2)
        {
            return Math.Abs(row1 - row2) + Math.Abs(col1 - col2) == 1;
        }

        private bool CheckWin()
        {
            int expected = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 3) break;

                    if (!int.TryParse(buttons[i, j].Text, out int actual) || actual != expected)
                    {
                        return false;
                    }
                    expected++;
                }
            }
            return true;
        }

        private void UpdateMoves()
        {
            movesLabel.Text = $"Moves: {moveCounter}";
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
    public partial class WinForm : Form
    {
        private Label messageLabel;
        private Button cookieButton;

        public WinForm(int moveCount)
        {
            InitializeComponent();
            messageLabel.Text = $"Hurray!🎉🎉🎉{Environment.NewLine}You won in {moveCount} moves!🏆🏆🏆";
        }

        private void InitializeComponent()
        {
            this.messageLabel = new Label();
            this.cookieButton = new Button();
            this.Text = "Victory!";
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.messageLabel.AutoSize = false;
            this.messageLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            this.messageLabel.Location = new Point(20, 30);
            this.messageLabel.Size = new Size(360, 80);
            this.messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.messageLabel.ForeColor = Color.DarkRed;

            this.cookieButton.Text = "Get a cookie";
            this.cookieButton.Font = new Font("Arial", 10, FontStyle.Bold);
            this.cookieButton.Location = new Point(150, 120);
            this.cookieButton.Size = new Size(120, 35);
            this.cookieButton.BackColor = Color.Chocolate;
            this.cookieButton.ForeColor = Color.White;
            this.cookieButton.FlatStyle = FlatStyle.Flat;
            this.cookieButton.Click += CookieButton_Click;

            this.cookieButton.MouseEnter += (s, e) =>
                this.cookieButton.BackColor = Color.SaddleBrown;
            this.cookieButton.MouseLeave += (s, e) =>
                this.cookieButton.BackColor = Color.Chocolate;

            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.cookieButton);
        }

        private void CookieButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🍪 Thanks for playing!", "Cookie!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}