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
    }
}
