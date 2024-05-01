namespace ISB.CLWater.Data.Entities;

[Table("TBL_INQUIRY", Schema = "dbo")]
public partial class Inquiry
{
    [Key]
    public int INQUIRY_ID { get; set; }

    public int INQUIRY_TYPE_ID { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(1500)]
    [Unicode(false)]
    public string? COMMENTS { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int? EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EDITED_DATE { get; set; }
}