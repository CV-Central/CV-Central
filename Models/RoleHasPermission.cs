using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class RoleHasPermission{
        /* ------- */
        public int? PermissionId {get; set;}

        /* ------- */
        public int? RoleId {get; set;}
    }
}