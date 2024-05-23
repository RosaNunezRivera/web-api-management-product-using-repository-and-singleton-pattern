using AutoMapper;
using DAL;
using ENTITIES.DTOs;
using ENTITIES.Entities;
using ENTITIES.Utility;

using Microsoft.AspNetCore.Mvc;


namespace WebAPIManagingProductWithRepositoryPattern.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //Independecy injections 
        private readonly IMapper _mapper;
        private readonly IProductDAL _productDAL;
        private readonly IGenericRepository<Product> genericProductRepository;
        private readonly ILog _log;

        public ProductsController(IMapper mapper, IGenericRepository<Product> genericProductRepositor, IProductDAL productDAL) 
        {
            _mapper = mapper;
            _productDAL = productDAL;
            this.genericProductRepository = genericProductRepositor;
            _log = Log.GetInstance();
            _log.LogInformation("Get started with Products Controller....");
        }

        /// <summary>
        /// Get Products Api Endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                //var listproducts = await _productDAL.GetProductsRepository();
                var listProducts = await genericProductRepository.GetAll();
                
                //Converting a list in format of DTO 
                //List<ProductDTO> listproductsDto = _mapper.Map<List<ProductDTO>>(listProducts);

                _log.LogInformation("Get all products successfully using the genericOrderRepository");
                //return Ok(listproductsDto);
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                _log.LogInformation("In Get all products error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        /// <summary>
        /// Implementing 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var prodToFind = await _productDAL.GetProductByIdRepository(id);

                if (prodToFind == null)
                {
                    _log.LogInformation("In GetProductById: Product not found");
                    return BadRequest("Product not found");
                }
                //Convert Productt object in Dto
                ProductDTO productDto = _mapper.Map<ProductDTO>(prodToFind);
                
                _log.LogInformation("Get Product By Id "+id.ToString()+ "using the productDAL repository");
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _log.LogInformation("In GetProductById error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product prod)
        {
            try
            {
                var result = await genericProductRepository.Add(prod);
                if (result == null)
                {
                    _log.LogInformation("In AddProduct: Product not found");
                    return BadRequest(result);
                }
                _log.LogInformation($"Product with Id {prod.ProductID} added successfully using the genericProductRepository");
                return Ok("Product Added Successfully");
            }
            catch (Exception ex)
            {
                _log.LogInformation("In AddProduct error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product prod)
        {
            try
            {
                var result = await genericProductRepository.Update(prod);

                if (result == null)
                {
                    _log.LogInformation("In UpdateProduct: Product not found");
                    return BadRequest(result);
                }

                _log.LogInformation($"Product with Id {prod.ProductID} updated successfully using the genericProductRepository");
                return Ok("Product Updated Successfully");
            }
            catch (Exception ex)
            {
                _log.LogInformation("In UpdateProduct error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            try 
            {
                var result = await genericProductRepository.Remove(id);

                if (result == null)
                {
                    _log.LogInformation("In RemoveProduct: Product not found");
                    return BadRequest(result);
                }

                _log.LogInformation($"Product Id {id} deleted successfully using the genericProductRepository");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.LogInformation("In RemoveProduct error: " + StatusCodes.Status500InternalServerError + " Internal Server Error. Please try again");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please try again");
            }
        }
    }
}
