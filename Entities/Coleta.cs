using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bionet.Entities
{
    public class Coleta
    {
        public int ColetaId { get; set; }
        public string TipoColeta { get; set; }
        //Não sei bem o que usar aqui
        public int UsuarioCriadorId { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        
        public Usuario UsuarioCriador { get; set; } // One-to-one relationship
        public ICollection<RetiradaColeta> Retiradas { get; set; } // One-to-many relationship
        
    }
}