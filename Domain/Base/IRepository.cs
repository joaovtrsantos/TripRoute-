namespace Domain.Base
{
    public interface IRepository<T>
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}
