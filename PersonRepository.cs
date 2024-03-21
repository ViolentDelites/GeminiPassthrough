namespace ISB.CLWater.Service.Repositories
{
    public interface IPersonRepository : ICLWaterRepository<Person> // Inherit from the base interface
    {
        // Example specific method
        //Task<Person> GetPersonWithAddress(int personId); 
        // ... Add any other Person-specific methods
    }
    public class PersonRepository : CLWaterRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory<CLWaterContext> contextFactory)
        : base(contextFactory)
        {
        }

        //Possible additional methods:

        //public async Task<Person> GetPersonWithName(int personId)
        //{
        //    return await _context.Set<Person>()
        //        .Include(p => p.FIRST_NAME) // Eager loading for efficiency if address is always needed
        //        .Where(p => p.PERSON_ID == personId)
        //        .FirstOrDefaultAsync();
        //}

        //public async Task<IEnumerable<Person>> FindPeople(Expression<Func<Person, bool>> expression)
        //{
        //    return await _context.Set<Person>()
        //        .Where(expression)
        //        .ToListAsync();
        //}

        //public async Task<bool> DoesPersonExist(int personId)
        //{
        //    return await _context.Set<Person>().AnyAsync(p => p.PERSON_ID == personId);
        //}
    }
}