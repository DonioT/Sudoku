using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SudokuWF
{
    public partial class Form1 : Form
    {
        private List<TextBox> textBoxes = new List<TextBox>();
        private int[,] current_solution = null;
        private static int BOARD_SIZE = 9;
        private int GLOBAL_FONT_SIZE = 15;


        public Form1()
        {
            InitializeComponent();     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public int[,] GrabGUIData()
        {
            int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
           foreach(var tb in textBoxes)
            {
                var stringName = tb.Name;
                var text = tb.Text;

                int row = int.Parse(stringName[0].ToString());
                int column = int.Parse(stringName[1].ToString());
                if (String.IsNullOrEmpty(text))
                {
                    text = (0).ToString();
                }
                board[row, column] = int.Parse(text);
            }

            return board;
        }

        private void DrawSudoku(object sender, EventArgs e)
        {
            var previousX = 30;
            var previousY = 0;
          
            for(int i = 0; i < BOARD_SIZE; i++)
            {
                previousY = (i % 3 == 0) ? previousY + 45 : previousY + 39;
                for (int y = 0; y < BOARD_SIZE; y++)
                {
                    TextBox textBox = new TextBox();
                    textBox.AutoSize = false;
                    textBox.Size = new System.Drawing.Size(35, 35);
                    textBox.Left =  (y % 3 == 0) ? previousX + 45 : (previousX + 39);
                    textBox.Text = "";
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Font = new Font(textBox.Font.FontFamily, GLOBAL_FONT_SIZE);
                    textBox.Name = i + "" + y;
                    textBox.MaxLength = 1;
                    previousX = textBox.Left;
                    textBox.Top = previousY;
                    textBox.BringToFront();

                    
                  textBoxes.Add(textBox);
                  
                  this.Controls.Add(textBox);
                }
                previousX = 30;
            }
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            ValidateResultLabel.Text = Solvers.ValidateSolution(GrabGUIData()) ? "Good Job! You solved it!" : "Sorry! There appears to be an error in your solution";
        }

     
        private async void NewGame_Click(object sender, EventArgs e)
        {
            ValidateResultLabel.Text = "";
            Task<List<int[,]>> worker = new Task<List<int[,]>>(Generators.GenerateRandomPuzzle);
            worker.Start();

            PictureBox loading = new PictureBox();
            loading.Image = Image.FromFile(@"..\..\Assets\loader2.gif");
            loading.Size = new System.Drawing.Size(30,50);
            loading.Location = new Point(50,8);

            Label loadingLabel = new Label();
            loadingLabel.Text = "Generating a new sudoku puzzle! Please wait...";
            loadingLabel.Location = new Point(80, 10);
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font(loadingLabel.Font.FontFamily, 13);

            this.Controls.Add(loading);
            this.Controls.Add(loadingLabel);

            List<int[,]> generateNewPuzzle = await worker;
            this.Controls.Remove(loading);
            this.Controls.Remove(loadingLabel);
         
            foreach (var tb in textBoxes)
            {
                String value = generateNewPuzzle[0][int.Parse(tb.Name[0].ToString()), int.Parse(tb.Name[1].ToString())].ToString();
                value = value == (0).ToString() ? "" : value;
                tb.Font = new Font(tb.Font.FontFamily, GLOBAL_FONT_SIZE);
                tb.Text = value;
                tb.Enabled = String.IsNullOrWhiteSpace(value) ? true : false;
            }
            //set solution as global;
            current_solution = generateNewPuzzle[1];
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            ValidateResultLabel.Text = "";
            int[,] boardData = GrabGUIData();
            if (Solvers.SolvableBoard(boardData))
            {
                current_solution = current_solution == null ? Solvers.SolveBoard(boardData) : current_solution;
                foreach (var tb in textBoxes)
                {
                    String value = current_solution[int.Parse(tb.Name[0].ToString()), int.Parse(tb.Name[1].ToString())].ToString();
                    value = value == (0).ToString() ? "" : value;
                    tb.Font = new Font(tb.Font.FontFamily, GLOBAL_FONT_SIZE);
                    tb.Text = value;
                    tb.Enabled = String.IsNullOrWhiteSpace(value) ? true : false;
                }
            }
            else
            {
                ValidateResultLabel.Text = "This board is not solvable! Check for errors";
            }
           
        }

    }
}

