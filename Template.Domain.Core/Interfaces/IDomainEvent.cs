using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core.Domain.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DataOcorrencia { get; }
    }
}
