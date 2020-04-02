using DAL.Model;
using System.Threading.Tasks;

namespace BLL.Interface.Login
{
    public interface IUserInteraction
    {
        Task<User> Register(Tourist tourist, LoginData loginData);
        Task<User> SignIn(LoginData loginData);
    }
}
