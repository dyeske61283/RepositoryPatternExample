using System;

namespace RepositoryUnitOfWorkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var context = new FileContext.FileContext(directory);

            IUnitOfWork unitOfWork = new UnitOfWork(context);

            foreach(var file in unitOfWork.Files.GetAll())
            {
                Console.WriteLine($"{file.Path}");
            }

            unitOfWork.Dispose();
        }
    }
}
