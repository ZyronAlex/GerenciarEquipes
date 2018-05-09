﻿using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly ICargoRepository cargoRepository;
        public CargoService(ICargoRepository cargoRepository) : base(cargoRepository)
        {
            this.cargoRepository = cargoRepository;
        }
    }
}
