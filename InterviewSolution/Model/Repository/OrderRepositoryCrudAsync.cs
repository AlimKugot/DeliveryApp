using InterviewSolution.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace InterviewSolution.Model.Repository
{
    public class OrderRepositoryCrudAsync : IOrderRepositoryCrudAsync
    {
        DataContext _dbContext;

        public OrderRepositoryCrudAsync(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }


        public async Task<Order> GetByIdAsync(long orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == orderId);
        }

        public async Task<bool> CreateAsync(Order orderToCreate)
        {
            try
            {
                await _dbContext.Orders.AddAsync(orderToCreate);
                return await _dbContext.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Order orderToUpdate)
        {
            try
            {
                _dbContext.Orders.Update(orderToUpdate);
                return await _dbContext.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> DeleteAsync(long orderId)
        {
            try
            {
                Order order = await GetByIdAsync(orderId);
                _dbContext.Remove(order);
                return await _dbContext.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
