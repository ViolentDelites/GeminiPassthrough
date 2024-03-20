namespace ISB.CLWater.Data.Entities
{
    [Table("spCheckCACLoginNameResult", Schema = "dbo")]
    public partial class CheckCACLoginNameResult
    {
        public bool is_va_user { get; set; }
        public bool is_admin { get; set; }
        public int user_id { get; set; }
        public string first_nm { get; set; } = default!;
        public string last_nm { get; set; } = default!;
    }
}