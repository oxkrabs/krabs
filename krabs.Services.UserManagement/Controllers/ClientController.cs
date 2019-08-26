using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using krabs.Application.Interfaces;
using krabs.Application.ViewModels.UserViewModels;
using krabs.Domain.Core.ViewModels;
using krabs.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace krabs.Services.UserManagement.Controllers
{
    [Route("api/[controller]/[action]")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">UserId - user guid</param>
        /// <returns></returns>
        [HttpGet("userId")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _userManageAppService.GetUserAsync(userId);
            return new OkObjectResult(user);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q">Quantity - At least 1 and max 50</param>
        /// <param name="p">Page - For pagination</param>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public async Task<ActionResult<IActionResult>> List([Range(1, 50)] int? q = 10, [Range(1, int.MaxValue)] int? p = 1, string s = null)
        {
            var irs = await _userManageAppService.GetUsers(new PagingViewModel(q ?? 10, p ?? 1, s));
            return new OkObjectResult(irs);
        }
    }
}