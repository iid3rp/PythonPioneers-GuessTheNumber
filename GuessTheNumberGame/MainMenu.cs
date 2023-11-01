using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumberGame
{
    public partial class MainMenuForm : Form
    {
        private static System.Windows.Forms.Timer FadingTimer = new System.Windows.Forms.Timer();
        private int BlackBoxAlpha;

        public MainMenuForm()
        {
            InitializeComponent();
            Thread.Sleep(3000);
        }

        private void MainMenuLoad(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;     
        }


        private void label1_Click(object sender, EventArgs e)
        {
            StartDifficultyForm StartDifficulty = new StartDifficultyForm();
            StartDifficulty.Show();
            this.Hide();
        }

        // Button click event
        private void label2_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Do you wish to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Set the DialogResult to OK and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BlackBox_Click(object sender, EventArgs e)
        {

        }
    }
}
