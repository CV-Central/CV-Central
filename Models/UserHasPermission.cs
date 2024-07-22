using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class UserHasPermission{
        /* ------- */
        public int? PermissionId {get; set;}
        
        /* ------- */
        public string? UserType {get; set;}

        /* ------- */
        public int? UserId {get; set;}
    }
}