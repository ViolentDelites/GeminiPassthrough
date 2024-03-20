namespace ISB.CLWater.Service.Repositories
{
    public class PersonRepository : CLWaterRepository<Person>
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