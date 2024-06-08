namespace crud8;

using Microsoft.EntityFrameworkCore;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 指定在不存在数据库时,自动创建数据库
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}