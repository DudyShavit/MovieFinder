using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieFinder.Service;

namespace MovieFinder
{
    public class MovieManager
    {
        public MovieManager()
        {
        }
        public IEnumerable<string> FindMovieFileList() 
        {
            return FileSystemService.GetListOfMovies(RootPath).Result;
            
            //return 0;
        }

        public void SetRootPath(string rootPath)
        {
            RootPath = rootPath;
        }

        public void ShowMovieFileList()
        {
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
            int totalMB = 0;
            foreach (var path in FoundMovieNamesList)
            {
                long length = new System.IO.FileInfo(path).Length;
                long lengthMB = (length / 1024) / 1024;
                totalMB += (int)lengthMB;
                var fileName = Path.GetFileName(path);

                if (IsHebrew(fileName) == true)
                {
                    Char[] tempArray = fileName.ToCharArray();
                    Array.Reverse(tempArray);
                    var fileNameRTL = new String(tempArray);
                    Console.Write("MB = {0} | ", lengthMB);
                    Console.WriteLine(fileNameRTL);
                }
                else
                {
                    Console.Write("MB = {0} | ", lengthMB);
                    Console.WriteLine(fileName);
                }
            }
            Console.WriteLine("***********************************");
            Console.WriteLine("TOTAL COUNT OF MB IS: {0}", totalMB);

            
        }
        public bool DeleteMovie(string MoviePath) 
        {
            return FileSystemService.Delete(MoviePath);
        }
        public void ShowMovie() { }
        public string RootPath { get; set; }
        public int NumOfMoviesFound { get; set; }
        public List<Movie> FoundMoviesList { get; set; }
        public IEnumerable<string> FoundMovieNamesList { get; set; }

        //static void IsAnyCharacterRightToLeft(string s)
        //{
        //    for (var i = 0; i < s.Length; i += char.IsSurrogatePair(s, i) ? 2 : 1)
        //    {
        //        var codepoint = char.ConvertToUtf32(s, i);
        //        if (IsRandALCat(codepoint))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public bool IsHebrew(string strCompare)
        {
            char[] chars = strCompare.ToCharArray();
            foreach (char ch in chars)
                if (ch >= '\u0591' && ch <= '\u07FF') return true;
            return false;
        }
    }
}
