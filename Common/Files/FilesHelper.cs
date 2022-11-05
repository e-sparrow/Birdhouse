using System.IO;

namespace Birdhouse.Common.Files
{
    public static class FilesHelper
    {
        public static void ClearDirectory(string directory)
        {
            var info = new DirectoryInfo(directory);

            var files = info.GetFiles();
            foreach (var file in files)
            {
                file.Delete(); 
            }

            var subdirectories = info.GetDirectories();
            foreach (var subdirectory in subdirectories)
            {
                subdirectory.Delete(true); 
            }
        }
    }
}