using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testtt.Repository.Models
{
    [Table("TipoCombustivel")]
    public partial class TipoCombustivel
    {
        [Key]
        [Column("tipo")]
        [StringLength(100)]
        [Unicode(false)]
        public string Tipo { get; set; } = null!;
    }
}
