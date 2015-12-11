using Firestorm.Domain.Repository.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Repository.Interfaces
{
    public interface ICidadeRepository : IRepositoryBase<Cidade>
    {
        List<Cidade> GetCidade();
    }
}
