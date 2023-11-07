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
            this.DifficultyTextLabel = new System.Windows.Forms.Label();
            this.DifficultyTypeLabel = new System.Windows.Forms.Label();
            this.DifficultyPageLabel = new System.Windows.Forms.Label();
            this.CountingDownLabel = new System.Windows.Forms.Label();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.HardLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.NormalLabel = new System.Windows.Forms.Label();
            this.EasyLabel = new System.Windows.Forms.Label();
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
            this.MainMenuPanel.Controls.Add(this.DifficultyTextLabel);
            this.MainMenuPanel.Controls.Add(this.DifficultyTypeLabel);
            this.MainMenuPanel.Controls.Add(this.DifficultyPageLabel);
            this.MainMenuPanel.Controls.Add(this.CountingDownLabel);
            this.MainMenuPanel.Controls.Add(this.LeftLabel);
            this.MainMenuPanel.Controls.Add(this.HardLabel);
            this.MainMenuPanel.Controls.Add(this.RightLabel);
            this.MainMenuPanel.Controls.Add(this.NormalLabel);
            this.MainMenuPanel.Controls.Add(this.EasyLabel);
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
            // DifficultyTextLabel
            // 
            this.DifficultyTextLabel.AutoSize = true;
            this.DifficultyTextLabel.Location = new System.Drawing.Point(113, 1200);
            this.DifficultyTextLabel.Name = "DifficultyTextLabel";
            this.DifficultyTextLabel.Size = new System.Drawing.Size(306, 253);
            this.DifficultyTextLabel.TabIndex = 15;
            this.DifficultyTextLabel.Text = resources.GetString("DifficultyTextLabel.Text");
            // 
            // DifficultyTypeLabel
            // 
            this.DifficultyTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DifficultyTypeLabel.AutoSize = true;
            this.DifficultyTypeLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyTypeLabel.Location = new System.Drawing.Point(110, 1137);
            this.DifficultyTypeLabel.Name = "DifficultyTypeLabel";
            this.DifficultyTypeLabel.Size = new System.Drawing.Size(117, 38);
            this.DifficultyTypeLabel.TabIndex = 14;
            this.DifficultyTypeLabel.Text = "Tutorial";
            // 
            // DifficultyPageLabel
            // 
            this.DifficultyPageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DifficultyPageLabel.AutoSize = true;
            this.DifficultyPageLabel.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyPageLabel.Location = new System.Drawing.Point(148, 1496);
            this.DifficultyPageLabel.Name = "DifficultyPageLabel";
            this.DifficultyPageLabel.Size = new System.Drawing.Size(122, 52);
            this.DifficultyPageLabel.TabIndex = 18;
            this.DifficultyPageLabel.Text = "1 of 3";
            this.DifficultyPageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CountingDownLabel
            // 
            this.CountingDownLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountingDownLabel.AutoSize = true;
            this.CountingDownLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountingDownLabel.Location = new System.Drawing.Point(298, 36);
            this.CountingDownLabel.Name = "CountingDownLabel";
            this.CountingDownLabel.Size = new System.Drawing.Size(77, 90);
            this.CountingDownLabel.TabIndex = 22;
            this.CountingDownLabel.Text = "3";
            this.CountingDownLabel.Visible = false;
            // 
            // LeftLabel
            // 
            this.LeftLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftLabel.Location = new System.Drawing.Point(117, 1496);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(36, 52);
            this.LeftLabel.TabIndex = 16;
            this.LeftLabel.Text = "<";
            this.LeftLabel.Click += new System.EventHandler(this.LeftLabelClick);
            // 
            // HardLabel
            // 
            this.HardLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HardLabel.AutoSize = true;
            this.HardLabel.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardLabel.Location = new System.Drawing.Point(942, 1428);
            this.HardLabel.Name = "HardLabel";
            this.HardLabel.Size = new System.Drawing.Size(142, 67);
            this.HardLabel.TabIndex = 21;
            this.HardLabel.Text = "Hard";
            this.HardLabel.Click += new System.EventHandler(this.HardLabelClick);
            // 
            // RightLabel
            // 
            this.RightLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RightLabel.AutoSize = true;
            this.RightLabel.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightLabel.Location = new System.Drawing.Point(276, 1496);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(36, 52);
            this.RightLabel.TabIndex = 17;
            this.RightLabel.Text = ">";
            this.RightLabel.Click += new System.EventHandler(this.RightLabelClick);
            // 
            // NormalLabel
            // 
            this.NormalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NormalLabel.AutoSize = true;
            this.NormalLabel.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalLabel.Location = new System.Drawing.Point(912, 1320);
            this.NormalLabel.Name = "NormalLabel";
            this.NormalLabel.Size = new System.Drawing.Size(190, 67);
            this.NormalLabel.TabIndex = 20;
            this.NormalLabel.Text = "Normal";
            this.NormalLabel.Click += new System.EventHandler(this.NormalLabelClick);
            // 
            // EasyLabel
            // 
            this.EasyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EasyLabel.AutoSize = true;
            this.EasyLabel.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyLabel.Location = new System.Drawing.Point(942, 1209);
            this.EasyLabel.Name = "EasyLabel";
            this.EasyLabel.Size = new System.Drawing.Size(132, 67);
            this.EasyLabel.TabIndex = 19;
            this.EasyLabel.Text = "Easy";
            this.EasyLabel.Click += new System.EventHandler(this.EasyLabelClick);
            // 
            // NumberHolderLabel
            // 
            this.NumberHolderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NumberHolderLabel.AutoSize = true;
            this.NumberHolderLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberHolderLabel.ForeColor = System.Drawing.Color.White;
            this.NumberHolderLabel.Location = new System.Drawing.Point(384, 902);
            this.NumberHolderLabel.Name = "NumberHolderLabel";
            this.NumberHolderLabel.Size = new System.Drawing.Size(513, 90);
            this.NumberHolderLabel.TabIndex = 13;
            this.NumberHolderLabel.Text = "type to guess :3";
            this.NumberHolderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.Location = new System.Drawing.Point(521, 846);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(239, 38);
            this.CountdownLabel.TabIndex = 11;
            this.CountdownLabel.Text = "Timer Goes Here:";
            this.CountdownLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GuidingLabel
            // 
            this.GuidingLabel.AutoSize = true;
            this.GuidingLabel.Location = new System.Drawing.Point(546, 1009);
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
            // OpeningTransition
            // 
            this.OpeningTransition.Interval = 1;
            this.OpeningTransition.Tick += new System.EventHandler(this.OpeningTransitionTick);
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
            this.Name = "MainMenuForm";
            this.Text = "Python Pioneers | Guess The Number";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
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
        private Timer ClosingTime;
        private Timer OpeningTime;
        private Timer OpeningTransition;
        private Label GuidingLabel;
        private Label CountdownLabel;
        private Timer CountdownTimer;
        private Label NumberHolderLabel;
        private Label DifficultyTextLabel;
        private Label DifficultyTypeLabel;
        private Label DifficultyPageLabel;
        private Label RightLabel;
        private Label LeftLabel;
        private Label HardLabel;
        private Label NormalLabel;
        private Label EasyLabel;
        private Label CountingDownLabel;
        private Timer CountingDownTimer;
    }
}

