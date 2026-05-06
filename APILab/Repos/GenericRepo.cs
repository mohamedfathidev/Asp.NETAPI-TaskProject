using APILab.Models;

namespace APILab.Repos
{
    public class GenericRepo<T>: IGenericRepo<T> where T : class
    {
        protected readonly AppMainContext _context;

        public GenericRepo(AppMainContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public void Edit(T entity) => _context.Set<T>().Attach(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Remove(T entity) => _context.Set<T>().Remove(entity);
        public void Save() => _context.SaveChanges();
    }
}
