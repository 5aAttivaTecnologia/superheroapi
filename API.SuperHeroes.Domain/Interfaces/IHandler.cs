﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.SuperHeroes.Domain.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notificar();
        bool ExistemNotificacoes();
        List<T> ObterValores();
    }
}