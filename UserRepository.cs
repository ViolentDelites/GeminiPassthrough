namespace ISB.CLWater.Service.Repositories
{
    public interface IUserRepository : ICLWaterRepository<User>
    {
    }
    public class UserRepository : CLWaterRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
    }
}