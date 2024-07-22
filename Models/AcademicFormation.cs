using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class AcademicFormation{
        /* ------- */
        public int Id {get; set;}

        /* ------- */
        public int? UserId {get; set;}

        /* ------- */
        public string? Institution {get; set;}

        /* ------- */
        public string? Title {get; set;}
        
        /* ------- */
        public DateOnly? StartDate {get; set;}
      
        /* ------- */
        public DateOnly? DateEnd {get; set;}
        
        /* ------- */
        public string? Description {get; set;}
       
        /* ------- */
        public string? Status {get; set;}
        
        /* ------- */
        [Required(ErrorMessage = "The date of creation is required.")]
        [DataType(DataType.Date)]
        public DateTime CreateAt {get; set;}
        
        /* ------- */
        [Required(ErrorMessage = "The date of update is required.")]
        [DataType(DataType.Date)]
        public DateTime UpdateAt {get; set;}
    }
}