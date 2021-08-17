
using ESL.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBookEmployeeRecords;
using ZooBookEmployeeRecords.Data;

namespace ESL.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
        }

        public IEmployee Employee { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
