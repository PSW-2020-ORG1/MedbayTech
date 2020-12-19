using Model;
using Model.Users;
using Repository;
using System.Linq;

namespace Backend.Users.Repository.MySqlRepository
{
    public class InsurancePolicySqlRepository : MySqlrepository<InsurancePolicy, string>,
        IInsurancePolicyRepository
    {

        public InsurancePolicySqlRepository(MedbayTechDbContext context) : base(context) { }
        public bool ExistsById(string id)
        {
            if (GetAll().FirstOrDefault(i => i.Id.Equals(id)) != null) return true;
            return false;
        }
    }
}
