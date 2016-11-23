namespace FNStore.Domain.Contracts.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void Roolback();
    }
}
