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

        public async Task<LoginUser?> CheckCACLoginName(string loginName)
        {
            return await _context.TBL_USER
                        .Where(u => u.LOGIN_NM == loginName)
                        .Select(u => new LoginUser
                        {
                            FirstName = u.FIRST_NM,
                            LastName = u.LAST_NM,
                            UserId = u.USER_ID,
                            IsAdmin = u.IS_ADMIN,
                            IsVaUser = u.IS_VA_USER
                        })
                        .FirstOrDefaultAsync();

            // Add logic for adding userinfo to session 
        }
    }
}