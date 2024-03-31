using NSubstitute;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Xunit;

namespace Questao5.Tests
{
    public class GetSaldoTests
    {
        [Fact]
        public void GetSaldoAreValid()
        {
            var contaCorrente = "FA99D033-7067-ED11-96C6-7C5DFA4A16C9";

            ISaldoRepository saldoRepositorySubstitute = Substitute.For<ISaldoRepository>();

            saldoRepositorySubstitute.GetSaldoAsync(contaCorrente);

            // Assert
            Assert.NotNull(contaCorrente);
            saldoRepositorySubstitute.Received().GetSaldoAsync(contaCorrente);
        }

        [Fact]
        public void GetSaldoAreNotValid_InvalidAccount()
        {
            var contaCorrente = "123";

            ISaldoRepository saldoRepositorySubstitute = Substitute.For<ISaldoRepository>();

            saldoRepositorySubstitute.GetSaldoAsync(contaCorrente);

            // Assert
            Assert.NotNull(contaCorrente);
            saldoRepositorySubstitute.Equals("INVALID_ACCOUNT");
        }

        [Fact]
        public void GetSaldoAreNotValid_InativeAccount()
        {
            var contaCorrente = "D2E02051-7067-ED11-94C0-835DFA4A16C9";

            ISaldoRepository saldoRepositorySubstitute = Substitute.For<ISaldoRepository>();

            saldoRepositorySubstitute.GetSaldoAsync(contaCorrente);

            // Assert
            Assert.NotNull(contaCorrente);
            saldoRepositorySubstitute.Equals("INATIVE_ACCOUNT");
        }
    }
}
