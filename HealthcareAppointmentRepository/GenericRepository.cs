using System.Linq.Expressions;
using HealthcareAppointmentModels;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly HealthcareAppointmentContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(HealthcareAppointmentContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        async Task<IList<T>> IGenericRepository<T>.GetAll(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy, List<string> includes)
        {
            try
            {
                IQueryable<T> query = _db;
                if(expression != null)
                {
                    query = query.Where(expression);
                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query.Include(include);
                    }
                }
                if(orderBy !=null)
                {
                    query = (IQueryable<T>)orderBy(query);
                }

                return await query.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task IGenericRepository<T>.Insert(T entity)
        {
            await _db.AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
        }

        void IGenericRepository<T>.Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }

}
