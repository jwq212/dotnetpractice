namespace eftest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student1
    {
        
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Course { get; set; }

        [StringLength(10)]
        public string Score { get; set; }

        [StringLength(10)]
        public string Age { get; set; }


    }
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
}
