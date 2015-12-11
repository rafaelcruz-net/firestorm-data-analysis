using Firestorm.Domain.Repository.Interfaces;
using Firestorm.Domain.Service.Base;
using Firestorm.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firestorm.Domain.Service
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
            : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public List<Cidade> GetCidade()
        {
            return this._cidadeRepository.GetCidade();
        }

    }
}
