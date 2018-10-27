using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RunGame
{
    public partial class background : Form
    {

        bool goleft = false;
        bool goright = false;
        bool jumping = false;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        int playSpeed = 18;
        int backLeft = 8;

        public background()
        {
            InitializeComponent();
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            player.Top += jumpSpeed;

            player.Refresh();

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (goleft && player.Left > 100)
            {
                player.Left -= playSpeed;
            }

            if (goright && player.Left + (player.Width + 100) < this.ClientSize.Width)
            {
                player.Left += playSpeed;
            }

        }
    
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

            if(e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if(e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if(jumping)
            {
                jumping = false;
            }
        }
    }
}
