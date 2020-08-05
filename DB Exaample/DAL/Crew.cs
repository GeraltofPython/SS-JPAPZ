namespace DB_Exaample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Crew
    {
        public int ID { get; set; }

        public int AID { get; set; }

        public int MID { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        public virtual Astronaut Astronaut { get; set; }

        public virtual Mission Mission { get; set; }
    }
}
