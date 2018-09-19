using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Data;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.UoW;
using Template.Domain.Interfaces.UoW;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.UoW
{
    public sealed class UnitOfWorkAutenticacao : IUnitOfWorkAutenticacao
    {
        AutenticacaoContext _db;

        public UnitOfWorkAutenticacao(AutenticacaoContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
