namespace ISB.CLWater.Service.Repositories
{
    public interface IPersonRepository : ICLWaterRepository<Person> // Inherit from the base interface
    {
    }
    public class PersonRepository : CLWaterRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory<CLWaterContext> contextFactory)
        : base(contextFactory)
        {
        }
    }
}