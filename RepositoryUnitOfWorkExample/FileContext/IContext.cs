using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUnitOfWorkExample.FileContext
{
    public interface IContext<T> : IDisposable where T : Entity
    {
        public void SaveChanges();

        public ISet<T> Set();
    }
}
