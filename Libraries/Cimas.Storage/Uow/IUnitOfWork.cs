using Cimas.Storage.Repositories.Areas;
using Cimas.Storage.Repositories.Companies;
using Cimas.Storage.Repositories.Users;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IAreaRepository Areas { get; }
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
