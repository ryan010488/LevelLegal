namespace LevelLegal.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {

        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entity);

        void SaveChanges();

        Task SaveChangesAsync();

        void Remove(T entity);

    }
}
