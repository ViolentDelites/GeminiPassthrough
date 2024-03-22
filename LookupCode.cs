namespace ISB.CLWater.Data.Entities
{
    [Table("LookupCode", Schema = "dbo")]
    public partial class LookupCode
    {
        public int Id { get; set; }
        public string CodeType { get; set; }
        public string Name { get; set; }
        // ... other relevant properties if needed
    }
}