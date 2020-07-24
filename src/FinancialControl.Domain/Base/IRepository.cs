namespace FinancialControl.Domain.Base
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}