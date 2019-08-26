using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.EntityFramework.Entities;
using krabs.Application.ViewModels.UserViewModels;
using krabs.Infrastructure.Identity.Entities;

namespace krabs.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>(MemberList.Destination);
            CreateMap<ApplicationUser, UserListViewModel>(MemberList.Destination);
        }
    }
}