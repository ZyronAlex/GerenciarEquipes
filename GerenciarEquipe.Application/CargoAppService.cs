using System.Collections.Generic;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class CargoAppService : AppServiceBase<Cargo>, ICargoAppService
    {
        private readonly ICargoService cargoService;
        public CargoAppService(ICargoService cargoService) : base(cargoService)
        {
            this.cargoService = cargoService;
        }

        public ICollection<Cargo> GetAllByLoja(long id_loja)
        {
            return cargoService.GetAllByLoja(id_loja);
        }
    }
}
