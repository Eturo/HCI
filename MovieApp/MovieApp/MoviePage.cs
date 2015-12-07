using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApp {

    public partial class MoviePage : Form {
        Movie movie;
        public MoviePage() {
            InitializeComponent();
        }
        public MoviePage(Movie movie) {
            InitializeComponent();
            this.movie = movie;
        }

        private void MoviePage_Load(object sender, EventArgs e) {

        }
    }
}
