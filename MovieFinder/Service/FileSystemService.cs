using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Service
{
    public class FileSystemService
    {
        static public async Task<IEnumerable<string>> GetListOfMovies(string rootPath)
        {
            IEnumerable<string> FoundFiles = null;
            await Task.Run(() =>
            {
                

                FoundFiles = GetFiles(rootPath, "*.mp4|*.mk?|*.mpg|*.avi", true);
            });
 
           return FoundFiles;
        }

        static IEnumerable<string> GetFiles(string folder, string filter, bool recursive)
        {
            string[] found = null;
            try
            {
                found = Directory.GetFiles(folder, filter);
            }
            catch { }
            if (found != null)
                foreach (var x in found)
                    yield return x;
            if (recursive)
            {
                found = null;
                try
                {
                    found = Directory.GetDirectories(folder);
                }
                catch { }
                if (found != null)
                    foreach (var x in found)
                        foreach (var y in GetFiles(x, filter, recursive))
                            yield return y;
            }
        }
        static public bool Delete(string path) 
        {
            bool Result = false;
            try
            {
                File.Delete(path);
                Result = true;
            }
            catch (Exception)
            {

                throw;
            }
            
            return Result;
        }
    }
}
