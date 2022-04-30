using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTeste
    {
        [Fact]
        public void TestaConexaoComBDMySql()
        {
            //arrange
            var contexto = new ByteBankContexto();
            bool conectado;
            //act

            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception e)
            {

                throw new Exception("Não foi possivel conectar ao banco de dados!");
            }
            //assert
            Assert.True(conectado);
        }
    }
}
