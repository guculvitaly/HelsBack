using HelsPeople.Model;
using HelsPeople.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.EFRepository
{
    public interface ISearchRepository : IRepositoryBase<Pacient>
    {
        IReadOnlyCollection<Pacient> Search(string query);
    }
}
