namespace APILab.Repos
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Edit(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();  
    }
}
