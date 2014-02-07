using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsmsWebApplication.Models
{
   
    public class Ism
    {
        public Ism() {
            this.IsmConfiguration = new IsmConfiguration();
        }

        public Ism(IsmConfiguration cfg) {
            this.IsmConfiguration = cfg;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ism")]
        public string IsmText { get; set; }

        public IsmConfiguration IsmConfiguration { get; set; }
        [Display(Name = "Created By")]
        public string Username { get; set; }
        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Shared On")]
        [DataType(DataType.DateTime)]
        public DateTime SharedOn { get; set; }
        [Display(Name = "Number of Views")]
        public int ViewCount { get; set; }
    }
}