using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsmsWebApplication.Models
{
    
    public class IsmConfiguration
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Targets Name")]
        public string TargetName { get; set; }
        
        [Display(Name = "Created By")]
        public string Username { get; set; }
        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Base Image Url")]
        [Required]
        public string BaseImageUrl { get; set; }
        [Display(Name = "Bubble Text Input Top")]
        [Required]
        public string BubbleTextInputTop { get; set; }
        [Display(Name = "Bubble Text Input Left")]
        [Required]
        public string BubbleTextInputLeft { get; set; }
        [Display(Name = "Bubble Text Input Width")]
        [Required]
        public string BubbleTextInputWidth { get; set; }
        [Display(Name = "Bubble Text Input Height")]
        [Required]
        public string BubbleTextInputHeight { get; set; }
       
        public virtual ICollection<Ism> Isms { get; set; } 

    }
}