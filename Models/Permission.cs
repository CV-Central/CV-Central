using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class Permission{
        /* ------- */
        public int Id {get; set;}

        /* ------ */
        [Required(ErrorMessage = "The Name is required.")]
        [MinLength(1, ErrorMessage = "Name Name must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "Name Name must be at most {1} characters.")]
        public string Name {get; set;}
       
        /* ------ */
        [Required(ErrorMessage = "The name of the guard is required.")]
        [MinLength(1, ErrorMessage = "GuardName Name must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "GuardName Name must be at most {1} characters.")]
        public string GuardName {get; set;}
        
        /* ------ */
        [Required(ErrorMessage = "The date of creation is required.")]
        [DataType(DataType.Date)]
        public DateTime CreateAt {get; set;}
       
        /* ------ */
        [Required(ErrorMessage = "The date of update is required.")]
        [DataType(DataType.Date)]
        public DateTime UpdateAt {get; set;}

        /* ------ */
        public string? Description {get; set;}

        /* ------ */
        [Required(ErrorMessage = "The module is required.")]
        [MinLength(1, ErrorMessage = "Module Name must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "Module Name must be at most {1} characters.")]
        public string Module {get; set;}

    }
}