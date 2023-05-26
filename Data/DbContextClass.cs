using Microsoft.EntityFrameworkCore;
using SpaceWalk.Models;

namespace SpaceWalk.Data
{
  public class DbContextClass : DbContext
  {
    public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<MainForum> MainForums { get; set; }
    public DbSet<SubForum> SubForums { get; set; }
    public DbSet<Threads> Threads { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserLike> UserLikes { get; set; }
  }
}