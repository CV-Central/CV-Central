using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class Role{
        /* ------- */
        public int Id {get; set;}

        /* ------ */
        [Required(ErrorMessage = "The Name of the role is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* ------- */
        [Required(ErrorMessage = "The GuardName of the role is required.")]
        [MinLength(1, ErrorMessage = "GuardName must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "GuardName must be at most {1} characters.")]
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

    }
}