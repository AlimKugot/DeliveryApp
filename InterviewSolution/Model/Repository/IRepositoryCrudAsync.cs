namespace InterviewSolution.Model.Repository
{
    public interface IRepositoryCrudAsync<T>
    {
        public Task<List<T>> GetAllAsync();

        public Task<bool> CreateAsync(T entity);

        public Task<T> GetByIdAsync(long id);

        public Task<bool> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(long id);

    }
}
