using Accounts.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Accounts.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
        {
        }
        public DbSet<Accountss> accounts { get; set; }
        public DbSet<AccountType> accountTypes { get; set; }
        public DbSet<CostCenter> costCenters { get; set; }
        public DbSet<MakeJournalHead>  makeJournalHeads { get; set; }
        public DbSet<MakeJournalBody>  makeJournalBodies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;

            }



            //{
            //    entity.HasOne(d => d.Message).WithMany(p => p.Receiveds)
            //        .HasForeignKey(d => d.MessageId)
            //        .OnDelete(DeleteBehavior.SetNull);
            //});
            //modelBuilder.Entity<CopyTo>(entity =>
            //{
            //    entity.HasOne(d => d.Message).WithMany(p => p.CopyTos)
            //        .HasForeignKey(d => d.MessageId)
            //        .OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}
