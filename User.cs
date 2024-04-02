namespace ISB.CLWater.Data.Entities;

[Table("TBL_USER", Schema = "dbo")]
[Index("LOGIN_NM", Name = "IX_TBL_USER")]
public partial class User
{
    [Key]
    public int USER_ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FIRST_NM { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LAST_NM { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string LOGIN_NM { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    public bool IS_ADMIN { get; set; }

    public bool IS_VA_USER { get; set; }
}