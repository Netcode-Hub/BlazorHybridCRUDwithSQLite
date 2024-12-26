using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridCRUDwithSQLite.Platforms.Android
{
    public class AndroidPathProvider : IPathProvider
    {
        public string GetDatabasePath(string databaseName)
        {
            return Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }
    }
}
