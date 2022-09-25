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
            var directory = Path.Combine(settings.Directory, settings.FileName);
            var file = File.ReadAllBytes(directory);
            
            int current = 0;
            for (int i = 0; i < file.Length; i += settings.MaxFileSize)
            {
                var partBytes = new byte[Math.Min(settings.MaxFileSize, file.Length - i)];
                for (int j = 0; j < partBytes.Length; j++)
                {
                    partBytes[j] = file[current];
                    current++;
                }

                File.WriteAllBytes(Path.Combine(settings.Directory, settings.NamingMethod.Invoke(i)), partBytes);
            }
            
            File.Delete(directory);
        }

        public void Merge(IFileSplittingSettings settings)
        {
            var bytes = new List<byte>();
            var partDirectories = new List<string>();

            for (int i = 0; ; i++)
            {
                var partDirectory = Path.Combine(settings.Directory, settings.NamingMethod.Invoke(i));
                if (File.Exists(partDirectory))
                {
                    bytes.AddRange(File.ReadAllBytes(partDirectory));
                    partDirectories.Add(partDirectory);
                }
                else break;
            }

            var directory = Path.Combine(settings.Directory, settings.FileName);
            File.WriteAllBytes(directory, bytes.ToArray());

            foreach (var partDirectory in partDirectories)
            {
                File.Delete(partDirectory);
            }
        }
    }
}