using Cimas.Entities.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Storage.Uow;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Halls
{
    public class HallService : IHallService
    {
        private readonly IUnitOfWork _uow;
        public HallService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddHallAsync(AddHallDescriptor descriptor)
        {
            var hall = new Hall()
            {
                CinemaId = descriptor.CinemaId,
                Name = descriptor.Name
            };

            _uow.HallRepository.Add(hall);

            List<HallSeat> halls = new List<HallSeat>();
            for (int i = 0; i < descriptor.Rows; i++)
            {
                for (int j = 0; j < descriptor.Coloums; j++)
                {
                    halls.Add(new HallSeat() { Row = i, Column = j, Hall = hall});
                }
            }

            _uow.HallSeatRepository.AddRange(halls);

            await _uow.CompleteAsync();

            return hall.Id;
        }

        public async Task DeleteHallAsync(int hallId)
        {
            var hall = await _uow.HallRepository.FindAsync(hallId);

            if(hall == null)
            {
                throw new Exception("Hall with such Id doesn't exist.");
            }

            _uow.HallRepository.Remove(hall);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int cinemaId)
        {
            return await _uow.HallRepository.GetHallsByCinemaIdAsync(cinemaId);
        }
    }
}