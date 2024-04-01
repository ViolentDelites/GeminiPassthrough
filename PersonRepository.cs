namespace ISB.CLWater.Service.Repositories
{
    public interface IPersonRepository : ICLWaterRepository<Person> // Inherit from the base interface
    {
        Task UpdatePersonAsync(int editUserId, Person person);
    }
    public class PersonRepository : CLWaterRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory<CLWaterContext> contextFactory)
        : base(contextFactory)
        {
        }

        public async Task UpdatePersonAsync(int editUserId, Person person)
        {
            try
            {
                var existingPerson = await _context.TBL_PERSON.FindAsync(person.PERSON_ID);
                if (existingPerson == null)
                {
                    // Handle person not found
                    return;
                }

                // Direct field mappings
                existingPerson.LAST_NAME = person.LAST_NAME;
                existingPerson.FIRST_NAME = person.FIRST_NAME;
                existingPerson.MIDDLE_NAME = person.MIDDLE_NAME ?? "";
                existingPerson.VARSTATUS = person.VARSTATUS ?? "";
                existingPerson.EMAIL_ADDRESS = person.EMAIL_ADDRESS ?? "";
                existingPerson.VARSTATIONED = person.VARSTATIONED ?? "";
                existingPerson.VARWORKED = person.VARWORKED ?? "";
                existingPerson.VARRESIDE = person.VARRESIDE ?? "";
                existingPerson.VARNONE = person.VARNONE ?? "";
                existingPerson.SUFFIX_ID = person.SUFFIX_ID == 0 ? null : person.SUFFIX_ID;
                existingPerson.PRIMARY_PHONE = person.PRIMARY_PHONE;
                existingPerson.ALTERNATE_PHONE = person.ALTERNATE_PHONE.GetValueOrDefault();
                //(Map other fields after looking at front-end)

                // Validation Logic
                if (existingPerson.IS_PRIMARY == true && person.IS_PRIMARY == false)
                {
                    throw new InvalidOperationException("ERROR: Attempt to change primary record to duplicate.");
                }

                if (person.IS_STAGING == true && person.IS_PRIMARY == true)
                {
                    throw new InvalidOperationException("ERROR: Attempt to set record as primary & staged.");
                }

                if (existingPerson.PERSON_ID != null && existingPerson.PERSON_ID != person.PERSON_ID)
                {
                    throw new InvalidOperationException("ERROR: Attempt to change primary id of a duplicate to a new primary id.");
                }

                // Audit fields 
                existingPerson.EDITED_BY = editUserId;
                existingPerson.EDITED_DATE = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the validation errors, e.g., log or return an error response
                Console.WriteLine(ex.Message); // Temporary - replace with your error handling
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
            }
        }

    }
}