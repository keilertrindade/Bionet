using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Bionet.Entities
{
    //[Index(nameof(ColetaId), nameof(UsuarioRecolhedor), IsUnique = true)]
    public class RetiradaColeta
    {

        public int Id { get; set; }
        public int ColetaId { get; set; }
        public int UsuarioRecolhedorId { get; set; }
        public DateTime DataRetirada { get; set; }
        public string Status { get; set; } // Enum for status (e.g., Pendente, Confirmado, Cancelado)
        
        public Coleta Coleta { get; set; } // One-to-one relationship
        public Usuario UsuarioRecolhedor { get; set; } // One-to-one relationship
    }
}