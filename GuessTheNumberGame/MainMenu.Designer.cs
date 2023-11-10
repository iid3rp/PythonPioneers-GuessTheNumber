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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.TimeToday = new System.Windows.Forms.Timer(this.components);
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.GuessAgainPicture = new System.Windows.Forms.PictureBox();
            this.GameOverPicture = new System.Windows.Forms.PictureBox();
            this.GoHome = new System.Windows.Forms.PictureBox();
            this.HardPicture = new System.Windows.Forms.PictureBox();
            this.NormalPicture = new System.Windows.Forms.PictureBox();
            this.EasyPicture = new System.Windows.Forms.PictureBox();
            this.DifficultySectionPicture = new System.Windows.Forms.PictureBox();
            this.CountingDownLabel = new System.Windows.Forms.Label();
            this.NumberHolderLabel = new System.Windows.Forms.Label();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.GuidingLabel = new System.Windows.Forms.Label();
            this.GuessTheNumberLogo = new System.Windows.Forms.PictureBox();
            this.GitHubPicture = new System.Windows.Forms.PictureBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.WindowLabel = new System.Windows.Forms.Label();
            this.ClosingLabel = new System.Windows.Forms.Label();
            this.PressAnyButtonLabel = new System.Windows.Forms.Label();
            this.ClosingTime = new System.Windows.Forms.Timer(this.components);
            this.OpeningTime = new System.Windows.Forms.Timer(this.components);
            this.OpeningTransition = new System.Windows.Forms.Timer(this.components);
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.CountingDownTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuessAgainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EasyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultySectionPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuessTheNumberLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GitHubPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeToday
            // 
            this.TimeToday.Interval = 1;
            this.TimeToday.Tick += new System.EventHandler(this.TimeTicking);
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenuPanel.Controls.Add(this.GuessAgainPicture);
            this.MainMenuPanel.Controls.Add(this.GameOverPicture);
            this.MainMenuPanel.Controls.Add(this.GoHome);
            this.MainMenuPanel.Controls.Add(this.HardPicture);
            this.MainMenuPanel.Controls.Add(this.NormalPicture);
            this.MainMenuPanel.Controls.Add(this.EasyPicture);
            this.MainMenuPanel.Controls.Add(this.DifficultySectionPicture);
            this.MainMenuPanel.Controls.Add(this.CountingDownLabel);
            this.MainMenuPanel.Controls.Add(this.NumberHolderLabel);
            this.MainMenuPanel.Controls.Add(this.CountdownLabel);
            this.MainMenuPanel.Controls.Add(this.GuidingLabel);
            this.MainMenuPanel.Controls.Add(this.GuessTheNumberLogo);
            this.MainMenuPanel.Controls.Add(this.GitHubPicture);
            this.MainMenuPanel.Controls.Add(this.TimeLabel);
            this.MainMenuPanel.Controls.Add(this.MinimizeLabel);
            this.MainMenuPanel.Controls.Add(this.WindowLabel);
            this.MainMenuPanel.Controls.Add(this.ClosingLabel);
            this.MainMenuPanel.Controls.Add(this.PressAnyButtonLabel);
            this.MainMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuPanel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuPanel.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(1264, 681);
            this.MainMenuPanel.TabIndex = 0;
            this.MainMenuPanel.Click += new System.EventHandler(this.MainMenuClick);
            this.MainMenuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDown);
            this.MainMenuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMove);
            this.MainMenuPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowUp);
            // 
            // GuessAgainPicture
            // 
            this.GuessAgainPicture.Image = global::GuessTheNumberGame.Properties.Resources.GuessAgain;
            this.GuessAgainPicture.Location = new System.Drawing.Point(711, 1549);
            this.GuessAgainPicture.Name = "GuessAgainPicture";
            this.GuessAgainPicture.Size = new System.Drawing.Size(294, 100);
            this.GuessAgainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GuessAgainPicture.TabIndex = 34;
            this.GuessAgainPicture.TabStop = false;
            // 
            // GameOverPicture
            // 
            this.GameOverPicture.Image = global::GuessTheNumberGame.Properties.Resources.GameOver;
            this.GameOverPicture.Location = new System.Drawing.Point(343, 1109);
            this.GameOverPicture.Name = "GameOverPicture";
            this.GameOverPicture.Size = new System.Drawing.Size(531, 180);
            this.GameOverPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameOverPicture.TabIndex = 33;
            this.GameOverPicture.TabStop = false;
            // 
            // GoHome
            // 
            this.GoHome.Image = ((System.Drawing.Image)(resources.GetObject("GoHome.Image")));
            this.GoHome.Location = new System.Drawing.Point(12, 1619);
            this.GoHome.Name = "GoHome";
            this.GoHome.Size = new System.Drawing.Size(147, 50);
            this.GoHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GoHome.TabIndex = 32;
            this.GoHome.TabStop = false;
            this.GoHome.Click += new System.EventHandler(this.GoHome_Click);
            // 
            // HardPicture
            // 
            this.HardPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HardPicture.Image = ((System.Drawing.Image)(resources.GetObject("HardPicture.Image")));
            this.HardPicture.Location = new System.Drawing.Point(830, 1430);
            this.HardPicture.Name = "HardPicture";
            this.HardPicture.Size = new System.Drawing.Size(295, 100);
            this.HardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HardPicture.TabIndex = 31;
            this.HardPicture.TabStop = false;
            this.HardPicture.Click += new System.EventHandler(this.HardPicture_Click);
            // 
            // NormalPicture
            // 
            this.NormalPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NormalPicture.Image = ((System.Drawing.Image)(resources.GetObject("NormalPicture.Image")));
            this.NormalPicture.Location = new System.Drawing.Point(830, 1288);
            this.NormalPicture.Name = "NormalPicture";
            this.NormalPicture.Size = new System.Drawing.Size(295, 100);
            this.NormalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NormalPicture.TabIndex = 30;
            this.NormalPicture.TabStop = false;
            this.NormalPicture.Click += new System.EventHandler(this.NormalPicture_Click);
            // 
            // EasyPicture
            // 
            this.EasyPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EasyPicture.Image = ((System.Drawing.Image)(resources.GetObject("EasyPicture.Image")));
            this.EasyPicture.Location = new System.Drawing.Point(830, 1145);
            this.EasyPicture.Name = "EasyPicture";
            this.EasyPicture.Size = new System.Drawing.Size(295, 100);
            this.EasyPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EasyPicture.TabIndex = 29;
            this.EasyPicture.TabStop = false;
            this.EasyPicture.Click += new System.EventHandler(this.EasyPicture_Click);
            // 
            // DifficultySectionPicture
            // 
            this.DifficultySectionPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DifficultySectionPicture.Image = ((System.Drawing.Image)(resources.GetObject("DifficultySectionPicture.Image")));
            this.DifficultySectionPicture.Location = new System.Drawing.Point(78, 1077);
            this.DifficultySectionPicture.Name = "DifficultySectionPicture";
            this.DifficultySectionPicture.Size = new System.Drawing.Size(500, 500);
            this.DifficultySectionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DifficultySectionPicture.TabIndex = 23;
            this.DifficultySectionPicture.TabStop = false;
            this.DifficultySectionPicture.Click += new System.EventHandler(this.TutorialPictureClick);
            // 
            // CountingDownLabel
            // 
            this.CountingDownLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountingDownLabel.AutoSize = true;
            this.CountingDownLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountingDownLabel.ForeColor = System.Drawing.Color.PaleGreen;
            this.CountingDownLabel.Location = new System.Drawing.Point(624, 1290);
            this.CountingDownLabel.Name = "CountingDownLabel";
            this.CountingDownLabel.Size = new System.Drawing.Size(77, 90);
            this.CountingDownLabel.TabIndex = 22;
            this.CountingDownLabel.Text = "3";
            this.CountingDownLabel.Visible = false;
            // 
            // NumberHolderLabel
            // 
            this.NumberHolderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NumberHolderLabel.AutoSize = true;
            this.NumberHolderLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberHolderLabel.ForeColor = System.Drawing.Color.PaleGreen;
            this.NumberHolderLabel.Location = new System.Drawing.Point(492, 353);
            this.NumberHolderLabel.Name = "NumberHolderLabel";
            this.NumberHolderLabel.Size = new System.Drawing.Size(272, 90);
            this.NumberHolderLabel.TabIndex = 13;
            this.NumberHolderLabel.Text = "---------";
            this.NumberHolderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.ForeColor = System.Drawing.Color.PaleGreen;
            this.CountdownLabel.Location = new System.Drawing.Point(511, 129);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(239, 38);
            this.CountdownLabel.TabIndex = 11;
            this.CountdownLabel.Text = "Timer Goes Here:";
            this.CountdownLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GuidingLabel
            // 
            this.GuidingLabel.AutoSize = true;
            this.GuidingLabel.ForeColor = System.Drawing.Color.PaleGreen;
            this.GuidingLabel.Location = new System.Drawing.Point(530, 462);
            this.GuidingLabel.Name = "GuidingLabel";
            this.GuidingLabel.Size = new System.Drawing.Size(191, 23);
            this.GuidingLabel.TabIndex = 9;
            this.GuidingLabel.Text = "Number must be 0 - 250";
            this.GuidingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GuessTheNumberLogo
            // 
            this.GuessTheNumberLogo.Image = global::GuessTheNumberGame.Properties.Resources.GuessTheNumberLogo;
            this.GuessTheNumberLogo.Location = new System.Drawing.Point(280, -1035);
            this.GuessTheNumberLogo.Name = "GuessTheNumberLogo";
            this.GuessTheNumberLogo.Size = new System.Drawing.Size(720, 360);
            this.GuessTheNumberLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GuessTheNumberLogo.TabIndex = 7;
            this.GuessTheNumberLogo.TabStop = false;
            // 
            // GitHubPicture
            // 
            this.GitHubPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GitHubPicture.Image = global::GuessTheNumberGame.Properties.Resources.GitHub40p;
            this.GitHubPicture.Location = new System.Drawing.Point(1232, 649);
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
            this.TimeLabel.Location = new System.Drawing.Point(12, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(209, 23);
            this.TimeLabel.TabIndex = 5;
            this.TimeLabel.Text = "<DayType>, <DayNum> | <Time24>";
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
            this.PressAnyButtonLabel.Location = new System.Drawing.Point(373, -507);
            this.PressAnyButtonLabel.Name = "PressAnyButtonLabel";
            this.PressAnyButtonLabel.Size = new System.Drawing.Size(535, 45);
            this.PressAnyButtonLabel.TabIndex = 0;
            this.PressAnyButtonLabel.Text = "-  Press Any Button to Continue   -";
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
            // CountdownTimer
            // 
            this.CountdownTimer.Interval = 1000;
            this.CountdownTimer.Tick += new System.EventHandler(this.CountdownTick);
            // 
            // CountingDownTimer
            // 
            this.CountingDownTimer.Interval = 1;
            this.CountingDownTimer.Tick += new System.EventHandler(this.CountingDownTick);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Text = "Python Pioneers | Guess The Number";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.MainMenuLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenuDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainMenuPress);
            this.MainMenuPanel.ResumeLayout(false);
            this.MainMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuessAgainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EasyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultySectionPicture)).EndInit();
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
        private Timer ClosingTime;
        private Timer OpeningTime;
        private Timer OpeningTransition;
        private Label GuidingLabel;
        private Label CountdownLabel;
        private Timer CountdownTimer;
        private Label NumberHolderLabel;
        private Label CountingDownLabel;
        private Timer CountingDownTimer;
        private PictureBox DifficultySectionPicture;
        private PictureBox HardPicture;
        private PictureBox NormalPicture;
        private PictureBox EasyPicture;
        private PictureBox GoHome;
        private PictureBox GameOverPicture;
        private PictureBox GuessAgainPicture;
    }
}

