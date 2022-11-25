using AutoMapper;
using Cimas.Models.Auth;
using Cimas.Service.Authorization.Descriptors;

namespace Cimas.Infrastructure.Mapper
{
    public class DescriptorMapper : Profile
    {
        public DescriptorMapper()
        {
            CreateMap<RegistrationModel, RegistrationDescriptor>();
            CreateMap<LoginModel, LoginDescriptor>();
        }
    }
}
