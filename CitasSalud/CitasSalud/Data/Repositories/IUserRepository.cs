using CitasSalud.Models;

namespace CitasSalud.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
        Task<IEnumerable<User>> GetAll();
    }
}
