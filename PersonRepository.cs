namespace ISB.CLWater.Service.Repositories
{
    public interface IPersonRepository : ICLWaterRepository<Person> // Inherit from the base interface
    {
        Task UpdatePersonAsync(int editUserId, Person person);
        Task<Person> RetrievePersonAsync(int personId);
        Task<int> InsertPersonAsync(Person person, int userId);
        Task<bool> IsDuplicateAsync(Person person, Address address);
        Task UpdatePersonRecordAsync(int editUserId, Person person, Address address);
        Task ValidateUserAsync(int editUserId, Person person, Address address, Person compPerson = null, Address compAddress = null);
        Task InsertCollectionForm(Person person, Address address, int userId, Comment comment);
    }
    public class PersonRepository : CLWaterRepository<Person>, IPersonRepository
    {
        private readonly IAddressRepository _addressRepository; 
        private readonly ICommentRepository _commentRepository;

        public PersonRepository(IDbContextFactory<CLWaterContext> contextFactory, IAddressRepository addressRepository, ICommentRepository commentRepository) :base(contextFactory)
        {
            _addressRepository = addressRepository;
            _commentRepository = commentRepository;
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
                existingPerson.COMMENTS = person.COMMENTS ?? "";
                existingPerson.HEAR_ABOUT_US_ID = person.HEAR_ABOUT_US_ID;
                existingPerson.OTHER_HEAR_ABOUT_US_DESC = person.OTHER_HEAR_ABOUT_US_DESC ?? "";
                existingPerson.IS_PRIMARY = person.IS_PRIMARY;
                existingPerson.PRIMARY_ID = person.PRIMARY_ID;
                existingPerson.address_note_id = person.address_note_id;
                existingPerson.address_note_dt = DateTime.Now;

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
                if (existingPerson.IS_STAGING == true && person.IS_STAGING == false)
                {
                    existingPerson.VALIDATE_DATE = DateTime.Now;
                }
                else { existingPerson.IS_STAGING = true; }

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
        public async Task<Person> RetrievePersonAsync(int personId)
        {
            try
            {
                var person = await _context.TBL_PERSON.FirstOrDefaultAsync(p => p.PERSON_ID == personId);

                if (person == null)
                {
                    throw new Exception("Retrieve Person Returned 0 Records");
                }

                return person;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, etc.)
                throw; // Re-throw for now, adjust as needed
            }
        }

        public async Task<int> InsertPersonAsync(Person person, int userId)
        {
            try
            {
                person.EDITED_BY = userId;
                person.EDITED_DATE = DateTime.Now; // Assuming you have such a field

                _context.TBL_PERSON.Add(person);
                await _context.SaveChangesAsync();

                return person.PERSON_ID; // Assuming this is auto-generated
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.) 
                throw;  // Re-throw for now; adjust as needed
            }
        }
        public async Task<bool> IsDuplicateAsync(Person person, Address address)
        {
            try
            {
                var isDuplicate = await _context.TBL_PERSON
                    .Where(p => p.LAST_NAME.ToUpper() == person.LAST_NAME.ToUpper() &&
                                p.FIRST_NAME.ToUpper() == person.FIRST_NAME.ToUpper() &&
                                p.PRIMARY_PHONE == person.PRIMARY_PHONE &&
                                (p.SUFFIX_ID == person.SUFFIX_ID || person.SUFFIX_ID == null) &&
                                p.TBL_ADDRESS.Any(a => a.ADDRESS_1.ToUpper() == address.ADDRESS_1.ToUpper() &&
                                                     a.CITY.ToUpper() == address.CITY.ToUpper() &&
                                                     a.ZIPCODE.ToUpper() == address.ZIPCODE.ToUpper() &&
                                                     a.STATE_ID == address.STATE_ID &&
                                                     a.COUNTRY_ID == address.COUNTRY_ID &&
                                                     (a.ADDRESS_2.ToUpper() == address.ADDRESS_2.ToUpper() || address.ADDRESS_2 == null)))
                    .AnyAsync();

                return isDuplicate;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task UpdatePersonRecordAsync(int editUserId, Person person, Address address)
        {
            try
            {
                // Update Person
                await UpdatePersonAsync(editUserId, person);

                // Address Logic
                var addressCount = await _addressRepository.PersonAddressCountAsync(person.PERSON_ID);

                switch (addressCount)
                {
                    case 1:
                        await _addressRepository.UpdateAddressAsync(editUserId, address);
                        break;
                    case 0:
                        await _addressRepository.InsertAddressAsync(editUserId, address);
                        break;
                    default:
                        throw new Exception("Address Check for user " + person.PERSON_ID + " Failed!");
                }
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task ValidateUserAsync(int editUserId, Person person, Address address, Person compPerson = null, Address compAddress = null)
        {
            try
            {
                await UpdatePersonAsync(editUserId, person);

                if (person.IS_PRIMARY == true)
                {
                    var addressCount = await _addressRepository.PersonAddressCountAsync(person.PERSON_ID);

                    switch (addressCount)
                    {
                        case 1:
                            await _addressRepository.UpdateAddressAsync(editUserId, address);
                            break;
                        case 0:
                            await _addressRepository.InsertAddressAsync(editUserId, address);
                            break;
                        default:
                            throw new Exception("Address Check for user " + person.PERSON_ID + " Failed!");
                    }
                }

                if (compPerson != null && compAddress != null)
                {
                    await UpdatePersonAsync(editUserId, compPerson);

                    var compAddressCount = await _addressRepository.PersonAddressCountAsync(compPerson.PERSON_ID);

                    switch (compAddressCount)
                    {
                        case 1:
                            await _addressRepository.UpdateAddressAsync(editUserId, compAddress);
                            break;
                        case 0:
                            await _addressRepository.InsertAddressAsync(editUserId, compAddress);
                            break;
                        default:
                            throw new Exception("Address Check for user " + compPerson.PERSON_ID + " Failed!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task InsertCollectionForm(Person person, Address address, int userId, Comment comment)
        {
            address.PERSON_ID = await InsertPersonAsync(person, userId);
            _addressRepository.InsertAddressAsync(userId, address); // Delegate to AddressRepository

            if (comment != null)
            {
                comment.PERSON_ID = address.PERSON_ID;
                _commentRepository.InsertCommentAsync(userId, comment); // Delegate to CommentRepository
            }
        }
    }
}