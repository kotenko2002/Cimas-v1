using Cimas.Entities.Areas;
using Cimas.Service.Companies.Descriptors;
using Cimas.Storage.Uow;
using System.Threading.Tasks;

namespace Cimas.Service.Areas
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _uow;

        public AreaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddAreaAsync(AreaAddDescriptor descriptor)
        {
            Area company = new Area()
            {
                CompanyId = descriptor.CompanyId,
                Name = descriptor.Name
            };
            _uow.Areas.Add(company);
            await _uow.CompleteAsync();

            return company.Id;
        }
    }
}
