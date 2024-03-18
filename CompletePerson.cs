namespace ISB.CLWater.Web.Models
{
    public class CompletePerson
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleInitial { get; set; }
        public required string Suffix { get; set; }
        public required string PrimaryPhone { get; set; }
        public required string AlternatePhone { get; set; }
        public int PersonId { get; set; }
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string Address1 { get; set; }
        public required string Address2 { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public required string OtherStateDescription { get; set; }
        public required string AddressNoteDesc { get; set; }
        public required string AddressNoteDate { get; set; }
        public required string RegistrationType { get; set; }
    }
}