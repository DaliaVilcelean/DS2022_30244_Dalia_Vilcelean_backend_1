using Assignment1.Entities;
using System.Threading.Tasks;

namespace Assignment1.Repositories
{
    public interface IUserRepository:IBaseRepository<User>
    {
      Task<User>  FindByUserNameAndPass(string username, string password);
    }
}
