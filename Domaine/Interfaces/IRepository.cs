namespace Domaine.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //Task<T> GetByIdAsync(int key);
        //Task<T> GetAllByIdAsync(int key);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        //Task<T> UpdateAsync(T entity);


    }
}
