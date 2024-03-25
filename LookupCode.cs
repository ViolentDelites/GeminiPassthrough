namespace ISB.CLWater.Data.Entities
{
    [Table("LookupCode", Schema = "dbo")]
    public partial class LookupCode
    {
        [StringLength(50)]
        public int Code { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; }
        [StringLength(10)]
        public string? Abbreviation { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set;}
        public DateTime? UpdatedDate { get; set; }

        // ... other relevant properties if needed
    }
}