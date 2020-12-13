using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace schedule_backend.Data
{
    public class TaskApiContext : DbContext
    {
        public TaskApiContext(DbContextOptions<TaskApiContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.TaskText).IsUnicode();
            });
        }
    }
}
