namespace View
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.p1Label = new System.Windows.Forms.Label();
            this.p2Label = new System.Windows.Forms.Label();
            this.p1Wins = new System.Windows.Forms.TextBox();
            this.p2Wins = new System.Windows.Forms.TextBox();
            this.newGame = new System.Windows.Forms.Button();
            this.statusIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::View.Properties.Resources.kisspng_tic_tac_toe_bitmap_computer_icons_bmp_file_format_5b212cde520e92_4886368715289008303361;
            this.pictureBox1.Location = new System.Drawing.Point(67, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 495);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // p1Label
            // 
            this.p1Label.AutoSize = true;
            this.p1Label.Location = new System.Drawing.Point(77, 48);
            this.p1Label.Name = "p1Label";
            this.p1Label.Size = new System.Drawing.Size(72, 13);
            this.p1Label.TabIndex = 1;
            this.p1Label.Text = "Player 1 Wins";
            // 
            // p2Label
            // 
            this.p2Label.AutoSize = true;
            this.p2Label.Location = new System.Drawing.Point(491, 48);
            this.p2Label.Name = "p2Label";
            this.p2Label.Size = new System.Drawing.Size(72, 13);
            this.p2Label.TabIndex = 2;
            this.p2Label.Text = "Player 2 Wins";
            // 
            // p1Wins
            // 
            this.p1Wins.Location = new System.Drawing.Point(80, 64);
            this.p1Wins.Name = "p1Wins";
            this.p1Wins.Size = new System.Drawing.Size(60, 20);
            this.p1Wins.TabIndex = 3;
            // 
            // p2Wins
            // 
            this.p2Wins.Location = new System.Drawing.Point(493, 64);
            this.p2Wins.Name = "p2Wins";
            this.p2Wins.Size = new System.Drawing.Size(70, 20);
            this.p2Wins.TabIndex = 4;
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(282, 12);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 23);
            this.newGame.TabIndex = 5;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            // 
            // statusIndicator
            // 
            this.statusIndicator.AutoSize = true;
            this.statusIndicator.Location = new System.Drawing.Point(279, 64);
            this.statusIndicator.Name = "statusIndicator";
            this.statusIndicator.Size = new System.Drawing.Size(77, 13);
            this.statusIndicator.TabIndex = 6;
            this.statusIndicator.Text = "Player 1\'s Turn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 580);
            this.Controls.Add(this.statusIndicator);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.p2Wins);
            this.Controls.Add(this.p1Wins);
            this.Controls.Add(this.p2Label);
            this.Controls.Add(this.p1Label);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Tic-Tac-Toe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label p1Label;
        private System.Windows.Forms.Label p2Label;
        private System.Windows.Forms.TextBox p1Wins;
        private System.Windows.Forms.TextBox p2Wins;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Label statusIndicator;
    }
}

