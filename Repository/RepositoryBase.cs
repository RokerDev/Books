using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BooksContext BooksContext;
        public RepositoryBase(BooksContext booksContext)
        => BooksContext = booksContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
        BooksContext.Set<T>()
        .AsNoTracking() :
        BooksContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges ?
        BooksContext.Set<T>()
        .Where(expression)
        .AsNoTracking() :
        BooksContext.Set<T>()
        .Where(expression);
        public void Create(T entity) => BooksContext.Set<T>().Add(entity);
        public void Update(T entity) => BooksContext.Set<T>().Update(entity);
        public void Delete(T entity) => BooksContext.Set<T>().Remove(entity);
    }

}
