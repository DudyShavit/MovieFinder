using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieFinder;

namespace MovieFinderApp
{
    /// <summary>
    /// Interaction logic for MoviesManagerUserControl.xaml
    /// </summary>
    public partial class MoviesManagerUserControl : UserControl
    {
        MovieManager movieManager = new MovieManager();
        IEnumerable<string> AllMoviesNames;
        public MoviesManagerUserControl()
        {
            InitializeComponent();
//            movieManager.SetRootPath(@"C:\Users\דודיש\Downloads");
            movieManager.SetRootPath(@"C:\");

            //listMovies.ItemsSource = (IEnumerable<string>)AllMoviesNames;
        }


        void Button_Click(object sender, RoutedEventArgs e)
        {
            //AllMoviesNames = movieManager.FindMovieFileList();
            List<Movie> items = new List<Movie>();

            foreach (var item in AllMoviesNames)
            {
                items.Add(new Movie() { Name = item, Created = new DateTime(DateTime.Now.Ticks), Length = "0", PathName = "", Size = 0, Type = " " });
            }

           // listMovies.ItemsSource = items;
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //movieManager.SetRootPath(@"C:\");
        }
        
        
    }
}
