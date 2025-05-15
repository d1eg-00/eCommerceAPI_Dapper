using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace eCommerce.API.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public ICollection<Usuario> ?Usuarios { get; set; }  //Departamento tem varios usuarios relacionados
    }
}