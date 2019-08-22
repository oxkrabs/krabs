using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using krabs.Domain.Interfaces;
using krabs.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace krabs.Infrastructure.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public Task<Client> GetClient(string clientId)
        {
            return Db
                .Clients
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims)
                .Include(x => x.Properties)
                .AsNoTracking()
                .Where(x => x.ClientId == clientId)
                .SingleOrDefaultAsync();
        }
    }
}