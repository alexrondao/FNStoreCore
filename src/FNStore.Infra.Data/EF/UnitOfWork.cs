using FNStore.Domain.Contracts.Transaction;

namespace FNStore.Infra.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FNStoreDataContext _context;
        public UnitOfWork(FNStoreDataContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Roolback()
        {
            return;
        }
    }
}
