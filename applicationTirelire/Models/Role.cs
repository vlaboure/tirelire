namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]

        public string Email { get; set; }

        [StringLength(30)]
        public string RoleAttribut { get; set; }
    }
}
