namespace GuessTheNumberGame
{
    partial class StartForm
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
            this.StartPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.WindowLabel = new System.Windows.Forms.Label();
            this.ClosingLabel = new System.Windows.Forms.Label();
            this.StartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartPanel
            // 
            this.StartPanel.Controls.Add(this.label3);
            this.StartPanel.Controls.Add(this.MinimizeLabel);
            this.StartPanel.Controls.Add(this.WindowLabel);
            this.StartPanel.Controls.Add(this.ClosingLabel);
            this.StartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartPanel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPanel.Location = new System.Drawing.Point(0, 0);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(1264, 681);
            this.StartPanel.TabIndex = 0;
            this.StartPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDown);
            this.StartPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMove);
            this.StartPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "SITS  |  Python Pioneers ---";
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
            this.MinimizeLabel.TabIndex = 7;
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
            this.WindowLabel.TabIndex = 6;
            this.WindowLabel.Text = "[]";
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WindowLabel.Click += new System.EventHandler(this.WindowClick);
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
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.StartPanel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "StartForm";
            this.Text = "Python Pioneers  |  Guess The Number!";
            this.Load += new System.EventHandler(this.StartLoad);
            this.StartPanel.ResumeLayout(false);
            this.StartPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.Label WindowLabel;
        private System.Windows.Forms.Label ClosingLabel;
        private System.Windows.Forms.Label label3;
    }
}