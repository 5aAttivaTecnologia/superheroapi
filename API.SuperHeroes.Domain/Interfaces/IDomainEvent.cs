using System;

namespace API.SuperHeroes.Domain.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DataOcorrencia { get; }
    }
}
