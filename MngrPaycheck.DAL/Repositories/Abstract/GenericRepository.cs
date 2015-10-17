using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;

namespace MngrPaycheck.DAL.Repositories.Abstract
{
    public class GenericRepository<T>: IRepository<T> where T : class
    {

        private readonly IMngPaycheckContext _context;

        public GenericRepository(IMngPaycheckContext context)
        {
            this._context = context;
        }

        public IMngPaycheckContext Context
        {
            get { return _context; }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Enumerable.ToList(Context.Set<T>());
        }

        public virtual T GetById(Guid Id)
        {
            return Id == Guid.Empty ? null : Context.Set<T>().Find(Id);
        }

        public virtual T Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Context.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
