using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridCRUDwithSQLite
{
    public interface IPathProvider
    {
        string GetDatabasePath(string databaseName);
    }
}
