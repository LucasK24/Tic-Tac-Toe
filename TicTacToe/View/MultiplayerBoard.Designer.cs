namespace View
{
    partial class MultiplayerBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplayerBoard));
            this.p1Label = new System.Windows.Forms.Label();
            this.p2Label = new System.Windows.Forms.Label();
            this.p1Wins = new System.Windows.Forms.TextBox();
            this.p2Wins = new System.Windows.Forms.TextBox();
            this.newGame = new System.Windows.Forms.Button();
            this.statusIndicator = new System.Windows.Forms.Label();
            this.gridPicture = new System.Windows.Forms.PictureBox();
            this.topLeft = new System.Windows.Forms.Button();
            this.topMiddle = new System.Windows.Forms.Button();
            this.topRight = new System.Windows.Forms.Button();
            this.centerLeft = new System.Windows.Forms.Button();
            this.centerMiddle = new System.Windows.Forms.Button();
            this.centerRight = new System.Windows.Forms.Button();
            this.bottomLeft = new System.Windows.Forms.Button();
            this.bottomMiddle = new System.Windows.Forms.Button();
            this.bottomRight = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridPicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1Label
            // 
            this.p1Label.AutoSize = true;
            this.p1Label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Label.Location = new System.Drawing.Point(114, 37);
            this.p1Label.Name = "p1Label";
            this.p1Label.Size = new System.Drawing.Size(79, 26);
            this.p1Label.TabIndex = 1;
            this.p1Label.Text = "Player 1";
            // 
            // p2Label
            // 
            this.p2Label.AutoSize = true;
            this.p2Label.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Label.Location = new System.Drawing.Point(478, 37);
            this.p2Label.Name = "p2Label";
            this.p2Label.Size = new System.Drawing.Size(79, 26);
            this.p2Label.TabIndex = 2;
            this.p2Label.Text = "Player 2";
            // 
            // p1Wins
            // 
            this.p1Wins.Enabled = false;
            this.p1Wins.Location = new System.Drawing.Point(129, 64);
            this.p1Wins.Name = "p1Wins";
            this.p1Wins.Size = new System.Drawing.Size(46, 20);
            this.p1Wins.TabIndex = 3;
            this.p1Wins.Text = "0";
            this.p1Wins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // p2Wins
            // 
            this.p2Wins.Enabled = false;
            this.p2Wins.Location = new System.Drawing.Point(493, 64);
            this.p2Wins.Name = "p2Wins";
            this.p2Wins.Size = new System.Drawing.Size(46, 20);
            this.p2Wins.TabIndex = 4;
            this.p2Wins.Text = "0";
            this.p2Wins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(296, 54);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(85, 32);
            this.newGame.TabIndex = 5;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // statusIndicator
            // 
            this.statusIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusIndicator.AutoSize = true;
            this.statusIndicator.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusIndicator.Location = new System.Drawing.Point(5, 4);
            this.statusIndicator.Name = "statusIndicator";
            this.statusIndicator.Size = new System.Drawing.Size(188, 36);
            this.statusIndicator.TabIndex = 6;
            this.statusIndicator.Text = "Player 1\'s Turn";
            this.statusIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridPicture
            // 
            this.gridPicture.Image = ((System.Drawing.Image)(resources.GetObject("gridPicture.Image")));
            this.gridPicture.Location = new System.Drawing.Point(80, 90);
            this.gridPicture.Name = "gridPicture";
            this.gridPicture.Size = new System.Drawing.Size(483, 489);
            this.gridPicture.TabIndex = 7;
            this.gridPicture.TabStop = false;
            // 
            // topLeft
            // 
            this.topLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topLeft.FlatAppearance.BorderSize = 0;
            this.topLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topLeft.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topLeft.Location = new System.Drawing.Point(120, 124);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(125, 133);
            this.topLeft.TabIndex = 8;
            this.topLeft.UseVisualStyleBackColor = false;
            this.topLeft.Click += new System.EventHandler(this.topLeft_Click);
            // 
            // topMiddle
            // 
            this.topMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topMiddle.FlatAppearance.BorderSize = 0;
            this.topMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topMiddle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMiddle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topMiddle.Location = new System.Drawing.Point(272, 124);
            this.topMiddle.Name = "topMiddle";
            this.topMiddle.Size = new System.Drawing.Size(126, 133);
            this.topMiddle.TabIndex = 9;
            this.topMiddle.UseVisualStyleBackColor = false;
            this.topMiddle.Click += new System.EventHandler(this.topMiddle_Click);
            // 
            // topRight
            // 
            this.topRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topRight.FlatAppearance.BorderSize = 0;
            this.topRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topRight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topRight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topRight.Location = new System.Drawing.Point(426, 124);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(126, 133);
            this.topRight.TabIndex = 10;
            this.topRight.UseVisualStyleBackColor = false;
            this.topRight.Click += new System.EventHandler(this.topRight_Click);
            // 
            // centerLeft
            // 
            this.centerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.centerLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.centerLeft.FlatAppearance.BorderSize = 0;
            this.centerLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centerLeft.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.centerLeft.Location = new System.Drawing.Point(119, 284);
            this.centerLeft.Name = "centerLeft";
            this.centerLeft.Size = new System.Drawing.Size(126, 131);
            this.centerLeft.TabIndex = 11;
            this.centerLeft.UseVisualStyleBackColor = false;
            this.centerLeft.Click += new System.EventHandler(this.centerLeft_Click);
            // 
            // centerMiddle
            // 
            this.centerMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.centerMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.centerMiddle.FlatAppearance.BorderSize = 0;
            this.centerMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centerMiddle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerMiddle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.centerMiddle.Location = new System.Drawing.Point(272, 284);
            this.centerMiddle.Name = "centerMiddle";
            this.centerMiddle.Size = new System.Drawing.Size(126, 131);
            this.centerMiddle.TabIndex = 12;
            this.centerMiddle.UseVisualStyleBackColor = false;
            this.centerMiddle.Click += new System.EventHandler(this.centerMiddle_Click);
            // 
            // centerRight
            // 
            this.centerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.centerRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.centerRight.FlatAppearance.BorderSize = 0;
            this.centerRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centerRight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerRight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.centerRight.Location = new System.Drawing.Point(426, 284);
            this.centerRight.Name = "centerRight";
            this.centerRight.Size = new System.Drawing.Size(126, 131);
            this.centerRight.TabIndex = 13;
            this.centerRight.UseVisualStyleBackColor = false;
            this.centerRight.Click += new System.EventHandler(this.centerRight_Click);
            // 
            // bottomLeft
            // 
            this.bottomLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomLeft.FlatAppearance.BorderSize = 0;
            this.bottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomLeft.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bottomLeft.Location = new System.Drawing.Point(120, 441);
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(126, 138);
            this.bottomLeft.TabIndex = 14;
            this.bottomLeft.UseVisualStyleBackColor = false;
            this.bottomLeft.Click += new System.EventHandler(this.bottomLeft_Click);
            // 
            // bottomMiddle
            // 
            this.bottomMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomMiddle.FlatAppearance.BorderSize = 0;
            this.bottomMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomMiddle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomMiddle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bottomMiddle.Location = new System.Drawing.Point(272, 441);
            this.bottomMiddle.Name = "bottomMiddle";
            this.bottomMiddle.Size = new System.Drawing.Size(126, 138);
            this.bottomMiddle.TabIndex = 15;
            this.bottomMiddle.UseVisualStyleBackColor = false;
            this.bottomMiddle.Click += new System.EventHandler(this.bottomMiddle_Click);
            // 
            // bottomRight
            // 
            this.bottomRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bottomRight.FlatAppearance.BorderSize = 0;
            this.bottomRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomRight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomRight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bottomRight.Location = new System.Drawing.Point(426, 441);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(126, 138);
            this.bottomRight.TabIndex = 16;
            this.bottomRight.UseVisualStyleBackColor = false;
            this.bottomRight.Click += new System.EventHandler(this.bottomRight_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.Controls.Add(this.statusIndicator, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(244, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 45);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // MultiplayerBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(660, 580);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.bottomMiddle);
            this.Controls.Add(this.bottomLeft);
            this.Controls.Add(this.centerRight);
            this.Controls.Add(this.centerMiddle);
            this.Controls.Add(this.centerLeft);
            this.Controls.Add(this.topRight);
            this.Controls.Add(this.topMiddle);
            this.Controls.Add(this.topLeft);
            this.Controls.Add(this.gridPicture);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.p2Wins);
            this.Controls.Add(this.p1Wins);
            this.Controls.Add(this.p2Label);
            this.Controls.Add(this.p1Label);
            this.Name = "MultiplayerBoard";
            this.Text = "Tic-Tac-Toe";
            ((System.ComponentModel.ISupportInitialize)(this.gridPicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label p1Label;
        private System.Windows.Forms.Label p2Label;
        private System.Windows.Forms.TextBox p1Wins;
        private System.Windows.Forms.TextBox p2Wins;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Label statusIndicator;
        private System.Windows.Forms.PictureBox gridPicture;
        private System.Windows.Forms.Button topLeft;
        private System.Windows.Forms.Button topMiddle;
        private System.Windows.Forms.Button topRight;
        private System.Windows.Forms.Button centerLeft;
        private System.Windows.Forms.Button centerMiddle;
        private System.Windows.Forms.Button centerRight;
        private System.Windows.Forms.Button bottomLeft;
        private System.Windows.Forms.Button bottomMiddle;
        private System.Windows.Forms.Button bottomRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

