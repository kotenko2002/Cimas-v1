﻿using AutoMapper;
using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Repositories.Sessions.Filter;
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
