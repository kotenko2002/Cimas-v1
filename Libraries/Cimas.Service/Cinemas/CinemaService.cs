using Cimas.Entities.Cinemas;
using Cimas.Service.Cinemas.Descriptors;
using Cimas.Storage.Uow;
using Cimas.Сommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Cinemas
{
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _uow;

        public CinemaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddCinemaAsync(AddCinemaDescriptor descriptor)
        {
            var company = await _uow.CompanyRepository.FindAsync(descriptor.CompanyId);
            if(company == null)
            {
                throw new NotFoundException("Company with such Id doesn't exist.");
            }

            var cinema = new Cinema()
            {
                Name = descriptor.Name,
                Adress = descriptor.Adress,
                CompanyId = descriptor.CompanyId
            };

            _uow.CinemaRepository.Add(cinema);
            await _uow.CompleteAsync();

            return cinema.Id;
        }

        public async Task DeleteCinemaAsync(int cinemaId)
        {
            var cinema = await _uow.CinemaRepository.FindAsync(cinemaId);
            if(cinema == null)
            {
                throw new NotFoundException("Cinema with such Id doesn't exist.");
            }

            _uow.CinemaRepository.Remove(cinema);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemasByComnapyIdAsync(int companyId)
        {
            return await _uow.CinemaRepository.GetCinemasByComnapyIdAsync(companyId);
        }
    }
}
