using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Common.DAL.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(Guid Id);

        T Add(T entity);

        T Delete(T entity);


        void Save();
    }
}
