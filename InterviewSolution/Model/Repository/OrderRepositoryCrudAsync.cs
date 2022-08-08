using InterviewSolution.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace InterviewSolution.Model.Repository
{
    public class OrderRepositoryCrudAsync : IOrderRepositoryCrudAsync
    {
        private readonly DataContext _dbContext;
        private readonly ILogger<OrderRepositoryCrudAsync> _logger;

        public OrderRepositoryCrudAsync(DataContext dbContext, ILogger<OrderRepositoryCrudAsync> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            List<Order> orders = await _dbContext.Orders.ToListAsync();
            _logger.LogInformation("[{DT}] :: Get all found: {OrderCount}", DateTime.Now, orders.Count);
            return orders;
        }


        public async Task<Order> GetByIdAsync(long orderId)
        {
            Order foundOrder = await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == orderId);
            _logger.LogInformation("[{DT}] :: Get by id found: {Order}", DateTime.Now, foundOrder);
            return foundOrder;
        }

        public async Task<bool> CreateAsync(Order orderToCreate)
        {
            try
            {
                await _dbContext.Orders.AddAsync(orderToCreate);
                bool isCreated = await _dbContext.SaveChangesAsync() >= 1;
                _logger.LogInformation("[{DT}] :: Creation status is {Status} for: {Order}", DateTime.Now, isCreated, orderToCreate);
                return isCreated;
            }
            catch (Exception e)
            {
                _logger.LogWarning("[{DT}] :: Creation exception: {Exception}", DateTime.Now, e.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Order orderToUpdate)
        {
            try
            {
                _dbContext.Orders.Update(orderToUpdate);
                bool isSuccess = await _dbContext.SaveChangesAsync() >= 1;
                _logger.LogInformation("[{DT}] :: Update status is {Status} for: {Order}", DateTime.Now, isSuccess, orderToUpdate);
                return isSuccess;
            }
            catch (Exception e)
            {
                _logger.LogWarning("[{DT}] :: Update exception: {Exception}", DateTime.Now, e.ToString());
                return false;
            }
        }



        public async Task<bool> DeleteAsync(long orderId)
        {
            try
            {
                Order order = await GetByIdAsync(orderId);
                _dbContext.Remove(order);
                bool isRemoved = await _dbContext.SaveChangesAsync() >= 1;
                _logger.LogInformation("[INFO] [{DT}] :: Delete status is {Status} for id {id}: {Order}", DateTime.Now, isRemoved, orderId, order);
                return isRemoved;
            }
            catch (Exception e)
            {
                _logger.LogWarning("[WARNING] [{DT}] :: Delete exception for {id}: {Exception}", DateTime.Now, orderId, e.ToString());
                return false;
            }
        }
    }
}
