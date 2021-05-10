using RepositoryUnitOfWorkExample.FileContext;
using RepositoryUnitOfWorkExample.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryUnitOfWorkExample
{
    class FileRepository : Repository<File>, IFileRepository
    {
        private readonly FileContext.FileContext _fileContext;

        public FileRepository(FileContext.FileContext context) : base(context)
        {
            _fileContext = context;
        }

        public IEnumerable<File> GetNewestFiles(int amountOfFiles)
        {
            throw new NotImplementedException();
        }
    }
}
