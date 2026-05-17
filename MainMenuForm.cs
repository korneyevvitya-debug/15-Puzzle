using System;
using System.Drawing;
using System.Windows.Forms;

namespace chisla
{
    public class MainMenuForm : Form
    {
        private Button startButton;
        private Button exitButton;
        private Label titleLabel;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Puzzle Menu";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.BackgroundImage = Image.FromFile(@"..\..\Assets\bgimage.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            titleLabel = new Label();
            titleLabel.Text = "Puzzle Game!";
            titleLabel.Font = new Font("Arial", 28, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(400, 60);
            titleLabel.Location = new Point(50, 40);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;



            //Начать игру
            startButton = new Button();
            startButton.Text = "Start Game";
            startButton.Font = new Font("Arial", 14, FontStyle.Bold);
            startButton.Size = new Size(200, 50);
            startButton.Location = new Point(140, 140);
            startButton.BackgroundImage = Image.FromFile(@"..\..\Assets\woodtexture.png");
            startButton.BackgroundImageLayout = ImageLayout.Stretch;
            startButton.ForeColor = Color.White;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Click += StartButton_Click;



            //Выход из игры
            exitButton = new Button();
            exitButton.Text = "Exit";
            exitButton.Font = new Font("Arial", 14, FontStyle.Bold);
            exitButton.Size = new Size(200, 50);
            exitButton.Location = new Point(140, 220);
            exitButton.BackgroundImage = Image.FromFile(@"..\..\Assets\woodtexture.png");
            exitButton.BackgroundImageLayout = ImageLayout.Stretch;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.ForeColor = Color.White;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Click += ExitButton_Click;

            this.Controls.Add(titleLabel);
            this.Controls.Add(startButton);
            this.Controls.Add(exitButton);

        }



        private void StartButton_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();

            this.Hide();

            gameForm.FormClosed += (s, args) => this.Show();

            gameForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
