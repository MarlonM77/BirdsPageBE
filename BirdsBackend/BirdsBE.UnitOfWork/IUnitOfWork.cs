using BirdsBE.Repository.RepositoryInterface;

namespace BirdsBE.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IAccountRepository Account { get; }
        IBirdRepository Bird { get; }

        void Commit();
        void Dispose();
    }
}
