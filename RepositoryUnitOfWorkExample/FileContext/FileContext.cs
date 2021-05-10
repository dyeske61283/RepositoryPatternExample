using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUnitOfWorkExample.FileContext
{
    internal class FileContext : IContext<File>
    {
        private readonly string _directoryPath;

        private bool disposed = false;

        private readonly IEnumerable<File> _files;

        public FileContext(string directoryPath)
        {
            _directoryPath = directoryPath;

            var dir = new DirectoryInfo(directoryPath);

            var files = new List<File>();

            foreach (var file in dir.GetFiles())
            {

                var task = file.OpenText().ReadToEndAsync();
                var content = task.GetAwaiter().GetResult();

                files.Add(new File
                {
                    Path = file.FullName,
                    LastUpdate = file.LastWriteTime,
                    CreateAt = file.CreationTime,
                    Content = content
                });
            }

            _files = files;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Disposing db connection...");
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            foreach (var file in _files)
            {
                WriteChangesToFile(file);
            }
        }

        public ISet<File> Set()
        {
            return new SortedSet<File>(_files);
        }

        private Task WriteChangesToFile(File file)
        {
            file.LastUpdate = DateTime.Now;
            return System.IO.File.WriteAllTextAsync(file.Path, file.Content);
        }
    }
}
