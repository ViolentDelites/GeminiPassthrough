using Microsoft.EntityFrameworkCore;

public class PersonService
{
    private readonly CLWaterContext _context;
    private readonly AddressRepository _addressRepository;
    private readonly PersonRepository _personRepository;
    // ... add other repositories as needed (e.g., AddressRepository)

    public PersonService(IDbContextFactory<CLWaterContext> contextFactory)
    {
        _context = contextFactory.CreateDbContext();
        _personRepository = new PersonRepository(contextFactory);
        _addressRepository = new AddressRepository(contextFactory);
        // ... instantiate other repositories
    }

    public async Task UpdatePerson(int editUserId, Person person)
    {
        // ... Potential validation logic ... 

        _context.Attach(person); // Attach for tracking 
        await _context.SaveChangesAsync(); // Save changes from the base repository 
    }

    public async Task UpdateAddress(int editUserId, Address address)
    {
        // ... Potential Validation
        _context.Attach(address);
        await _context.SaveChangesAsync(); // Using base repository functionality 
    }

    public async Task InsertAddress(int editUserId, Address address)
    {
        address.CreatedBy = editUserId;
        await _context.AddOrUpdateAsync(address);  // Directly using the base repository
        await _context.SaveChangesAsync();
    }

}
