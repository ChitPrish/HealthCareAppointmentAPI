using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointmentRepository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy = null,
            List<string>? includes = null
            );

        Task Insert(T entity);

        void Update(T entity);

    }
}
