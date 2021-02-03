using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieManager movieManager = new MovieManager();
            //movieManager.SetRootPath(@"C:\Users\דודיש\Downloads");
            movieManager.SetRootPath(@"C:\");
            movieManager.FindMovieFileList();
            movieManager.ShowMovieFileList();
        }
    }
}
