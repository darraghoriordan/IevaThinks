using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IevaThinks.Models
{
    public class IevaThoughtsContext : DbContext
    {
        public IevaThoughtsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<IevaThought> IevaThoughts { get; set; }
    }
    public class IevaThought
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Thought")]
        public string Thought { get; set; }
        [Display(Name = "Created By")]
        public string Username { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Shared On")]
        public DateTime SharedOn { get; set; }
        [Display(Name = "Number of Views")]
        public int ViewCount { get; set; }
    }
}