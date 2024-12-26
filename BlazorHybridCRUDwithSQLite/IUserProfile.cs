using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridCRUDwithSQLite
{
    public interface IUserProfile
    {
        void AddProfile(UserProfile profile);
        void UpdateProfile(UserProfile profile);
        UserProfile GetProfile(int id);
        IEnumerable<UserProfile> GetAllProfiles();
        void DeleteProfile(int id);
    }

    public class UserProfileService : IUserProfile
    {
        private SQLiteConnection _dbConnection;
        public UserProfileService(string dbPath)
        {
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<UserProfile>();
        }
        public void AddProfile(UserProfile profile) => _dbConnection.Insert(profile);

        public void DeleteProfile(int id) => _dbConnection.Delete<UserProfile>(id);
        

        public IEnumerable<UserProfile> GetAllProfiles() => _dbConnection.Table<UserProfile>().ToList();

        public UserProfile GetProfile(int id) => _dbConnection.Find<UserProfile>(id);

        public void UpdateProfile(UserProfile profile) => _dbConnection.Update(profile);
    }
}
