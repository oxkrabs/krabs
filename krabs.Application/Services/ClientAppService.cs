using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using krabs.Application.Interfaces;
using krabs.Application.ViewModels;
using krabs.Application.ViewModels.ClientsViewModel;
using krabs.Domain.Interfaces;

namespace krabs.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IClientRepository _clientRepository;

        public ClientAppService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public Task<IEnumerable<ClientListViewModel>> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientDetails(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientViewModel client)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<SecretViewModel>> GetSecrets(string clientId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveSecret(RemoveClientSecretViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveSecret(SaveClientSecretViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ClientPropertyViewModel>> GetProperties(string clientId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveProperty(RemovePropertyViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveProperty(SaveClientPropertyViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveClaim(RemoveClientClaimViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveClaim(SaveClientClaimViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(SaveClientViewModel client)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(RemoveClientViewModel client)
        {
            throw new System.NotImplementedException();
        }

        public Task Copy(CopyClientViewModel client)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetClientDefaultDetails(string clientId)
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}