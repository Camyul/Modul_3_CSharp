using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public interface IRepository<T>
        where T: class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
