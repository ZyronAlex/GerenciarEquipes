using System.Collections.Generic;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class InquiridoAppService : AppServiceBase<Inquirido>, IInquiridoAppService
    {
        private readonly IInquiridoService inquiridoService;
        public InquiridoAppService(IInquiridoService inquiridoService) : base(inquiridoService)
        {
            this.inquiridoService = inquiridoService;
        }

        public ICollection<Inquirido> GetByIdCargo(long? id_cargo)
        {
            return inquiridoService.GetByIdCargo(id_cargo);
        }

        public ICollection<Inquirido> GetByIdMeta(long? id_meta)
        {
            return inquiridoService.GetByIdMeta(id_meta);
        }
    }
}
