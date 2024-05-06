namespace ISB.CLWater.Data.Entities;

[Table("LK_STATE", Schema = "dbo")]
[Index("STATE_DESC", Name = "IX_LK_STATE")]
public partial class State
{
    [Key]
    public int STATE_ID { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string STATE_NAME_LONG { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string STATE_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("STATE")]
    public virtual ICollection<Address> TBL_ADDRESS { get; set; } = new List<Address>();
}