using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{    
    public class ClienteRepositorioTeste
    {
        [Fact]
        public void TestaObterTodosClientes()
        {
            //arrange
            var _respositorio = new ClienteRepositorio();
            //act
            List<Cliente> lista = _respositorio.ObterTodos();
            //assert
            Assert.NotNull(lista);
        }
    }
}
