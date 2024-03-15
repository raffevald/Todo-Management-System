using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Context {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options) : base( options ) { }

        public DbSet<TodoGroup> TodoGroups { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating ( ModelBuilder modelBuilder ) {
            base.OnModelCreating ( modelBuilder );
            modelBuilder.ApplyConfigurationsFromAssembly ( typeof ( ApplicationDbContext ).Assembly );
        }
    }
}
