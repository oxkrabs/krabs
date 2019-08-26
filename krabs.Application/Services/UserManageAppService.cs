using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using krabs.Application.EventSourcedNormalizers;
using krabs.Application.Interfaces;
using krabs.Application.ViewModels;
using krabs.Application.ViewModels.RoleViewModels;
using krabs.Application.ViewModels.UserViewModels;
using krabs.Domain.Core.Bus;
using krabs.Domain.Core.ViewModels;
using krabs.Domain.Interfaces;
using krabs.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace krabs.Application.Services
{
    public class UserManageAppService : IUserManageAppService
    {
        private readonly IMediatorHandler Bus;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserManageAppService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IMediatorHandler bus)
        {
            Bus = bus;
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public Task UpdateProfile(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfilePicture(ProfilePictureViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task ChangePassword(ChangePasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task CreatePassword(SetPasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAccount(RemoveAccountViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPassword(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventHistoryData>> GetHistoryLogs(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetUserDetails(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<UserViewModel>(user);
        }

        public Task UpdateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClaimViewModel>> GetClaims(string userName)
        {
            throw new NotImplementedException();
        }

        public Task SaveClaim(SaveUserClaimViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaim(RemoveUserClaimViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleViewModel>> GetRoles(string userName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRole(RemoveUserRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task SaveRole(SaveUserRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserLoginViewModel>> GetLogins(string userName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLogin(RemoveUserLoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserListViewModel>> GetUsersInRole(string[] role)
        {
            throw new NotImplementedException();
        }

        public Task ResetPassword(AdminChangePasswordViewodel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ListOfUsersViewModel> GetUsers(PagingViewModel paging)
        {
            var users = _userManager
                .Users
                .Skip((paging.Page - 1) * paging.Quantity)
                .Take(paging.Quantity);
            var total = await _userManager.Users.CountAsync();
            return new ListOfUsersViewModel(_mapper.Map<IEnumerable<UserListViewModel>>(users), total);
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}