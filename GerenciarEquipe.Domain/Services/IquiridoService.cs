using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class InquidoService : ServiceBase<Inquirido>, IInquiridoService
    {
        private readonly IInquiridoRepository inquiridoRepository;
        public InquidoService(IInquiridoRepository inquiridoRepository) : base(inquiridoRepository)
        {
            this.inquiridoRepository = inquiridoRepository;
        }

        public ICollection<Inquirido> GetByIdCargo(long? id_cargo)
        {
            return inquiridoRepository.GetByIdCargo(id_cargo);
        }

        public ICollection<Inquirido> GetByIdMeta(long? id_meta)
        {
            return inquiridoRepository.GetByIdMeta(id_meta);
        }
    }
}
