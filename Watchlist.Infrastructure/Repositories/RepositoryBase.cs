using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist.Domain.Interfaces;

namespace Watchlist.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        #region Private Members

        private readonly WatchListDbContext _context;

        #endregion

        #region Constructors
        public RepositoryBase(WatchListDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public async Task Add(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            return entity != null ? true : false;
        }

        #endregion
    }
}
