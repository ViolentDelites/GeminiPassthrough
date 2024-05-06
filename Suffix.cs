namespace ISB.CLWater.Data.Entities;

[Table("LK_SUFFIX", Schema = "dbo")]
public partial class Suffix
{
    [Key]
    public int SUFFIX_ID { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string SUFFIX_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("SUFFIX")]
    public virtual ICollection<Person> TBL_PERSON { get; set; } = new List<Person>();
}