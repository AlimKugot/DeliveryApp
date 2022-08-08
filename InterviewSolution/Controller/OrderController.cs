using InterviewSolution.Model.Entity;
using InterviewSolution.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            _logger.LogInformation("[{DT}] :: Get All request to {Url}", DateTime.Now, Request.Path.Value);
            List<Order> orders = await _ordersService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            _logger.LogInformation("[{DT}] :: Get request to {Url}", DateTime.Now, Request.Path.Value);
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
            _logger.LogInformation("[{DT}] :: Post request to {Url}", DateTime.Now, Request.Path.Value);
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            _logger.LogInformation("[{DT}] :: Put request to {Url}", DateTime.Now, Request.Path.Value);
            bool updateSuccessful = await _ordersService.UpdateAsync(order);
            if (updateSuccessful)
            {
                return Ok("Update successful.");
            }
            else 
            {
                return BadRequest(order);    
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("[{DT}] :: Delete request to {Url}", DateTime.Now, Request.Path.Value);
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
