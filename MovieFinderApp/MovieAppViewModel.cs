using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MovieFinder;

namespace MovieFinderApp
{
    class MovieAppViewModel:ViewModelBase
    {
        private Movie _Movie;
        private ObservableCollection<Movie> _Movies;
        private ICommand _RefreshCommand, _DeleteCommand;
        MovieManager movieManager = new MovieManager();
        public Movie Movie
        {
            get
            {
                return _Movie;
            }
            set
            {
                _Movie = value;
                NotifyPropertyChanged("Movie");
            }
        }
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _Movies;
            }
            set
            {
                _Movies = value;
                NotifyPropertyChanged("Movies");
            }
        }

        public Movie SelectedMovie { get; set; }
        public ICommand RefreshCommand
        {
            get
            {
                if (_RefreshCommand == null)
                {
                    _RefreshCommand = new RelayCommand(() => Refresh());
                }
                return _RefreshCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(() => Delete());
                }
                return _DeleteCommand;
            }
        }
        public MovieAppViewModel()
        {
            Movie = new Movie();
            Movies = new ObservableCollection<Movie>();
            Movies.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Movies_CollectionChanged);
        }
        //Whenever new item is added to the collection, am explicitly calling notify property changed  
        void Movies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Movies");
        }
        private void Refresh()
        {
            movieManager.SetRootPath(@"C:\Users\דודיש\Downloads");
            IEnumerable<string> AllMoviesNames = movieManager.FindMovieFileList();
            // List<Movie> items = new List<Movie>();

            foreach (var item in AllMoviesNames)
            { 
                Movies.Add(new Movie() { Name = item, Created = DateTime.Today.Date, Length = "0", PathName = "", Size = 0, Type = " " });
            }

        }

        private void Delete()
        {
            if (movieManager.DeleteMovie(SelectedMovie.Name) == true)
            {
                Movies.Remove(SelectedMovie);
            }

        }
    }
}  
    

