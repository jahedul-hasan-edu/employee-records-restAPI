using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBookEmployeeRecords.Models;

namespace ZooBookEmployeeRecords.Data
{
    public interface IEmployee : IRepository<Employee>
    {
    }
}
