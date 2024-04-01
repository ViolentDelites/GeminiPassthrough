namespace ISB.CLWater.Data.Entities;

[Table("TBL_ADDRESS", Schema = "dbo")]
[Index("PERSON_ID", Name = "ADDRESS_STATE_ID")]
[Index("ADDRESS_1", Name = "IX_TBL_ADDRESS")]
[Index("ADDRESS_2", Name = "IX_TBL_ADDRESS_1")]
[Index("OTHER_STATE_DESC", Name = "IX_TBL_ADDRESS_2")]
[Index("CITY", Name = "IX_TBL_ADDRESS_3")]
[Index("STATE_ID", Name = "IX_TBL_ADDRESS_4")]
[Index("COUNTRY_ID", Name = "IX_TBL_ADDRESS_5")]
[Index("IS_CURRENT", "PERSON_ID", "STATE_ID", Name = "_dta_index_TBL_ADDRESS_10_181575685__K9_K2_K10_3_4")]
public partial class Address
{
    [Key]
    public int ADDRESS_ID { get; set; }

    public int PERSON_ID { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string CITY { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string ZIPCODE { get; set; } = null!;

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int? EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EDITED_DATE { get; set; }

    public int? IS_CURRENT { get; set; }

    public int? STATE_ID { get; set; }

    public int? COUNTRY_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ADDRESS_2 { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string? OTHER_STATE_DESC { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ADDRESS_1 { get; set; }

    [ForeignKey("COUNTRY_ID")]
    [InverseProperty("TBL_ADDRESS")]
    public virtual Country? COUNTRY { get; set; }

    [ForeignKey("PERSON_ID")]
    [InverseProperty("TBL_ADDRESS")]
    public virtual Person PERSON { get; set; } = null!;

    [ForeignKey("STATE_ID")]
    [InverseProperty("TBL_ADDRESS")]
    public virtual State? STATE { get; set; }
}