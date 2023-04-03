namespace miniproject.Interfaces
{
    public interface IGenericRepositry<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        T Insert(T entity);
        T Update(T entity);
        void Delete(int id);
        void DeleteAll();
    }
}
