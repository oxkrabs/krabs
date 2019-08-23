using System.Diagnostics;
using System.Threading.Tasks;
using krabs.Application.Interfaces;
using krabs.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace krabs.Services.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientAppService _clientAppService;
        private readonly IUserManageAppService _userManageAppService;

        public ClientController(IClientRepository clientRepository, IClientAppService clientAppService, IUserManageAppService userManageAppService)
        {
            _clientRepository = clientRepository;
            _clientAppService = clientAppService;
            _userManageAppService = userManageAppService;
        }

        public async Task<IActionResult> Get()
        {
            var user = await _userManageAppService.GetUserAsync("9c0b4e2a-4c3f-4205-b48f-960897b73c16");
            return new OkObjectResult(user);
        }
    }
}