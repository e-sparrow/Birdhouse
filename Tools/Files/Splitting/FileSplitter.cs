using System;
using System.Collections.Generic;
using System.IO;
using Birdhouse.Tools.Files.Splitting.Interfaces;

namespace Birdhouse.Tools.Files.Splitting
{
    public class FileSplitter : IFileSplitter
    {
        public void Split(IFileSplittingSettings settings)
        {
            var file = File.ReadAllBytes(settings.Path);
            
            int current = 0;
            for (int i = 0; i < file.Length; i += settings.MaxFileSize)
            {
                var min = Math.Min(settings.MaxFileSize, file.Length - i);
                var partBytes = new byte[min];
                for (var j = 0; j < partBytes.Length; j++)
                {
                    partBytes[j] = file[current];
                    current++;
                }

                var destination = Path.Combine(settings.Path, settings.NamingMethod.Invoke(i));
                File.WriteAllBytes(destination, partBytes);
            }
            
            File.Delete(settings.Path);
        }

        public void Merge(IFileSplittingSettings settings)
        {
            var bytes = new List<byte>();
            var partDirectories = new List<string>();

            for (int i = 0; ; i++)
            {
                var partDirectory = Path.Combine(settings.Path, settings.NamingMethod.Invoke(i));
                if (File.Exists(partDirectory))
                {
                    var directoryBytes = File.ReadAllBytes(partDirectory);
                    bytes.AddRange(directoryBytes);
                    partDirectories.Add(partDirectory);
                }
                else break;
            }

            var array = bytes.ToArray();
            File.WriteAllBytes(settings.Path, array);

            foreach (var partDirectory in partDirectories)
            {
                File.Delete(partDirectory);
            }
        }
    }
}