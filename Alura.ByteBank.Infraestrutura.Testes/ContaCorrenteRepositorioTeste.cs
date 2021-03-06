using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTeste
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteRepositorioTeste()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _contaCorrenteRepositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }
        [Fact]
        public void TestaObterTodosContaCorrente()
        {
            //arrange            
            //act
            List<ContaCorrente> lista = _contaCorrenteRepositorio.ObterTodos();
            //assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            //arrange
            //act
            var contaCorrente = _contaCorrenteRepositorio.ObterPorId(1);
            //assert
            Assert.NotNull(contaCorrente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientePorVariosId(int id)
        {
            //arrange
            //act
            var contaCorrente = _contaCorrenteRepositorio.ObterPorId(id);
            //assert
            Assert.NotNull(contaCorrente);
        }

        [Fact]
        public void TestaAtualizaSaldoDetermindaConta()
        {
            //arrange
            var conta = _contaCorrenteRepositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;
            //act
            var atualizado = _contaCorrenteRepositorio.Atualizar(1, conta);
            //assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInserteContaCorrente()
        {
            //arrange
            var conta = new ContaCorrente
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente
                {
                    Nome = "kent Nelson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancario",
                    Id = 1
                },
                Agencia = new Agencia
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores, 25",
                    Numero = 147
                }
               
            };
            //act
            var retorno = _contaCorrenteRepositorio.Adicionar(conta);
            //assert
            Assert.True(retorno);

        }

        [Fact]
        public void TestaConsultaPix()
        {
            //arrange
            var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
            var pix = new PixDTO() { Chave = guid, Saldo = 10 };
            //act
            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock
                .Setup(x => x.consultaPix(It.IsAny<Guid>()))
                .Returns(pix);

            var mock = pixRepositorioMock.Object;

            var saldo = mock.consultaPix(guid).Saldo;

            //assert
            Assert.Equal(10, saldo);
        }

    }
}
