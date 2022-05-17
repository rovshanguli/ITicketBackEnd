using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class SeansRepository : Repository<Seans>, ISeansRepository
    {
        public SeansRepository(AppDbContext context) : base(context)
        {

        }
    
    }
}
