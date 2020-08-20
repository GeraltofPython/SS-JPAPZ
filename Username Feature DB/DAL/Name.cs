namespace Username_Feature_DB.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Name
    {
        public int ID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(128)]
        public string Name1 { get; set; }
    }
}
