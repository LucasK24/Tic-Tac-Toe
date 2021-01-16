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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(39, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(677, 495);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // p1Label
            // 
            this.p1Label.AutoSize = true;
            this.p1Label.Location = new System.Drawing.Point(64, 28);
            this.p1Label.Name = "p1Label";
            this.p1Label.Size = new System.Drawing.Size(45, 13);
            this.p1Label.TabIndex = 1;
            this.p1Label.Text = "Player 1";
            // 
            // p2Label
            // 
            this.p2Label.AutoSize = true;
            this.p2Label.Location = new System.Drawing.Point(605, 28);
            this.p2Label.Name = "p2Label";
            this.p2Label.Size = new System.Drawing.Size(45, 13);
            this.p2Label.TabIndex = 2;
            this.p2Label.Text = "Player 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 608);
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
    }
}

