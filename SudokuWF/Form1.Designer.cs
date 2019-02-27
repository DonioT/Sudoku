namespace SudokuWF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Validate = new System.Windows.Forms.Button();
            this.New_Game = new System.Windows.Forms.Button();
            this.Solve = new System.Windows.Forms.Button();
            this.ValidateResultLabel = new System.Windows.Forms.Label();
            this.SolveResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Validate
            // 
            this.Validate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Validate.FlatAppearance.BorderSize = 2;
            this.Validate.Location = new System.Drawing.Point(74, 499);
            this.Validate.Name = "Validate";
            this.Validate.Size = new System.Drawing.Size(75, 36);
            this.Validate.TabIndex = 0;
            this.Validate.Text = "Check Answer";
            this.Validate.UseVisualStyleBackColor = true;
            this.Validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // New_Game
            // 
            this.New_Game.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.New_Game.Location = new System.Drawing.Point(74, 415);
            this.New_Game.Name = "New_Game";
            this.New_Game.Size = new System.Drawing.Size(75, 36);
            this.New_Game.TabIndex = 1;
            this.New_Game.Text = "New Game";
            this.New_Game.UseVisualStyleBackColor = true;
            this.New_Game.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(74, 457);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(75, 36);
            this.Solve.TabIndex = 2;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // ValidateResultLabel
            // 
            this.ValidateResultLabel.AutoSize = true;
            this.ValidateResultLabel.Font = new System.Drawing.Font(ValidateResultLabel.Font.FontFamily, 9);
            this.ValidateResultLabel.Location = new System.Drawing.Point(160, 507);
            this.ValidateResultLabel.Name = "ValidateResultLabel";
            this.ValidateResultLabel.Size = new System.Drawing.Size(0, 15);
            this.ValidateResultLabel.TabIndex = 3;
            // 
            // SolveResultLabel
            // 
            this.SolveResultLabel.AutoSize = true;
            this.SolveResultLabel.Location = new System.Drawing.Point(160, 465);
            this.SolveResultLabel.Font = new System.Drawing.Font(SolveResultLabel.Font.FontFamily, 9);
            this.SolveResultLabel.Name = "SolveResultLabel";
            this.SolveResultLabel.Size = new System.Drawing.Size(35, 13);
            this.SolveResultLabel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 548);
            this.Controls.Add(this.SolveResultLabel);
            this.Controls.Add(this.ValidateResultLabel);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.New_Game);
            this.Controls.Add(this.Validate);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.DrawSudoku);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Validate;
        private System.Windows.Forms.Button New_Game;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.Label ValidateResultLabel;
        private System.Windows.Forms.Label SolveResultLabel;
    }
}

