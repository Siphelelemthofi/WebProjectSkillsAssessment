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
        public DbSet<Person> ? UserInformation{get;set;}
        public DbSet<Account> ? UserAccount { get; set; }
        public DbSet<Transaction> ? UserTransaction { get; set; }
        public DbSet<GetAllIdNumberForPersons> ? getAllIdNumberForPersons { get; set; }
        public DbSet<GetAllAccountNumber> ? getAllAccountNumbers { get; set; }
        public DbSet<GetTransactionsByAccountCodeOrId> ?  getTransactionsByAccountCodeOrIds { get; set; }
        public DbSet<UpdateUserInformation> ? updateUserInformation { get; set; }
       
    }
}
