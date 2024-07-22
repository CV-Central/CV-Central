using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class WorkExperience{
        /* ------- */
        public int Id {get; set;}

        /* ------- */
        public int? UserId {get; set;}
       
        /* ------- */
        public string? Company {get; set;}
        
        /* ------- */
        public string? Position {get; set;}
        
        /* ------- */
        public DateOnly? StartDate {get; set;}
        
        /* ------- */
        public DateOnly? DateEnd {get; set;}
        
        /* ------- */
        public string? Description {get; set;}
        
        /* ------- */
        public string? Status {get; set;}

        /* ------ */
        [Required(ErrorMessage = "The date of creation is required.")]
        [DataType(DataType.Date)]
        public DateTime CreateAt {get; set;}
       
        /* ------ */
        [Required(ErrorMessage = "The date of update is required.")]
        [DataType(DataType.Date)]
        public DateTime UpdateAt {get; set;}

    }
}