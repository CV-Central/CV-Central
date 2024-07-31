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

        /* CLAVE PRIMARIA COMPUESTA */
        /* El metodo "OnModelCreating" es propio del "DbContext" */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* RoleHasPermissions */
            /* Crear una clave primaria compuesta para la entidad "RoleHasPermissions" a partir de PermissionId y RoleId*/
            modelBuilder.Entity<RoleHasPermission>()
                .HasKey(rp => new { rp.PermissionId, rp.RoleId });
            
            /* UserHasPermissions */
            /* Crear una clave primaria compuesta para la entidad "UserHasPermissions" a partir de PermissionId, UserType y UserId*/
            modelBuilder.Entity<UserHasPermission>()
                .HasKey(up => new { up.PermissionId, up.UserType, up.UserId});
            
            /* UserHasRoles */
            /* Crear una clave primaria compuesta para la entidad "UserHasPermissions" a partir de RoleId, UserType y UserId*/
            modelBuilder.Entity<UserHasRole>()
                /*  La combinación de estas dos propiedades(StudentId, CourseId) será la clave primaria de la entidad "StudentCourse". */
                .HasKey(ur => new { ur.RoleId, ur.UserType, ur.UserId});


            base.OnModelCreating(modelBuilder);
        }
       
    }
}