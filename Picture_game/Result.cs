using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_game
{
    public partial class Result : Form
    {
        public List <Resulting> res;
        public Result()
        {
            InitializeComponent();
            Data_sort();
        }
        private void Data_sort()
        {
            List<Resulting> res = new List<Resulting>();
            string[] file_data = File.ReadAllLines(@".\..\..\Result\Result.txt");
            for (int i = 0; i < file_data.Length; i++)
            {
               string[] result= file_data[i].Split(',');
                res.Add(new Resulting() { Name = result[0], point = Convert.ToInt32(result[1]), time = Convert.ToInt32(result[2]) });                    
            }
            List<Resulting> resultings = res.OrderByDescending(result => result.point).ThenBy(result=>result.time).ToList();
            foreach (Resulting r in resultings)
            {
                dataGridView1.Rows.Add(r.Name, r.point, r.time);
            }
         
        }
    }
}
