namespace ISB.CLWater.Service.Repositories
{
    public interface IAddressRepository : ICLWaterRepository<Address>
    {
        Task InsertAddressAsync(int editUserId, Address address);
        Task<Address> RetrieveAddressAsync(int personId);
        Task UpdateAddressAsync(int editUserId, Address address);
        Task<int> PersonAddressCountAsync(int personId);

    }
    public class AddressRepository : CLWaterRepository<Address>, IAddressRepository
    {
        public AddressRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }

        public async Task InsertAddressAsync(int editUserId, Address address)
        {
            try
            {
                address.EDITED_BY = editUserId;
                address.EDITED_DATE = DateTime.Now;

                _context.TBL_ADDRESS.Add(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task<Address> RetrieveAddressAsync(int personId)
        {
            try
            {
                var address = await _context.TBL_ADDRESS.FirstOrDefaultAsync(a => a.PERSON_ID == personId);

                if (address == null)
                {
                    throw new Exception("Retrieve Address Returned 0 Records");
                }

                return address;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task UpdateAddressAsync(int editUserId, Address address)
        {
            try
            {
                var existingAddress = await _context.TBL_ADDRESS.FirstOrDefaultAsync(a => a.PERSON_ID == address.PERSON_ID);

                if (existingAddress == null)
                {
                    // Handle case where the address is not found
                    return;
                }

                // Update fields (adjust as needed)
                existingAddress.CITY = address.CITY;
                existingAddress.ZIPCODE = address.ZIPCODE;
                existingAddress.EDITED_BY = editUserId;
                existingAddress.EDITED_DATE = DateTime.Now;
                existingAddress.STATE_ID = address.STATE_ID;
                existingAddress.COUNTRY_ID = address.COUNTRY_ID;
                existingAddress.ADDRESS_2 = address.ADDRESS_2;
                existingAddress.OTHER_STATE_DESC = address.OTHER_STATE_DESC;
                existingAddress.ADDRESS_1 = address.ADDRESS_1;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }
        public async Task<int> PersonAddressCountAsync(int personId)
        {
            try
            {
                var count = await _context.TBL_ADDRESS.CountAsync(a => a.PERSON_ID == personId && a.IS_CURRENT == 1);

                return count;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }
    }
}