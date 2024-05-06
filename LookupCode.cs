namespace ISB.CLWater.Data.Entities
{
    [Table("LookupCode", Schema = "dbo")]
    public partial class LookupCode
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public required string CODE_TYPE { get; set; }
    
        [StringLength(255)]
        public required string DESCRIPTION { get; set; }

        [StringLength(255)]
        public string? DESCRIPTION_LONG { get; set; }

        public bool? IS_ACTIVE { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? UPDATED_BY { get; set;}
        public DateTime? UPDATED_DATE { get; set; }
    }
}