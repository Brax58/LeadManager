
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repository.Context
{
    public class BaseContext<T> where T : class
    {
        protected readonly LeadManagerContext db;

        public BaseContext(LeadManagerContext context) =>
            db = context;

        public virtual void Add(T obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll() =>
            db.Set<T>().ToList();

        public virtual T GetById(int? id) =>
            db.Set<T>().Find(id);

        public virtual void Remove(T obj)
        {
            db.Set<T>().Remove(obj);
            db.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (!_disposed)
            {
                db.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
