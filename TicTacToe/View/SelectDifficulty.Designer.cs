
namespace View
{
    partial class SelectDifficulty
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
            this.easyButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.impossibleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.easyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(16, 323);
            this.easyButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(956, 97);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.Location = new System.Drawing.Point(16, 429);
            this.hardButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(956, 97);
            this.hardButton.TabIndex = 1;
            this.hardButton.Text = "Hard";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // impossibleButton
            // 
            this.impossibleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impossibleButton.Location = new System.Drawing.Point(16, 535);
            this.impossibleButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.impossibleButton.Name = "impossibleButton";
            this.impossibleButton.Size = new System.Drawing.Size(956, 97);
            this.impossibleButton.TabIndex = 2;
            this.impossibleButton.Text = "Impossible";
            this.impossibleButton.UseVisualStyleBackColor = true;
            this.impossibleButton.Click += new System.EventHandler(this.impossibleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select CPU Difficulty";
            // 
            // SelectDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(990, 892);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.impossibleButton);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.easyButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectDifficulty";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button impossibleButton;
        private System.Windows.Forms.Label label1;
    }
}