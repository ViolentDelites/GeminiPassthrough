namespace ISB.CLWater.Data.Entities;

[Table("TBL_ProjectUpdate", Schema = "dbo")]
public partial class ProjectUpdate
{
    [Key]
    public long Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Url { get; set; }

    [StringLength(1500)]
    [Unicode(false)]
    public string? Description { get; set; }

    public DateOnly? ArticleDate { get; set; }
}