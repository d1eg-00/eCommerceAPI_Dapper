using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.API.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        //Coneccao com db
        private IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = eCommerce; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }

        //aplicando retorno de usuarios

        public List<Usuario> Get()
        {
            return _connection.Query<Usuario>("SELECT * FROM Usuarios").ToList(); //retorna todos usuarios utilizando comandos SQL
        }

        public Usuario ?Get(int id)
        {
            return _connection.QuerySingleOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
            //return _connection.QuerySingleOrDefault<Usuario>("SELECT Id, Nome, Email, Sexo, RG, CPF, NomeMae, SituacaoCadastro, DataCadastro FROM Usuarios WHERE Id = @Id", new { Id = id });
        }

        public void Insert(Usuario usuario)
        {
            
            var ultimoUsuario = _db.LastOrDefault();

            if(ultimoUsuario == null)
            {
                usuario.Id = 1;
            }
            else
            {
                usuario.Id = ultimoUsuario.Id;
                usuario.Id++;
            }
            _db.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
           _db.Remove(_db.FirstOrDefault(a => a.Id == usuario.Id)!);
           _db.Add(usuario);
        }

        public void Delete(int id)
        {
            _db.Remove(_db.FirstOrDefault(a => a.Id == id)!);
        }

        private static List<Usuario> _db = new List<Usuario>() //simulando db 
        {
            new Usuario() {Id=1, Nome="Felipe Rodrigues", Email="felipe.rodrigues@gmail.com"},
            new Usuario() {Id=2, Nome="Marcelo Rodrigues", Email="marcelo.rodrigues@gmail.com"},
            new Usuario() {Id=3, Nome="Jessica Rodrigues", Email="Jessica.rodrigues@gmail.com"},
        };
    }
}