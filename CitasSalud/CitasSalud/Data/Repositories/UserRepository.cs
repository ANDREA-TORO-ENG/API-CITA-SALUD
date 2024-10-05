using CitasSalud.Models;
using Dapper;

namespace CitasSalud.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _context;
        public UserRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT * FROM Users";
                return await connection.QueryAsync<User>(query);
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT * FROM Users WHERE IdUser = @IdUser";
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { IdUser = id });
            }
        }

        public async Task<int> Create(User user)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "INSERT INTO Users (UserName, UserLastName, UserPhone, UserEmail, UserDateBirth) VALUES (@UserName, @UserLastName, @UserPhone, @UserEmail, @UserDateBirth); SELECT CAST(SCOPE_IDENTITY() as int)";
                return await connection.QuerySingleAsync<int>(query, user);
            }
        }

        public async Task<int> Update(User user)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UPDATE Users SET UserName = @UserName, UserLastName = @UserLastName, UserPhone=@UserPhone, UserEmail = @UserEmail, UserDateBirth = @UserDateBirth WHERE IdUser = @IdUser";
                return await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "DELETE FROM Users WHERE IdUser = @IdUser";
                return await connection.ExecuteAsync(query, new { IdUser = id });
            }
        }
    }
}
