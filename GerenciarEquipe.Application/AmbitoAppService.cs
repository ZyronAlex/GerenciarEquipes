using System.Collections.Generic;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class AmbitoAppService : AppServiceBase<Ambito>, IAmbitoAppService
    {
        private readonly IAmbitoService ambitoService;
        public AmbitoAppService(IAmbitoService ambitoService) : base(ambitoService)
        {
            this.ambitoService = ambitoService;
        }

        public ICollection<Ambito> GetByIdCargo(long? id_cargo)
        {
            return ambitoService.GetByIdCargo(id_cargo);
        }

        public ICollection<Ambito> GetByIdMeta(long? id_meta)
        {
            return ambitoService.GetByIdMeta(id_meta);
        }
    }
}
