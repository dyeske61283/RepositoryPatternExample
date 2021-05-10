using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryUnitOfWorkExample
{
    interface IFileRepository : IRepository<File>
    {
        IEnumerable<File> GetNewestFiles(int amountOfFiles);
    }
}
