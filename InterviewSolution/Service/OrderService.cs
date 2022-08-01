using InterviewSolution.Model.Entity;
using InterviewSolution.Model.Repository;

namespace InterviewSolution.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositoryCrudAsync _ordersRepository;

        public OrderService(IOrderRepositoryCrudAsync orderRepository)
        {
            _ordersRepository = orderRepository;
        }

        public Task<bool> CreateAsync(Order entity)
        {
            return _ordersRepository.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(long id)
        {
            return (_ordersRepository.DeleteAsync(id));
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _ordersRepository.GetAllAsync();
        }

        public Task<Order> GetByIdAsync(long id)
        {
            return _ordersRepository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(Order entity)
        {
            return _ordersRepository.UpdateAsync(entity);
        }
    }
}
