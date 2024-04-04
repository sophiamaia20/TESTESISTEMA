using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testtt.Repository.Models
{
    [Table("Veiculo")]
    public partial class Veiculo
    {
        [Key]
        public int PlacaVeiculo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? TipoCombustivel { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? NomeVeiculo { get; set; }
    }
}
