using ManagePeopleWithTheirAccounts.Business.PersonBusiness;
using Microsoft.EntityFrameworkCore;
using WebProjectSkillsAssessment.Bussiness.Interface;
//using WebProjectSkillsAssessment.Domain.Manager;
using WebProjectSkillsAssessment.Repository.AccountRepository;
using WebProjectSkillsAssessment.Repository.Data;
using WebProjectSkillsAssessment.Repository.PersonRepository;
using WebProjectSkillsAssessment.Repository.TransactionRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransationRepository, TransactionRepository>();
builder.Services.AddScoped<PersonBusiness>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
