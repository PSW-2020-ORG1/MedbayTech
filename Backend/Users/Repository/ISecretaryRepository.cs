using Model.Users;
using Repository;

namespace Backend.Users.Repository
{
    public interface ISecretaryRepository : ICreate<Secretary>, IGetAll<Secretary>
    {
        public Secretary GetByUsername(string username);
    }
}
