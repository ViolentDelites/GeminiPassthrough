namespace ISB.CLWater.Data.Entities;

[Table("TBL_NOTIFICATION_TRACKING", Schema = "dbo")]
public partial class NotificationTracking
{
    [Key]
    public int NOTIFICATION_TRACKING_ID { get; set; }

    public int NOTIFICATION_TYPE_ID { get; set; }

    public int PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DATE_SENT { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EDITED_DATE { get; set; }

    public int? EDITED_BY { get; set; }

    [ForeignKey("NOTIFICATION_TYPE_ID")]
    [InverseProperty("TBL_NOTIFICATION_TRACKING")]
    public virtual NotificationType NOTIFICATION_TYPE { get; set; } = null!;

    [ForeignKey("PERSON_ID")]
    [InverseProperty("TBL_NOTIFICATION_TRACKING")]
    public virtual Person PERSON { get; set; } = null!;
}