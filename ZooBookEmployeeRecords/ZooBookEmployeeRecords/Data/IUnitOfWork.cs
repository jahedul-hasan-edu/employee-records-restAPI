using System;
using System.Collections.Generic;
using System.Text;
using ZooBookEmployeeRecords.Data;

namespace ESL.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
         IEmployee Employee { get; }
        void Save();
    }
}
