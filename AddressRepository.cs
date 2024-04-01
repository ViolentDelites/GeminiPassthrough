namespace ISB.CLWater.Service.Repositories
{
    public interface IAddressRepository : ICLWaterRepository<Address>
    {
    }
    public class AddressRepository : CLWaterRepository<Address>, IAddressRepository
    {
        public AddressRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
    }
}