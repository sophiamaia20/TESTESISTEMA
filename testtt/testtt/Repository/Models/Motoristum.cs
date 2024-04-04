using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testtt.Repository.Models
{
    public partial class Motoristum
    {
        public Motoristum()
        {
            OrdemServiços = new HashSet<OrdemServiço>();
        }

        [Key]
        [Column("CPF")]
        public int Cpf { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? NomeCompleto { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? CategoriaCarteira { get; set; }

        [InverseProperty("MotoristaCpfNavigation")]
        public virtual ICollection<OrdemServiço> OrdemServiços { get; set; }
    }
}
