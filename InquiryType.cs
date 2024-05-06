namespace ISB.CLWater.Data.Entities;

[Table("LK_INQUIRY_TYPE", Schema = "dbo")]
public partial class InquiryType
{
    [Key]
    public int INQUIRY_TYPE_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? INQUIRY_TYPE_DESC { get; set; }

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }
}