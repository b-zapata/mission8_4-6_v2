using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mission8_4_6_v2.Models;

public partial class TodosContext : DbContext
{
    public TodosContext() { }
    public TodosContext(DbContextOptions<TodosContext> options) : base(options) { }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Todo> Todos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Todos.sqlite");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.Property(e => e.CategoryId).HasDefaultValue(1);
            entity.Property(e => e.Completed).HasDefaultValue(0);

            entity.HasOne(d => d.Category).WithMany(p => p.Todos).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
