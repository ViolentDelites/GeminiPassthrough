namespace ISB.CLWater.Data.Entities;

[Table("LK_COUNTRY", Schema = "dbo")]
[Index("COUNTRY_DESC", Name = "IX_LK_COUNTRY")]
public partial class Country
{
    [Key]
    public int COUNTRY_ID { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string COUNTRY_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("COUNTRY")]
    public virtual ICollection<Address> TBL_ADDRESS { get; set; } = new List<Address>();
}