using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bionet.Entities
{
    public class Usuario
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Tipo { get; set; }
    public string NumeroIdentificador { get; set; }
    public string Endereco { get; set; } //Classe endereço
    public bool Ativo { get; set; }

    public ICollection<Coleta> ColetaCriadas { get; set; } // One-to-many relationship
    public ICollection<RetiradaColeta> RetiradasRealizadas { get; set; } // One-to-many relationship

    }
}