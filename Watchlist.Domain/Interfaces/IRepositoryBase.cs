using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Add(T entity);
        Task<bool> IsExist(int id);
    }
}
