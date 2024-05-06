namespace ISB.CLWater.Data.Entities;

[Table("LK_REGISTRATION_TYPE", Schema = "dbo")]
public partial class RegistrationType
{
    [Key]
    public int REGISTRATION_TYPE_ID { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string REGISTRATION_TYPE_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("REGISTRATION_TYPE")]
    public virtual ICollection<Person> TBL_PERSON { get; set; } = new List<Person>();
}