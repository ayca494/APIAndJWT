using APIAndJWT.Domain.Entities;

namespace APIAndJWT.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly UdemyAPIContext context;
        public BaseRepository(UdemyAPIContext context)
        {
            this.context = context; 
        }
    }
}
