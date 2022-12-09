using Cimas.Entities.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Storage.Uow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Halls
{
    public class HallService : IHallService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HallService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddHallAsync(AddHallDescriptor descriptor)
        {
            var hall = new Hall()
            {
                CinemaId = descriptor.CinemaId,
                Name = descriptor.Name
            };

            _unitOfWork.HallRepository.Add(hall);

            List<HallSeat> halls = new List<HallSeat>();
            for (int i = 0; i < descriptor.Rows; i++)
            {
                for (int j = 0; j < descriptor.Coloums; j++)
                {
                    halls.Add(new HallSeat() { Row = i, Column = j, Hall = hall});
                }
            }

            _unitOfWork.HallSeatRepository.AddRange(halls);

            await _unitOfWork.CompleteAsync();
        }
    }
}