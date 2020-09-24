using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Program.Models
{
    public partial class MQContext : DbContext
    {
        public MQContext()
        {
        }

        public MQContext(DbContextOptions<MQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RecievedSms> RecievedSms { get; set; }
        public virtual DbSet<Request> Request { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PRO-05\SQLEXPRESS;Initial Catalog=MQ;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RecievedSms>(entity =>
            {
                entity.ToTable("recieved_sms");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
