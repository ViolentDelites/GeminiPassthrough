namespace ISB.CLWater.Data.Entities;

[Table("LK_FOLLOW_UP_REASON", Schema = "dbo")]
public partial class FollowUpReason
{
    [Key]
    public int FOLLOW_UP_REASON_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FOLLOW_UP_REASON_DESC { get; set; }

    public bool? IS_ACTIVE { get; set; }

    public int? CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    public int? EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EDITED_DATE { get; set; }
}