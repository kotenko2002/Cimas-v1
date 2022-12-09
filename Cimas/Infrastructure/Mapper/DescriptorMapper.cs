using AutoMapper;
using Cimas.Models.Auth;
using Cimas.Models.From;
using Cimas.Service.Authorization.Descriptors;
using Cimas.Service.Cinemas.Descriptors;
using Cimas.Service.Companies.Descriptors;
using Cimas.Service.Films.Descriptors;
using Cimas.Service.Halls.Descriptors;
using Cimas.Service.Sessions.Descriptors;

namespace Cimas.Infrastructure.Mapper
{
    public class DescriptorMapper : Profile
    {
        public DescriptorMapper()
        {
            CreateMap<RegistrationModel, RegistrationDescriptor>();
            CreateMap<LoginModel, LoginDescriptor>();
            CreateMap<AddHallModel, AddHallDescriptor>();
            CreateMap<ChangeSessionSeatsStatusModel, ChangeSessionSeatsStatusDescriptor>();
            CreateMap<AddCompanyModel, AddCompanyDescriptor>();
            CreateMap<AddCinemaModel, AddCinemaDescriptor>();
            CreateMap<AddFilmModel, AddFilmDescriptor>();
        }
    }
}
