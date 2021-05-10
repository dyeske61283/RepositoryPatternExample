using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryUnitOfWorkExample
{
    interface IUnitOfWork : IDisposable
    {
        IFileRepository Files { get; }

        void Complete();
    }
}
