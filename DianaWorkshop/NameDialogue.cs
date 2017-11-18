using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DianaWorkshop
{
    public partial class NameDialogue : Form
    {
        public NameDialogue()
        {
            InitializeComponent();
        }

        private void NameDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Game.Username == null || Game.Username == "")
            {
                e.Cancel = true;
                return;
            }
            Game.NotifyServer(Game.Username, "has joined the game!", Game.Usercolor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.Username = textBox1.Text;
            Close();
        }

        private void NameDialogue_Load(object sender, EventArgs e)
        {
            
        }

        private void NameDialogue_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}
