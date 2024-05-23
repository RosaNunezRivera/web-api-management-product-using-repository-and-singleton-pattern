using AutoMapper;
using DAL;
using ENTITIES.Entities;
using ENTITIES.Utility;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIManagingProductWithRepositoryPattern.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //Independecy injections 
        //private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> genericOrderRepository;
        private readonly ILog _log;

        public OrdersController(IGenericRepository<Order> genericOrderRepository)
        {
            this.genericOrderRepository = genericOrderRepository;
            _log = Log.GetInstance();
            _log.LogInformation("Get started with Orders Controller....");
        }

        /// <summary>
        /// Get Orders Api Endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var listOrders = await genericOrderRepository.GetAll();
           
                _log.LogInformation($"Get all orders successfully using the genericOrderRepository");
                return Ok(listOrders);
            }
            catch (Exception ex)
            {
                _log.LogInformation("In Get Orders error: "+StatusCodes.Status500InternalServerError+" Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var orderToFind = await genericOrderRepository.GetById(id);

                if (orderToFind == null)
                {
                    _log.LogInformation("In GetOrderById: Order not found");
                    return BadRequest("Order not found");
                }

                _log.LogInformation($"Get Order By Id {id} successfully using the genericOrderRepository");
                return Ok(orderToFind);
            }
            catch (Exception ex)
            {
                _log.LogInformation("In GetOrderById error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            try
            {
                var result = await genericOrderRepository.Add(order);
           
                if (result == null)
                {
                    _log.LogInformation("In AddOrder: Order not found");
                    return BadRequest("Order not found");
                }

                _log.LogInformation($"Order with Order Id {order.OrderID} added successfully using the genericOrderRepository");
                return Ok("Order Added Successfully");
            }
            catch (Exception ex)
            {
                _log.LogInformation("In AddOrder error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                var result = await genericOrderRepository.Update(order);

                if (result == null)
                {
                    _log.LogInformation("In UpdateOrder: Order not found");
                    return BadRequest(result);
                }

                _log.LogInformation($"Order with Id {order.ProductID} Updated Successfully using the genericOrderRepository");
                return Ok("Order updated successfully ");
            }
            catch (Exception ex)
            {
                _log.LogInformation("In UpdateOrder error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            try
            {
                var result = await genericOrderRepository.Remove(id);

                if (result == null)
                {
                    _log.LogInformation("In RemoveOrder: Order not found");
                    return BadRequest(result);
                }

                _log.LogInformation($"Order Id {id} was deleted successfully using the genericOrderRepository);
                return Ok("Order deleted successfully ");
            }
            catch (Exception ex)
            {
                _log.LogInformation("In RemoveOrder error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }
    }
}
