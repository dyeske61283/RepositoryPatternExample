using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryUnitOfWorkExample
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly FileContext.FileContext _context;

        public UnitOfWork(FileContext.FileContext context)
        {
            _context = context;
            Files = new FileRepository(_context);
        }

        public IFileRepository Files { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
