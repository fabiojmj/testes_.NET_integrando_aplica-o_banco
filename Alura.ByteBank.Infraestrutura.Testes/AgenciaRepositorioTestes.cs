using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //arrange
            var agencia = new Agencia
            {
                Nome = "Agencia Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //assert
            Assert.True(adicionado);

        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            //arrange
            var byteBankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = byteBankRepositorioMock.Object;
            //act
            var lista = mock.BuscarAgencias();
            //assert
            byteBankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
