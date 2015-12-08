using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace MovieApp {
    public partial class Form1 : Form {
        Point? clickPosition = null;
        ToolTip tooltip = new ToolTip();
        public Form1() {
            InitializeComponent();
            generateListView1();
            //      this.chart1.MouseClick += new MouseEventHandler(this.chart1_MouseClick);

        }

        private void button1_Click(object sender, EventArgs e) {
            pictureBox1.Visible = false;
            chart1.Visible = true;
            listBox1.Visible = true;
            listView1.Visible = true;
            button3.Visible = true;
            //AdminPage admin = new AdminPage();
            //admin.Show();
            //showAllInListBox();
            //MessageBox.Show("List count is:" + listBox1.Items.Count);

            // Search(gets list of searchedMovies)
            List<Movie> allMovies = Util.getAllMovies("Resources/movies.xml");

            int titleVal = (trackBar1.Value+64);
            char title = Convert.ToChar(titleVal);

            int actorVal = trackBar3.Value+64;
            char actor = Convert.ToChar(actorVal);

            int directorVal = trackBar2.Value+64;
            char director = Convert.ToChar(directorVal);
            List<string> certs = getCerts();

            List<Movie> searchMovies = Util.search(allMovies, title, actor, director);
            List<string> genres = getGenreList();
            //List<Movie> searchedMovies = titleSearch; //just for testing
            List<Movie> searchedMovies = Util.getFinalList(searchMovies, genres,certs);
            // End of Search

            // Generate ScatterPlot

            chart1.ChartAreas[0].AxisX.Minimum = 1920;
            chart1.ChartAreas[0].AxisX.Maximum = 2020;
            chart1.ChartAreas[0].AxisX.Interval = 20;
            clearChart();
            listBox1.Items.Clear();

            int point;
            for (int i=0; i<searchedMovies.Count; i++)
            {
                if (searchedMovies[i].genres[0] == "Action"){
                    point = this.chart1.Series["Action"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Action"].Points[point].ToolTip = searchedMovies[i].title;
                    this.chart1.Series["Action"].Points[point].Name = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Adventure")
                {
                    point = this.chart1.Series["Adventure"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Adventure"].Points[point].ToolTip = searchedMovies[i].title;
                }


                if (searchedMovies[i].genres[0] == "Romance")
                {
                    point = this.chart1.Series["Romance"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Romance"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "War")
                {
                    point = this.chart1.Series["War"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["War"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Drama")
                {
                    point = this.chart1.Series["Drama"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Drama"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Animation")
                {
                    point = this.chart1.Series["Animation"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Animation"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Sci-Fi")
                {
                    point = this.chart1.Series["Sci-Fi"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Sci-Fi"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Western")
                {
                    point = this.chart1.Series["Western"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Western"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Comedy")
                {
                    point = this.chart1.Series["Comedy"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Comedy"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Crime")
                {
                    point = this.chart1.Series["Crime"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Crime"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Mystery")
                {
                    point = this.chart1.Series["Mystery"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Mystery"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Thriller")
                {
                    point = this.chart1.Series["Thriller"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Thriller"].Points[point].ToolTip = searchedMovies[i].title;
                    this.chart1.Series["Thriller"].Points[point].Name = searchedMovies[i].title;
                }
            }
            //End of Generate ScatterPlot

            //Populate ListBox
            for (int i = 0; i < searchedMovies.Count; i++) {
                listBox1.Items.Add(searchedMovies[i]);
            }
            //End of Populate List Box

            //End of Generate ScatterPlot

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

       /* void chart1_MouseClick(object sender, MouseEventArgs e) {
            var pos = e.Location;
            clickPosition = pos;
            var results = this.chart1.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.PlottingArea);
            foreach (var result in results) {
                if (result.ChartElementType == ChartElementType.PlottingArea) {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

            //        var dataPoint = chart1.Series["Action"].Points.FindAllByValue("D");
                }
            }
        }*/

        private List<string> getCerts() {
            List<string> certs = new List<string>();
            if (checkBox1.Checked)
                certs.Add(checkBox1.Text);
            if (checkBox2.Checked)
                certs.Add(checkBox2.Text);
            if (checkBox3.Checked)
                certs.Add(checkBox3.Text);
            if (checkBox4.Checked)
                certs.Add(checkBox4.Text);
            return certs;

        }

        private void button2_Click(object sender, EventArgs e) {
            WatchList wl = new WatchList();
            wl.Show();
        }
        private void generateListView1()
        {
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("Director", 80);
            this.listView1.Columns.Add("Actors", 80);
            this.listView1.Columns.Add("Genres", 80);
            this.listView1.Columns.Add("Rating", 80);
            this.listView1.Columns.Add("Year Made", 80);
            this.listView1.Columns.Add("Length", 80);
            this.listView1.Columns.Add("Certification", 80);
        }

        private void clearChart() {
            //Clear Chart
            if (chart1.Series.Contains(chart1.Series["Action"])) {
                this.chart1.Series["Action"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Adventure"])) {
                this.chart1.Series["Adventure"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Romance"])) {
                this.chart1.Series["Romance"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["War"])) {
                this.chart1.Series["War"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Drama"])) {
                this.chart1.Series["Drama"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Animation"])) {
                this.chart1.Series["Animation"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Western"])) {
                this.chart1.Series["Western"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Comedy"])) {
                this.chart1.Series["Comedy"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Thriller"])) {
                this.chart1.Series["Thriller"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Crime"])) {
                this.chart1.Series["Crime"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Mystery"])) {
                this.chart1.Series["Mystery"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Sci-Fi"])) {
                this.chart1.Series["Sci-Fi"].Points.Clear();
            }
            //End of clear chart
        }

        private List<string> getGenreList(){
            List<string> genres = new List<string>();
            if(checkBox5.Checked){
                genres.Add(checkBox5.Text);
            }
            if(checkBox6.Checked){
                genres.Add(checkBox6.Text);
            }
            if(checkBox7.Checked){
                genres.Add(checkBox7.Text);
            }
            if(checkBox8.Checked){
                genres.Add(checkBox8.Text);
            }
            if(checkBox9.Checked){
                genres.Add(checkBox9.Text);
            }
            if(checkBox10.Checked){
                genres.Add(checkBox10.Text);
            }
            if(checkBox11.Checked){
                genres.Add(checkBox11.Text);
            }
            if(checkBox12.Checked){
                genres.Add(checkBox12.Text);
            }
            if(checkBox13.Checked){
                genres.Add(checkBox13.Text);
            }
            if(checkBox14.Checked){
                genres.Add(checkBox14.Text);
            }
            if(checkBox17.Checked){
                genres.Add(checkBox17.Text);
            }
            if(checkBox16.Checked){
                genres.Add(checkBox16.Text);
            }
            return genres;
        }


        
        
        
        




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Movie sm = (Movie)listBox1.SelectedItem;
            var item = new ListViewItem(new [] { sm.director, sm.actors[0], sm.genres[0], sm.rating, sm.year, sm.length, sm.certification });
            listView1.Items.Clear();
            listView1.Items.Add(item);
            for(int i =1; i< sm.genres.Count;i++){
                listView1.Items.Add(new ListViewItem(new[] { "", "", sm.genres[i],"","","",""}));
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Movie sm = (Movie)listBox1.SelectedItem;
            MoviePage mp = new MoviePage(sm);
            mp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add (Movie)listBox1.SelectedItem to watchlist.xml
            XElement xml = XElement.Load("Resources/watchlist.xml");
            xml.Add(new XElement("movie",
            new XElement("title", ),
            new XElement("FirstName", firstName),
            new XElement("LastName", lastName),
            new XElement("Location", location)));
            xml.Save(fileLocation);

        }
    }
}
