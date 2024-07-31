using System.ComponentModel.DataAnnotations;

namespace CV_Central.Models {
    public class Skill{
        /* ------- */
        public int Id {get; set;}

        /* ------ */
        public int? UserId {get; set;}
        
        /* ------ */
        public string? SkillName {get; set;}
        
        /* ------ */
        public string? ProficiencyLevel {get; set;}
       
        /* ------ */
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