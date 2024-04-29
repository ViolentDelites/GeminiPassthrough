namespace ISB.CLWater.Service.Repositories
{
    public interface IUserRepository : ICLWaterRepository<User>
    {
    }
    public class UserRepository : CLWaterRepository<User>, IUserRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public UserRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        
    }
}