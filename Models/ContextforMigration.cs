using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TerminologyDemo.Models;


 public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OurDBContext>
{

public OurDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OurDBContext>();
            optionsBuilder.UseSqlServer("Server=ANJUMATHEW;Database=TerminologyDb;user=sa;password=Experion@123;");

            return new OurDBContext(optionsBuilder.Options);
        }
}