using Cimas.Storage.Repositories.Areas;
using Cimas.Storage.Repositories.Companies;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IAreaRepository Areas { get; }
        Task CompleteAsync();
    }
}
