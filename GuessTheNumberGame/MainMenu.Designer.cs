using System.Reflection;
using System.Windows.Forms;

namespace GuessTheNumberGame
{
    partial class MainMenuForm
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
            this.components = new System.ComponentModel.Container();
            this.TimeToday = new System.Windows.Forms.Timer(this.components);
            this.FadingBackground = new System.Windows.Forms.Timer(this.components);
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.GuidingLabel = new System.Windows.Forms.Label();
            this.NumberHolderLabel = new System.Windows.Forms.Label();
            this.GuessTheNumberLogo = new System.Windows.Forms.PictureBox();
            this.GitHubPicture = new System.Windows.Forms.PictureBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.WindowLabel = new System.Windows.Forms.Label();
            this.ClosingLabel = new System.Windows.Forms.Label();
            this.PressAnyButtonLabel = new System.Windows.Forms.Label();
            this.UnderlineLabel = new System.Windows.Forms.Label();
            this.ClosingTime = new System.Windows.Forms.Timer(this.components);
            this.OpeningTime = new System.Windows.Forms.Timer(this.components);
            this.OpeningTransition = new System.Windows.Forms.Timer(this.components);
            this.WaitingTimer = new System.Windows.Forms.Timer(this.components);
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuessTheNumberLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GitHubPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeToday
            // 
            this.TimeToday.Interval = 1000;
            this.TimeToday.Tick += new System.EventHandler(this.TimeTicking);
            // 
            // FadingBackground
            // 
            this.FadingBackground.Interval = 1;
            this.FadingBackground.Tick += new System.EventHandler(this.FadingTick);
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.Controls.Add(this.CountdownLabel);
            this.MainMenuPanel.Controls.Add(this.GuidingLabel);
            this.MainMenuPanel.Controls.Add(this.NumberHolderLabel);
            this.MainMenuPanel.Controls.Add(this.GuessTheNumberLogo);
            this.MainMenuPanel.Controls.Add(this.GitHubPicture);
            this.MainMenuPanel.Controls.Add(this.TimeLabel);
            this.MainMenuPanel.Controls.Add(this.MinimizeLabel);
            this.MainMenuPanel.Controls.Add(this.WindowLabel);
            this.MainMenuPanel.Controls.Add(this.ClosingLabel);
            this.MainMenuPanel.Controls.Add(this.PressAnyButtonLabel);
            this.MainMenuPanel.Controls.Add(this.UnderlineLabel);
            this.MainMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuPanel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuPanel.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(1264, 681);
            this.MainMenuPanel.TabIndex = 0;
            this.MainMenuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDown);
            this.MainMenuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMove);
            this.MainMenuPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowUp);
            // 
            // GuidingLabel
            // 
            this.GuidingLabel.AutoSize = true;
            this.GuidingLabel.Location = new System.Drawing.Point(550, 509);
            this.GuidingLabel.Name = "GuidingLabel";
            this.GuidingLabel.Size = new System.Drawing.Size(181, 23);
            this.GuidingLabel.TabIndex = 9;
            this.GuidingLabel.Text = "Number must be 0-250";
            this.GuidingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NumberHolderLabel
            // 
            this.NumberHolderLabel.AutoSize = true;
            this.NumberHolderLabel.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberHolderLabel.Location = new System.Drawing.Point(406, 432);
            this.NumberHolderLabel.Name = "NumberHolderLabel";
            this.NumberHolderLabel.Size = new System.Drawing.Size(468, 60);
            this.NumberHolderLabel.TabIndex = 8;
            this.NumberHolderLabel.Text = "                                        ";
            this.NumberHolderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NumberHolderLabel.UseCompatibleTextRendering = true;
            this.NumberHolderLabel.UseMnemonic = false;
            // 
            // GuessTheNumberLogo
            // 
            this.GuessTheNumberLogo.Image = global::GuessTheNumberGame.Properties.Resources.GuessTheNumberLogo;
            this.GuessTheNumberLogo.Location = new System.Drawing.Point(280, -335);
            this.GuessTheNumberLogo.Name = "GuessTheNumberLogo";
            this.GuessTheNumberLogo.Size = new System.Drawing.Size(720, 360);
            this.GuessTheNumberLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GuessTheNumberLogo.TabIndex = 7;
            this.GuessTheNumberLogo.TabStop = false;
            // 
            // GitHubPicture
            // 
            this.GitHubPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GitHubPicture.Image = global::GuessTheNumberGame.Properties.Resources.GitHub40p;
            this.GitHubPicture.Location = new System.Drawing.Point(12, 649);
            this.GitHubPicture.Name = "GitHubPicture";
            this.GitHubPicture.Size = new System.Drawing.Size(20, 20);
            this.GitHubPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GitHubPicture.TabIndex = 6;
            this.GitHubPicture.TabStop = false;
            this.GitHubPicture.Click += new System.EventHandler(this.GitHubPictureClick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TimeLabel.Location = new System.Drawing.Point(12, 5);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(152, 23);
            this.TimeLabel.TabIndex = 5;
            this.TimeLabel.Text = "Time & Date Goes Here";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TimeLabel.UseCompatibleTextRendering = true;
            this.TimeLabel.UseMnemonic = false;
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeLabel.Location = new System.Drawing.Point(1188, 5);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(23, 18);
            this.MinimizeLabel.TabIndex = 4;
            this.MinimizeLabel.Text = "---";
            this.MinimizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeLabelClick);
            // 
            // WindowLabel
            // 
            this.WindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowLabel.AutoSize = true;
            this.WindowLabel.BackColor = System.Drawing.Color.Transparent;
            this.WindowLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.WindowLabel.Location = new System.Drawing.Point(1217, 5);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(18, 18);
            this.WindowLabel.TabIndex = 3;
            this.WindowLabel.Text = "[]";
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WindowLabel.Click += new System.EventHandler(this.WindowLabelClick);
            // 
            // ClosingLabel
            // 
            this.ClosingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClosingLabel.AutoSize = true;
            this.ClosingLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClosingLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClosingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ClosingLabel.Location = new System.Drawing.Point(1241, 5);
            this.ClosingLabel.Name = "ClosingLabel";
            this.ClosingLabel.Size = new System.Drawing.Size(20, 20);
            this.ClosingLabel.TabIndex = 1;
            this.ClosingLabel.Text = "X";
            this.ClosingLabel.Click += new System.EventHandler(this.ClosingLabelClick);
            // 
            // PressAnyButtonLabel
            // 
            this.PressAnyButtonLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PressAnyButtonLabel.AutoSize = true;
            this.PressAnyButtonLabel.BackColor = System.Drawing.Color.Transparent;
            this.PressAnyButtonLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressAnyButtonLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PressAnyButtonLabel.Location = new System.Drawing.Point(373, 807);
            this.PressAnyButtonLabel.Name = "PressAnyButtonLabel";
            this.PressAnyButtonLabel.Size = new System.Drawing.Size(535, 45);
            this.PressAnyButtonLabel.TabIndex = 0;
            this.PressAnyButtonLabel.Text = "-  Press Any Button to Continue   -";
            this.PressAnyButtonLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // UnderlineLabel
            // 
            this.UnderlineLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnderlineLabel.Location = new System.Drawing.Point(435, 472);
            this.UnderlineLabel.Name = "UnderlineLabel";
            this.UnderlineLabel.Size = new System.Drawing.Size(420, 37);
            this.UnderlineLabel.TabIndex = 10;
            this.UnderlineLabel.Text = "_______________________________";
            // 
            // ClosingTime
            // 
            this.ClosingTime.Interval = 5;
            this.ClosingTime.Tick += new System.EventHandler(this.ClosingTick);
            // 
            // OpeningTime
            // 
            this.OpeningTime.Interval = 5;
            this.OpeningTime.Tick += new System.EventHandler(this.OpeningTick);
            // 
            // OpeningTransition
            // 
            this.OpeningTransition.Interval = 1;
            this.OpeningTransition.Tick += new System.EventHandler(this.OpningTransitionTick);
            // 
            // WaitingTimer
            // 
            this.WaitingTimer.Interval = 1000;
            this.WaitingTimer.Tick += new System.EventHandler(this.WaitingTick);
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.Location = new System.Drawing.Point(524, 346);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(239, 38);
            this.CountdownLabel.TabIndex = 11;
            this.CountdownLabel.Text = "Timer Goes Here:";
            this.CountdownLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CountdownTimer
            // 
            this.CountdownTimer.Interval = 1000;
            this.CountdownTimer.Tick += new System.EventHandler(this.CountdownTick);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.MainMenuPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "MainMenuForm";
            this.Text = "Python Pioneers | Guess The Number";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.MainMenuLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenuDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainMenuPress);
            this.MainMenuPanel.ResumeLayout(false);
            this.MainMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuessTheNumberLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GitHubPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label PressAnyButtonLabel;
        private Label ClosingLabel;
        private Label WindowLabel;
        private Label MinimizeLabel;
        private Panel MainMenuPanel;
        private Timer TimeToday;
        private Label TimeLabel;
        private PictureBox GitHubPicture;
        private PictureBox GuessTheNumberLogo;
        private Timer FadingBackground;
        private Timer ClosingTime;
        private Timer OpeningTime;
        private Timer OpeningTransition;
        private Label GuidingLabel;
        private Label UnderlineLabel;
        private Label NumberHolderLabel;
        private Timer WaitingTimer;
        private Label CountdownLabel;
        private Timer CountdownTimer;
    }
}

