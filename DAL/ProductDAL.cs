using AutoMapper;
using ENTITIES.Context;
using ENTITIES.DTOs;
using ENTITIES.Entities;
using ENTITIES.Utility;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    /// Creating interface 
    /// </summary>
    public interface IProductDAL
    {
        //Task<List<Product>> GetProductsRepository();
        Task<Product> GetProductByIdRepository(int id);
        //Task<string> AddProductRepository(ProductDTO prodDto);
        //Task<string> UpdateProduct(ProductDTO prodDto);
        //Task<string> RemoveProductRepository(int id);
    }

    public class ProductDAL : IProductDAL
    {
        //Dependencies injections
        private readonly IMPContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public ProductDAL(IMPContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
            _log = Log.GetInstance();
            _log.LogInformation("Get started with IProductDAL Controller....");
        }

        /// <summary>
        /// Get all products 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<List<Product>> GetProductsRepository()
        //{
        //    return await _context.Products.ToListAsync();
        //}

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<string> AddProductRepository(ProductDTO prodDto)
        //{
        //    try
        //    {
        //        var prodToAdd = _mapper.Map<Product>(prodDto);

        //        await _context.Products.AddAsync(prodToAdd);
        //        await _context.SaveChangesAsync();
        //        return "Product added suscessfully";

        //    }
        //    catch (DbUpdateException ex)
        //    {

        //        throw new Exception("error occured", ex);
        //    }
           
        //}

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Product> GetProductByIdRepository(int id)
        {
            try
            {
                _log.LogInformation("In ProductDAL GetProductById "+id);
                return await _context.Products.FindAsync(id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("error occured", ex);
            }

        }

        /// <summary>
        /// Update a new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<string> UpdateProduct(ProductDTO prodDto)
        //{
        //    //Finding the Product Id 
        //    var prodToUpdate = await _context.Products.FindAsync(prodDto.ProductID);

        //    if (prodToUpdate == null)
        //    {
        //        return "Product not found";
        //    }

        //    //Implemeting mapper to convert the data to Dto
        //    _mapper.Map(prodDto, prodToUpdate);

        //    await _context.SaveChangesAsync();
        //    return "Product Updated suscessfully";
        //}


        /// <summary>
        /// Remove a producto
        /// /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<string> RemoveProductRepository(int id)
        //{
        //    //Find the product Id to Delete 
        //    var productToDelete = await _context.Products.FindAsync(id);
           
        //    if (productToDelete == null)
        //    {
        //        return "Product was not found";
        //    }
        //    //Deleting 
        //    _context.Products.Remove(productToDelete);

        //    //Save changed 
        //    await _context.SaveChangesAsync();

        //    return "Product was deleted suscessfully";
        //}
    }
}
