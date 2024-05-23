using ENTITIES.Context;
using ENTITIES.Utility;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        
        // Declaring Context and Generic Entities to permanently save
        // changes from and to database.

        private MPContext _context;

        private DbSet<T> _entity;
        private readonly ILog _log;


        // Paramter-less constructor of GenericRepository to create object
        // of context and entity.
        public GenericRepository(MPContext context)
        {
            //_context = new MPContext();
            _context = context;
            _entity = _context.Set<T>();
            _log = Log.GetInstance();
            _log.LogInformation("Get started with Generic Controller....");
        }

        /// <summary>
        /// Async method to Get all T objects 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {

            _log.LogInformation($"Generic Repositry - Get all T successfully");
            return await _entity.ToListAsync();
 
        }

        /// <summary>
        /// Generic Method to get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<T> GetById(object id)
        {
            _log.LogInformation($"Generic Repositry - GetById "+id);
            return await _entity.FindAsync(id);
        }

        /// <summary>
        /// Async method to add new T objects 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<T> Add(T obj)
        {
            await _entity.AddAsync(obj);
            await Save();
            _log.LogInformation($"Generic Repositry - Add");
            return obj;
        }


        /// <summary>
        /// Asyn method to Update T Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<T> Remove(object id)
        {
            T existingObject = await _entity.FindAsync(id);
           
            if (existingObject != null) 
            {
                _entity.Remove(existingObject);
                _log.LogInformation($"Generic Repositry -  Remove Id "+id);
                await Save();
            }
            return existingObject;
        }

        /// <summary>
        /// Asyn method to Update T Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> Update(T obj)
        {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await Save();
            _log.LogInformation($"Generic Repositry - Update");
            return obj;
        }

        /// <summary>
        /// Method to save changes.
        /// </summary>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}


