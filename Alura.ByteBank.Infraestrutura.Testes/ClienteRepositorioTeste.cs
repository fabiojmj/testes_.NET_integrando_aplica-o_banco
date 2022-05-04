﻿using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteRepositorioTeste()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _clienteRepositorio = provedor.GetService<IClienteRepositorio>();             
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //arrange            
            //act
            List<Cliente> lista = _clienteRepositorio.ObterTodos();
            //assert
            Assert.NotNull(lista);
        }
    }
}
