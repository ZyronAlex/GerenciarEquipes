﻿using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class MetaRepository : RepositoryBase<Meta>, IMetaRepository 
    {
    }
}
