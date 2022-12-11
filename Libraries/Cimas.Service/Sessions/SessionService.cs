using AutoMapper;
using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Repositories.Sessions.Filter;
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
        private readonly IUnitOfWork _uow;

        public SessionService(
            IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddSessionAsync(AddSessionDescriptor descriptor)
        {
            var film = await _uow.FilmRepository.FindAsync(descriptor.FilmId);
            Session session = new Session()
            {
                FilmId = descriptor.FilmId,
                HallId = descriptor.HallId,
                StartDateTime = descriptor.StartDateTime,
                EndDateTime = descriptor.StartDateTime.AddMinutes(film.Duration),
                TicketPrice = descriptor.TicketPrice
            };

            var hallSeatsList = await _uow.HallSeatRepository.GetAllSeatsByHallId(session.HallId);

            if(hallSeatsList.Count() == 0)
            {
                throw new Exception("Hall doesn't contain any seat.");
            }

            var sessionSeatsList = hallSeatsList
                .Select(s => new SessionSeat() { Row = s.Row, Column = s.Column, Status = SeatStatus.Free, Session = session })
                .ToList();

            _uow.SessionSeatRepository.AddRange(sessionSeatsList);
            await _uow.CompleteAsync();

            return session.Id;
        }

        public async Task DeleteSessionAsync(int sessionId)
        {
            var session = await _uow.SessionRepository.FindAsync(sessionId);
            if (session == null)
            {
                throw new Exception("Session with such Id doesn't exist.");
            }

            _uow.SessionRepository.Remove(session);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId)
        {
            return await _uow.SessionSeatRepository.GetSeatsBySessionIdAsync(sessionId);
        }

        public async Task ChangeSessionSeatsStatusAsync
            (int sessionId, IEnumerable<ChangeSessionSeatStatusDescriptor> descriptors)
        {
            var sessionSeats = await _uow.SessionSeatRepository.GetSeatsBySessionIdAsync(sessionId);

            foreach (var descriptor in descriptors)
            {
                var seat = sessionSeats.FirstOrDefault(seat => seat.Column == descriptor.Column && seat.Row == descriptor.Row);

                if (seat == null)
                {
                    throw new Exception("No seat with such Colomn or Row.");
                }

                seat.Status = descriptor.Status;
            }

            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByRange(SessionsByRangeDescriptor descriptor)
        {
            var filter = new SessionsByRangeFilter()
            {
                From = descriptor.StartDate,
                To = descriptor.StartDate.AddDays(descriptor.days),
            };

            return await _uow.SessionRepository.GetSessionsByRange(filter);
        }
    }
}
