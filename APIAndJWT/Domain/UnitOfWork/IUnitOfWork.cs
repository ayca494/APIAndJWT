namespace APIAndJWT.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
