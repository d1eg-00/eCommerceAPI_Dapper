using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Models
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public string ?Email { get; set; }
        public string ?Sexo {get; set;}
        public string ?RG {get; set;}
        public string ?CPF {get; set;}
        public string ?NomeMae {get; set;}
        public string ?SituacaoCadastro {get; set;}

        public DateTimeOffset DataCadastro { get; set; }
        public Contato ?Contato { get; set; } // Relacionamento de um para um > Um usuário te um contato relacionado a ele

        public ICollection<EnderecoEntrega> ?EnderecosEntrega { get; set; } // Usuario pode ter varios enderecos de entrega >> Relacionamento

        public ICollection<Departamento> ?Departamentos { get; set; }
    }
}