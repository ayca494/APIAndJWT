using APIAndJWT.Domain.Entities;

namespace APIAndJWT.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyAPIContext context;
        public UnitOfWork(UdemyAPIContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync(); //Memoryde tutulan tüm işlemlerin veriatbanına yansımasını sağlıyor.
        }
    }
}
