namespace ISB.CLWater.Data.Entities;

[Table("TBL_COMMENT", Schema = "dbo")]
[Index("PERSON_ID", Name = "IX_TBL_COMMENT")]
public partial class Comment
{
    [Key]
    public int COMMENT_ID { get; set; }

    public int PERSON_ID { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? COMMENT { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }
}