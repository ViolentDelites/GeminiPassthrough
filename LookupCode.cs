namespace ISB.CLWater.Data.Entities
{
    [Table("TBL_LOOKUP_CODE", Schema = "dbo")]
    public partial class LookupCode
    {
        [StringLength(100)]
        public string CODE_TYPE { get; set; }
        [StringLength(50)]
        public int ID { get; set; }
        [StringLength(100)]
        public string? NAME { get; set; }
        [StringLength(2000)]
        public string? DESCRIPTION { get; set; }
        [StringLength(10)]
        public string? ABBREVIATION { get; set; }
        public bool? IS_ACTIVE { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? UPDATED_BY { get; set;}
        public DateTime? UPDATED_DATE { get; set; }

        // ... other relevant properties if needed
    }
}