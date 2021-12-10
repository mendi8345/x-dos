using System.Data;
using System.Data.SqlClient;
using Dapper;
using X_dos.Models;

namespace X_dos.Services
{
    public class UserService :BaseRepository, IUserService
    {
        public UserService(IConfiguration configuration) : base(configuration)
        {
            _connectionName = 
                configuration.GetConnectionString("XDos");
        }

        public Task Add(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddAsync(User user)
        {
            user.Date = DateTime.Now;
            var sql = "add_user";
            var p = new
            {
                user.Name,
                user.Email,
                user.Address,
                user.Date
            };
            var result = await WithConnection(c =>
            c.ExecuteAsync(sql, p, commandType: CommandType.StoredProcedure));
                return  result;
            }
        public async Task<User> GetUser(int id)
        {
            var p = new { Id = id};
            var user = await WithConnection(conn =>
                conn.QueryAsync<User>("get_user", p, commandType: CommandType.StoredProcedure));
            return (User)user;
        }
    }
}

