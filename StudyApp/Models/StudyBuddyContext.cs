using Microsoft.EntityFrameworkCore;
using System;

namespace StudyApp.Models;
public class StudyBuddyContext : DbContext
{
    public DbSet<ProgramOfStudy> StudyBuddy_Programs { get; set; }
    public DbSet<School> StudyBuddy_Schools { get; set; }
    public DbSet<Course> StudyBuddy_Courses { get; set; }
    public DbSet<Hobby> StudyBuddy_Hobbies { get; set; }
    public DbSet<Message> StudyBuddy_Messages { get; set; }
    public DbSet<User> StudyBuddy_Users { get; set; }
    public DbSet<Profile> StudyBuddy_Profiles { get; set; }
    public DbSet<Event> StudyBuddy_Events { get; set; }
    
    // environment variables must be setup on your system with user and password as DBPWD and DBUSER
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? oracleUser = Environment.GetEnvironmentVariable("DBUSER");
        string? oraclePassword = Environment.GetEnvironmentVariable("DBPWD");
        string dataSource = @"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
    }

    /** USAGE:

            Each time we modify the entity classes in our source code, we
            need to "migrate the changes to our DB, it's basically like
            commiting changes so the DB is updated". Each time we modify the
            entity classes of out db, the following commands need to be run...

            dotnet ef migrations add <name>      (makes a new migration file, <name>  has to be PascalCaseLikeThis)
            dotnet ef database update            (then run this one after to apply)
    **/ 

}