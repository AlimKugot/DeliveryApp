using InterviewSolution.Model.Entity;

namespace InterviewSolution.Service
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllAsync();

        public Task<bool> CreateAsync(Order entity);

        public Task<Order> GetByIdAsync(long id);

        public Task<bool> UpdateAsync(Order entity);

        public Task<bool> DeleteAsync(long id);
    }
}
