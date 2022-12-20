using Cimas.Entities.Films;
using Cimas.Service.Films.Descriptors;
using Cimas.Storage.Uow;
using Cimas.Сommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Films
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _uow;
        public FilmService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<int> AddFilmAsync(AddFilmDescriptor descriptor)
        {
            var company = await _uow.CompanyRepository.FindAsync(descriptor.CompanyId);
            if (company == null)
            {
                throw new NotFoundException("Company with such Id doesn't exist.");
            }

            var film = new Film()
            {
                Name = descriptor.Name,
                Duration = descriptor.Duration,
                CompanyId = descriptor.CompanyId
            };

            _uow.FilmRepository.Add(film);
            await _uow.CompleteAsync();

            return film.Id;
        }

        public async Task DeleteFilmAsync(int filmId)
        {
            var film = await _uow.FilmRepository.FindAsync(filmId);
            if (film == null)
            {
                throw new NotFoundException("Film with such Id doesn't exist.");
            }

            _uow.FilmRepository.Remove(film);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Film>> GetFilmsByComnapyIdAsync(int companyId)
        {
            return await _uow.FilmRepository.GetFilmsByComnapyIdAsync(companyId);
        }
    }
}
