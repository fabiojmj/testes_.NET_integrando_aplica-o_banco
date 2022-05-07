using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agendaRepositorio;

        public AgenciaRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _agendaRepositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaObterTodasAgencia()
        {
            //arrange
            //act
            List<Agencia> listaAgencia = _agendaRepositorio.ObterTodos();

            //assert
            Assert.NotNull(listaAgencia);
        }        

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //arrange
            //act
            var agencia = _agendaRepositorio.ObterPorId(1);
            //assert
            Assert.NotNull(agencia);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterAgenciaPorVariosId(int id)
        {
            //arrange
            //act
            var agencia = _agendaRepositorio.ObterPorId(id);
            //assert
            Assert.NotNull(agencia);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //arrange
            //act
            var removido = _agendaRepositorio.Excluir(3);

            //Assert
            Assert.True(removido);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            //arrange
            //act
            //assert
            Assert.Throws<Exception>(
                () => _agendaRepositorio.ObterPorId(33));
        }
    }
}
