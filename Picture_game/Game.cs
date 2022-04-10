using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Picture_game
{
    public partial class Game : Form
    {
        static int  sec = 0;
        static int min = 0;
        static public int points;
        static string Name;
        static string file_r;
        static int time;
        Random random = new Random();
        Label firstClicked = null;
        Label secondClicked = null;
        List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", ",", ",", "k", "k","a",
        "b", "b", "v", "v", "w", "w", "z", "z","a",
        "c", "c", "q", "q", "e", "e", "r","r","s",
        "x", "x", "i", "i", "M", "M", "L", "L", "s"
        };
        public Game(string name)
        {
            InitializeComponent();
            Form1 form1=new Form1();
            form1.Close();
            Randomize();
            Name = name;
            timer1.Start();
           

        }
        private void Randomize()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            sec = sec + 1;
            if (sec == 60)
            {
                min = min + 1;
                sec = 0;
            }
            label_minute.Text = Convert.ToString(min);
            label_second.Text = Convert.ToString(sec);
        }

        private void label4_Click(object sender, EventArgs e)
        {

            if (timer2.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.White)
                    return;


                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.White;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.White;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    points += 1;
                    label_result.Text = points.ToString();
                    return;


                }
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Ты собрал(а) все картинки,умничка");
            Initialization();
            Close();
            timer1.Stop();
        }
        public static void Initialization ()
        {
            time = min * 60 + sec;
            file_r = Name + "," + points + "," + time;
            string appendText = file_r +"\n";
            File.AppendAllText(@".\..\..\Result\Result.txt",appendText);
            Result result = new Result();
            result.Show();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Result r = new Result();
            Game.Initialization();
            timer1.Stop();
           
        }
    }
}
