﻿using Cimas.Storage.Repositories.Cinemas;
using Cimas.Storage.Repositories.Companies;
using Cimas.Storage.Repositories.Films;
using Cimas.Storage.Repositories.Halls;
using Cimas.Storage.Repositories.HallSeats;
using Cimas.Storage.Repositories.Products;
using Cimas.Storage.Repositories.Reports;
using Cimas.Storage.Repositories.Sessions;
using Cimas.Storage.Repositories.SessionSeats;
using Cimas.Storage.Repositories.Users;
using Cimas.Storage.Repositories.WorkDays;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IUserRepository UserRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        IFilmRepository FilmRepository { get; }
        IHallRepository HallRepository { get; }
        IHallSeatRepository HallSeatRepository { get; }
        ISessionRepository SessionRepository { get; }
        ISessionSeatRepository SessionSeatRepository { get; }
        IWorkDayRepository WorkDayRepository { get; }
        IProductRepository ProductRepository { get; }
        IReportRepository ReportRepository { get; }
        

        Task CompleteAsync();
    }
}
