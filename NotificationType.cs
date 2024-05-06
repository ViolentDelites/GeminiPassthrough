namespace ISB.CLWater.Data.Entities;

[Table("LK_NOTIFICATION_TYPE", Schema = "dbo")]
public partial class NotificationType
{
    [Key]
    public int NOTIFICATION_TYPE_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NOTIFICATION_TYPE_DESC { get; set; }

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("NOTIFICATION_TYPE")]
    public virtual ICollection<NotificationTracking> TBL_NOTIFICATION_TRACKING { get; set; } = new List<NotificationTracking>();
}