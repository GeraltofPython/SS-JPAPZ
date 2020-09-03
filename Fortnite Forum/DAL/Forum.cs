namespace Fortnite_Forum.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    //change
    [Table("Forum")]
    public partial class Forum
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public DateTime PostDate { get; set; }

        [Required]
        public string SubjectTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string CategoryID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Category Category { get; set; }
    }
}
