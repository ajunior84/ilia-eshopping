using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Interfaces
{
    /// <summary>
    /// Unit of Work interface
    /// </summary>
    public interface IUnitOfWork
    {
        #region "  Methods  "

        Task<int> CommitAsync();
        int Commit();

        #endregion
    }
}
