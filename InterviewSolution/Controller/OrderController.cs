using InterviewSolution.Model.Entity;
using InterviewSolution.Service;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSolution.Controller
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _ordersService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService ordersService, ILogger<OrderController> logger)
        {
            _ordersService = ordersService;
            _logger = logger;
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
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            bool isCreateSuccessful = await _ordersService.CreateAsync(order);
            return Ok(isCreateSuccessful);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            bool isUpdateSuccessful = await _ordersService.UpdateAsync(order);
            return Ok(isUpdateSuccessful);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleteSuccessful = await _ordersService.DeleteAsync(id);
            return Ok(isDeleteSuccessful);
        }
    }
}
