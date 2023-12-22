using Mediator.Domains;
using Mediatr.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Data;

public class AppDbContext : IdentityDbContext<UserDetail>
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
    {
        this.Service = services;
    }
    public IServiceProvider Service { get; set; }
    public DbSet<StudentDetails> Students { get; set; }
  /*  public DbSet<UserDetail> Users { get; set; }*/
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Service));
    }
}
    