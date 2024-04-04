using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testtt.Repository.Models
{
    [Table("Posto")]
    public partial class Posto
    {
        [Key]
        public int PostoId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? PostoNome { get; set; }
    }
}
