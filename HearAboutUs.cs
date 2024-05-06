namespace ISB.CLWater.Data.Entities;

[Table("LK_HEAR_ABOUT_US", Schema = "dbo")]
public partial class HearAboutUs
{
    [Key]
    public int HEAR_ABOUT_US_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string HEAR_ABOUT_US_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("HEAR_ABOUT_US")]
    public virtual ICollection<Person> TBL_PERSON { get; set; } = new List<Person>();
}