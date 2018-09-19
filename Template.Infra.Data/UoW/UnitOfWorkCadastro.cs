using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.Data.Context;
using Template.Domain.Interfaces.UoW;

namespace Template.Cadastro.Infra.Data.UoW
{
    public sealed class UnitOfWorkCadastro : IUnitOfWorkCadastro
    {
        TemplateContext _db;

        public UnitOfWorkCadastro(TemplateContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
