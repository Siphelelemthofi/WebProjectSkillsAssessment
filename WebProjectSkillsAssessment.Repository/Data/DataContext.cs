using ManagePeopleWithTheirAccounts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using WebProjectSkillsAssessment.Domain.Entities;
using Transaction = WebProjectSkillsAssessment.Domain.Entities.Transaction;

namespace WebProjectSkillsAssessment.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Person>?  UserInformation{get;set;}
        public DbSet<GetAllPersons>? GetAllPersons { get; set; }
        public DbSet<Account> ? UserAccount { get; set; }
        public DbSet<Transaction> ? UserTransaction { get; set; }
        public DbSet<GetTransactionsByAccountCodeOrId> ? GetTransactionsByAccountCodeOrIds { get; set; }
        public DbSet<UpdateUserInformation> ? UpdateUserInformation { get; set; }
        public DbSet<GetPersonDetailsByCode> ? GetPersonDetailsByCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAllIdNumberForPersons>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetAllAccountNumber>().HasNoKey().ToView(null);
        }
    }
}
