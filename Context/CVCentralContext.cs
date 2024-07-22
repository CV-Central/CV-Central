using Microsoft.EntityFrameworkCore;
using CV_Central.Models;
namespace CV_Central.Context
{
    public class CVCentralContext : DbContext
    {
        public CVCentralContext(DbContextOptions<CVCentralContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<ExternalAuthentication> ExternalAuthentications { get; set; }
        public DbSet<AcademicFormation> AcademicFormation {get; set;}
        public DbSet<ComplementaryCourse> ComplementaryCourses {get; set;}
        public DbSet<Permission> Permissions {get; set;}
        public DbSet<RoleHasPermission> RoleHasPermissions {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<Skill> Skills {get; set;}
        public DbSet<UserHasPermission> UserHasPermissions {get; set;}
        public DbSet<UserHasRole> UserHasRoles {get; set;}
        public DbSet<WorkExperience> WorkExperiences {get; set;}

    }
}