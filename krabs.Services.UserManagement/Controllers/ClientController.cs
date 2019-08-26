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
        
    }
}