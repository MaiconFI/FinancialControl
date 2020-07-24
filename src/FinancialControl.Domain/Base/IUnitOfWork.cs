using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Base
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}