using miniproject.Interfaces;
using miniproject.Models;

namespace miniproject.Repositry
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : class
    {
        private readonly ItiCoursesContext context;
        public GenericRepositry(ItiCoursesContext _context ) {
        
            context= _context;  
        }
        public void Delete(int id)
        {
            context.Set<T>().Remove(GetByID(id));
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            context.Set<T>().RemoveRange(GetAll());
            context.SaveChanges();  
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T GetByName(string name)
        {
            return context.Set<T>().Find(name);
        }

        public T Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
            return entity;
        }
    
    }
}
