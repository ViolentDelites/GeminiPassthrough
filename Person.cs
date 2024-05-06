namespace ISB.CLWater.Data.Entities;

[Table("TBL_PERSON", Schema = "dbo")]
[Index("FIRST_NAME", Name = "IX_TBL_PERSON")]
[Index("LAST_NAME", Name = "IX_TBL_PERSON_1")]
[Index("PRIMARY_PHONE", Name = "IX_TBL_PERSON_2")]
[Index("EMAIL_ADDRESS", Name = "IX_TBL_PERSON_3")]
[Index("VALIDATE_DATE", Name = "IX_TBL_PERSON_4")]
[Index("HEAR_ABOUT_US_ID", Name = "IX_TBL_PERSON_5")]
[Index("address_note_id", Name = "IX_TBL_PERSON_6")]
[Index("IS_PRIMARY", Name = "PERSON_PERSON_ID")]
[Index("PRIMARY_ID", "IS_PRIMARY", "IS_STAGING", "PERSON_ID", "SUFFIX_ID", "REGISTRATION_TYPE_ID", "CREATED_DATE", Name = "_dta_index_TBL_PERSON_10_565577053__K22_K21_K20_K1_K13_K10_K12_2_3_4_14")]
[Index("SUFFIX_ID", "IS_STAGING", "IS_PRIMARY", "PRIMARY_ID", "REGISTRATION_TYPE_ID", Name = "idx_person")]
public partial class Person
{
    [Key]
    public int PERSON_ID { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string LAST_NAME { get; set; } = null!;

    [StringLength(35)]
    [Unicode(false)]
    public string FIRST_NAME { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string? MIDDLE_NAME { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? VARSTATUS { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? EMAIL_ADDRESS { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? VARSTATIONED { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? VARWORKED { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? VARRESIDE { get; set; }

    public int? REGISTRATION_TYPE_ID { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? VARNONE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int? SUFFIX_ID { get; set; }
    public LookupCode? SUFFIX { get; set; }

    [Column(TypeName = "numeric(20, 0)")]
    public decimal? PRIMARY_PHONE { get; set; }

    [Column(TypeName = "numeric(20, 0)")]
    public decimal? ALTERNATE_PHONE { get; set; }

    [Column(TypeName = "text")]
    public string? COMMENTS { get; set; }

    public int? CREATED_BY { get; set; }

    public int? HEAR_ABOUT_US_ID { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string? OTHER_HEAR_ABOUT_US_DESC { get; set; }

    public bool? IS_STAGING { get; set; }

    public bool? IS_PRIMARY { get; set; }

    public int? PRIMARY_ID { get; set; }

    public int? EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EDITED_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VALIDATE_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? address_note_dt { get; set; }

    public int address_note_id { get; set; }

    public bool? SUSPECT_UPDATE { get; set; }

    [ForeignKey("HEAR_ABOUT_US_ID")]
    [InverseProperty("TBL_PERSON")]
    public virtual HearAboutUs? HEAR_ABOUT_US { get; set; }

    [ForeignKey("REGISTRATION_TYPE_ID")]
    [InverseProperty("TBL_PERSON")]
    public virtual RegistrationType? REGISTRATION_TYPE { get; set; }

    //[ForeignKey("SUFFIX_ID")]
    //[InverseProperty("TBL_PERSON")]
    //public virtual Suffix? SUFFIX { get; set; }

    [InverseProperty("PERSON")]
    public virtual ICollection<Address> TBL_ADDRESS { get; set; } = new List<Address>();

    [InverseProperty("PERSON")]
    public virtual ICollection<NotificationTracking> TBL_NOTIFICATION_TRACKING { get; set; } = new List<NotificationTracking>();

    [ForeignKey("address_note_id")]
    [InverseProperty("TBL_PERSON")]
    public virtual AddressNote address_note { get; set; } = null!;
}