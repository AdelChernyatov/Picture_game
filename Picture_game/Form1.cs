using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_game
{
    public partial class Form1 : Form
    {
        public  Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                Game game = new Game(textBox1.Text);
                this.Hide();
                game.Show();
                


            }
            else
            {
                MessageBox.Show("Введите имя!");
            }

        }

        private void btn_rating_Click(object sender, EventArgs e)
        {
            Result res = new Result();
            res.Show();         
        }
      
    }
}
