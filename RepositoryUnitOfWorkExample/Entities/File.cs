using System;

namespace RepositoryUnitOfWorkExample
{
    class File : Entity
    {
        public string Path { get; set; }

        public string Content { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime CreateAt { get; set; }

        public File() : base()
        {

        }

        public File(long id): base(id)
        {

        }
    }
}
