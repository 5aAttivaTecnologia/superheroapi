using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core.Infra.Data.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
