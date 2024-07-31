using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class UserHasRole{
        /* ------- */
        public int? RoleId {get; set;}
        
        /* ------- */
        public string? UserType {get; set;}

        /* ------- */
        public int? UserId {get; set;}
    }
}