using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllAsync();

        Task<Director> GetByIdAsync(int id);

        Task<int> Add(Director director);

        Task<Boolean> Update(Director director);

        Task<Boolean> DeleteAsync(int id);
    }
}
