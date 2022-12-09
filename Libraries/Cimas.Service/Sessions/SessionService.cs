using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Repositories.HallSeats;
using Cimas.Storage.Uow;
using Cimas.Сommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Service.Sessions
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddSessionAsync(AddSessionDescriptor descriptor)
        {
            var film = await _unitOfWork.FilmRepository.FindAsync(descriptor.FilmId);
            Session session = new Session()
            {
                FilmId = descriptor.FilmId,
                HallId = descriptor.HallId,
                StartDateTime = descriptor.StartDateTime,
                EndDateTime = descriptor.StartDateTime.AddMinutes(film.Duration),
                TicketPrice = descriptor.TicketPrice
            };

            var hallSeatsList = await _unitOfWork.HallSeatRepository.GetAllSeatsByHallId(session.HallId);

            if(hallSeatsList.Count() == 0)
            {
                throw new Exception("Hall doesn't contain any seat.");
            }

            var sessionSeatsList = hallSeatsList
                .Select(s => new SessionSeat() { Row = s.Row, Column = s.Column, Status = SeatStatus.Free, Session = session })
                .ToList();

            _unitOfWork.SessionSeatRepository.AddRange(sessionSeatsList);
            await _unitOfWork.CompleteAsync();
        }
    }
}
