namespace GuessTheNumberGame
{
    partial class StartDifficultyForm
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
            this.DifficultyPanel = new System.Windows.Forms.Panel();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.WindowLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClosingLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DifficultyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DifficultyPanel
            // 
            this.DifficultyPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DifficultyPanel.Controls.Add(this.MinimizeLabel);
            this.DifficultyPanel.Controls.Add(this.WindowLabel);
            this.DifficultyPanel.Controls.Add(this.label3);
            this.DifficultyPanel.Controls.Add(this.ClosingLabel);
            this.DifficultyPanel.Controls.Add(this.label1);
            this.DifficultyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DifficultyPanel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyPanel.Location = new System.Drawing.Point(0, 0);
            this.DifficultyPanel.Name = "DifficultyPanel";
            this.DifficultyPanel.Size = new System.Drawing.Size(1264, 681);
            this.DifficultyPanel.TabIndex = 0;
            this.DifficultyPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDown);
            this.DifficultyPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMove);
            this.DifficultyPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowUp);
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeLabel.Location = new System.Drawing.Point(1141, 9);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(31, 23);
            this.MinimizeLabel.TabIndex = 8;
            this.MinimizeLabel.Text = "---";
            this.MinimizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeClick);
            // 
            // WindowLabel
            // 
            this.WindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowLabel.AutoSize = true;
            this.WindowLabel.BackColor = System.Drawing.Color.Transparent;
            this.WindowLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.WindowLabel.Location = new System.Drawing.Point(1188, 9);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(22, 23);
            this.WindowLabel.TabIndex = 7;
            this.WindowLabel.Text = "[]";
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WindowLabel.Click += new System.EventHandler(this.WindowClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "SITS  |  Python Pioneers ---";
            // 
            // ClosingLabel
            // 
            this.ClosingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClosingLabel.AutoSize = true;
            this.ClosingLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClosingLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClosingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ClosingLabel.Location = new System.Drawing.Point(1226, 9);
            this.ClosingLabel.Name = "ClosingLabel";
            this.ClosingLabel.Size = new System.Drawing.Size(26, 26);
            this.ClosingLabel.TabIndex = 5;
            this.ClosingLabel.Text = "X";
            this.ClosingLabel.Click += new System.EventHandler(this.ClosingClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Go back!";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // StartDifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.DifficultyPanel);
            this.Name = "StartDifficultyForm";
            this.Text = "Python Pioneers  |  Guess The Number!";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.StartDifficultyLoad);
            this.DifficultyPanel.ResumeLayout(false);
            this.DifficultyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DifficultyPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.Label WindowLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ClosingLabel;
    }
}