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
    }
}
