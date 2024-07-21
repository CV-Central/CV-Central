using System.ComponentModel.DataAnnotations;

namespace CV_Central.DTOs{
    public class userUpdateDTO{
        /* ------ */
        [Required(ErrorMessage = "The Name of the user is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* ------- */
        [Required(ErrorMessage = "The age of the user is required.")]
        [MinLength(1, ErrorMessage = "Age must be at least {1} characters.")]
        [MaxLength(3, ErrorMessage = "Age must be at most {1} characters.")]
        public string Age {get; set;}

        /* ------- */
        [Required(ErrorMessage = "The Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Password must be at most {1} characters.")]
        public string Password {get; set;}

        /* ------- */
        public string? Phone {get; set;}

        /* ------- */
        [Required(ErrorMessage = "The Address is required.")]
        [MinLength(1, ErrorMessage = "Address must be at least {1} characters.")]
        [MaxLength(45, ErrorMessage = "Address must be at most {1} characters.")]
        public string Address {get; set;}

        /* ------- */
        public string? Image {get; set;}

        /* ------- */
        [Required(ErrorMessage = "The date of update is required.")]
        [DataType(DataType.Date)]
        public DateTime UpdateAt {get; set;}
    }
}