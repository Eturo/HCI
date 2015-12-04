using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MovieApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            pictureBox1.Visible = false;
            AdminPage admin = new AdminPage();
            admin.Show();
            //showAllInListBox();
            //MessageBox.Show("List count is:" + listBox1.Items.Count);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        public void showAllInListBox() {
            List<Movie> movies = Util.getAllMovies();
            for(int i = 0; i < movies.Count; i++) {
                listBox1.Items.Add(movies[i]);
            }
            listBox1.EndUpdate();
        }
    }
}
