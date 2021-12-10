using X_dos.Models;

namespace X_dos.Services
{
    public interface IUserService
    {
        Task<int> AddAsync(User user);
    }
}
