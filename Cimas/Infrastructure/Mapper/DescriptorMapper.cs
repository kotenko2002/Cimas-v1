using AutoMapper;
using Cimas.Entities.Cinemas;
using Cimas.Entities.Films;
using Cimas.Entities.Products;
using Cimas.Entities.Sessions;
using Cimas.Entities.Users;
using Cimas.Entities.WorkDays;
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
using Cimas.Service.WorkDays.Views;
using Cimas.Storage.Repositories.Reports.Views;
using Cimas.Storage.Repositories.Sessions.Views;

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
            CreateMap<EditReportModel, EditReportDescriptor>();

            CreateMap<User, GetUserResponse>();
            CreateMap<Cinema, CinemasResponse>();
            CreateMap<Film, FilmResponse>();
            CreateMap<SessionSeat, SessionSeatResponse>();
            CreateMap<WorkDay, WorkDayReponse>();
            CreateMap<Product, ProductResponse>();

            CreateMap<Storage.Repositories.Sessions.Views.SessionView, SessionResponse>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDateTime.ToString("HH:mm")))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndDateTime.ToString("HH:mm")));

            CreateMap<ShortReportForReviewerView, ShortReportForReviewerResponse>()
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<FullReportView, FullReportResponse>()
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<SessionReportView, SessionReportResponse>()
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime.ToString("dd/MM/yyyy HH:mm")));
            
        }
    }
}
