using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options)
    }
}
