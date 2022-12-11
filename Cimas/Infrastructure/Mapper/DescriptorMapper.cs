using AutoMapper;
using Cimas.Entities.Users;
using Cimas.Models.Auth;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.Authorization.Descriptors;
using Cimas.Service.Cinemas.Descriptors;
using Cimas.Service.Companies.Descriptors;
using Cimas.Service.Films.Descriptors;
using Cimas.Service.Halls.Descriptors;
using Cimas.Service.Products.Descriptors;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Service.WorkDays.Descriptors;

namespace Cimas.Infrastructure.Mapper
{
    public class DescriptorMapper : Profile
    {
        public DescriptorMapper()
        {
            CreateMap<RegistrationModel, RegistrationDescriptor>();
            CreateMap<LoginModel, LoginDescriptor>();
            CreateMap<AddHallModel, AddHallDescriptor>();
            CreateMap<ChangeSessionSeatStatusModel, ChangeSessionSeatStatusDescriptor>();
            CreateMap<AddCompanyModel, AddCompanyDescriptor>();
            CreateMap<AddCinemaModel, AddCinemaDescriptor>();
            CreateMap<AddFilmModel, AddFilmDescriptor>();
            CreateMap<SessionsByRangeModel, SessionsByRangeDescriptor>();
            CreateMap<AddSessionModel, AddSessionDescriptor>();
            CreateMap<StartWorkDayModel, StartWorkDayDescriptor>();
            CreateMap<AddProductModel, AddProductDescriptor>();
            CreateMap<EditProductModel, EditProductDescriptor>();

            CreateMap<User, GetUserResponse>();
        }
    }
}
