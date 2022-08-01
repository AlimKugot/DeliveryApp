using InterviewSolution.Model.Entity;
using InterviewSolution.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewSolution.Controller
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersService;

        public OrdersController(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Order> orders = await _ordersService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Order order = await _ordersService.GetByIdAsync(id);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound(id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            bool createSuccessful = await _ordersService.CreateAsync(order);
            if (createSuccessful)
            {
                return Ok("Create successful.");
            }
            else
            {
                return BadRequest(order);
            }
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Order order)
        {
                
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteSuccessful = await _ordersService.DeleteAsync(id);
            if (deleteSuccessful)
            {
                return Ok("Delete successful.");
            } 
            else
            {
                return BadRequest(id);
            }
        }
    }
}
