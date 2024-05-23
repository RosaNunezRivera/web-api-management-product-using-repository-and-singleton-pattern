using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Declaring the genetic interface 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {

        // Get All
        Task<IEnumerable<T>> GetAll();

        // Get By Id
        Task<T> GetById(object id);   
        
        // Add
        Task<T> Add(T obj);

        // Update
        Task<T> Update(T obj);

        // Delete
        Task<T> Remove(object id);

        // Save Changes
        Task Save();
    }
}
