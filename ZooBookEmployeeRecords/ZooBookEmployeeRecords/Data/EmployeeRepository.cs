using ESL.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBookEmployeeRecords.Models;

namespace ZooBookEmployeeRecords.Data
{
    public class EmployeeRepository : Repository<Employee>, IEmployee
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
