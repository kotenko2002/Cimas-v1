using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Repositories.Sessions.Views;
using Cimas.Storage.Uow;
using Cimas.Сommon.Enums;
using Cimas.Сommon.Exceptions;
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
                throw new NotFoundException("Session with such Id doesn't exist.");
            }

            //TODO: del all seats
            _uow.SessionRepository.Remove(session);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<IEnumerable<SessionSeat>>> GetSeatsBySessionIdAsync(int sessionId)
        {
            var seats = await _uow.SessionSeatRepository.GetSeatsBySessionIdAsync(sessionId);

            int minColoumnValue = seats.Min(seat => seat.Column);

            List<List<SessionSeat>> result = new List<List<SessionSeat>>();

            foreach (var item in seats)
            {
                if(item.Column == minColoumnValue)
                {
                    result.Add(new List<SessionSeat>());
                }

                result[result.Count - 1].Add(item);
            }

            return result;
        }

        public async Task ChangeSessionSeatsStatusAsync(IEnumerable<ChangeSessionSeatStatusDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var seat = await _uow.SessionSeatRepository.FindAsync(descriptor.Id);
                if (seat == null)
                {
                    throw new Exception("Seat with such id doesn't exists");
                }

                seat.Status = descriptor.Status;
            }

            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<SessionView>> GetSessionsByDateAndHallId(SessionsByRangeDescriptor descriptor)
        {
            var sessions =  await _uow.SessionRepository.GetSessionsByDateAndHallId(descriptor.Date, descriptor.HallId);

            foreach (var session in sessions)
            {
                var film = await _uow.FilmRepository.FindAsync(session.FilmId);

                if(film == null)
                {
                    throw new Exception("Film with such id doesn't exists");
                }

                session.FilmName = film.Name;
            }

            return sessions;
        }
    }
}
