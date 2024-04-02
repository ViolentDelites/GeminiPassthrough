namespace ISB.CLWater.Service.Repositories
{
    public interface ICommentRepository : ICLWaterRepository<Comment>
    {
        Task InsertCommentAsync(int userId, Comment comment);
    }
    public class CommentRepository : CLWaterRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }

        public async Task InsertCommentAsync(int userId, Comment comment)
        {
            try
            {
                comment.CREATED_BY = userId;
                comment.CREATED_DATE = DateTime.Now; // Assuming you have such a field

                _context.TBL_COMMENT.Add(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }
    }
}