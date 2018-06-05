using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class AmbitoService : ServiceBase<Ambito>, IAmbitoService
    {
        private readonly IAmbitoRepository ambitoRepository;
        public AmbitoService(IAmbitoRepository ambitoRepository) : base(ambitoRepository)
        {
            this.ambitoRepository = ambitoRepository;
        }

        public ICollection<Ambito> GetByIdCargo(long? id_cargo)
        {
            return ambitoRepository.GetByIdCargo(id_cargo);
        }

        public ICollection<Ambito> GetByIdMeta(long? id_meta)
        {
            return ambitoRepository.GetByIdMeta(id_meta);
        }
    }
}
