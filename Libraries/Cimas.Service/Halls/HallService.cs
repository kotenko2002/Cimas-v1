using Cimas.Entities.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Storage.Repositories.Halls.Views;
using Cimas.Storage.Uow;
using Cimas.Сommon.Exceptions;
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
            if(descriptor.Rows == 0 || descriptor.Columns == 0)
            {
                throw new NotFoundException("Count of Rows or Coulms can't be 0");
            }

            var hall = new Hall()
            {
                CinemaId = descriptor.CinemaId,
                Name = descriptor.Name
            };

            _uow.HallRepository.Add(hall);

            List<HallSeat> halls = new List<HallSeat>();
            for (int i = 0; i < descriptor.Rows; i++)
            {
                for (int j = 0; j < descriptor.Columns; j++)
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
                throw new NotFoundException("Hall with such Id doesn't exist.");
            }

            _uow.HallRepository.Remove(hall);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<HallView>> GetHallsByCinemaIdAsync(int cinemaId)
        {
            return await _uow.HallRepository.GetHallsByCinemaIdAsync(cinemaId);
        }
    }
}