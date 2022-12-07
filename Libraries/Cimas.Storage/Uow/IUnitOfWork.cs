using Cimas.Storage.Repositories.Cinemas;
using Cimas.Storage.Repositories.Companies;
using Cimas.Storage.Repositories.Users;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ICinemaRepository Cinemas { get; }
        Task CompleteAsync();
    }
}
