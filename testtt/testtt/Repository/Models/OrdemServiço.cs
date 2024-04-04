using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testtt.Repository.Models
{
    [Table("OrdemServiço")]
    public partial class OrdemServiço
    {
        [Key]
        [Column("OrdemID")]
        public int OrdemId { get; set; }
        [Column("MotoristaCPF")]
        public int? MotoristaCpf { get; set; }
        [Column("dataservico", TypeName = "date")]
        public DateTime? Dataservico { get; set; }
        public double? QuantidadeCombustivel { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Servicodesc { get; set; }

        [ForeignKey("MotoristaCpf")]
        [InverseProperty("OrdemServiços")]
        public virtual Motoristum? MotoristaCpfNavigation { get; set; }
    }
}
