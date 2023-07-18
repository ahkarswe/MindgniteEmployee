using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindgniteEmployee.Models;

namespace MindgniteEmployee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MindgniteEmployee.Models.MindgniteViewModel>? MindgniteViewModel { get; set; }
    }
}