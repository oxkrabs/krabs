using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;

namespace krabs.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClient(string clientId);
    }
}