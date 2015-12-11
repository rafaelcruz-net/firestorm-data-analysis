using Firestorm.Domain.Repository.Context;
using Firestorm.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public List<Cidade> GetCidade()
        {
            
            var result = (from x in this.DbSet
                          where x.Estado.UF == "RJ" || x.Estado.UF == "SP"
                          select x);

            return result.ToList();

        }

    }
}
