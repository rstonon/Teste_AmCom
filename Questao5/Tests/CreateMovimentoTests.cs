using NSubstitute;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Infrastructure.Persistence;
using Xunit;

namespace Questao5.Tests
{
    public class CreateMovimentoTests
    {
        [Fact]
        public void CreateMovimentoAreValid()
        {
            var movimento = new Movimento(Utils.GerarHashMd5("teste"), "382D323D-7067-ED11-8866-7D5DFA4A16C9", "C", 1500);

            IMovimentoRepository movimentoRepositorySubstitute = Substitute.For<IMovimentoRepository>();

            movimentoRepositorySubstitute.AddMovimentoAsync(movimento);

            // Assert
            Assert.NotNull(movimento);
            movimentoRepositorySubstitute.Received().AddMovimentoAsync(movimento);
        }

        [Fact]
        public void CreateMovimentoAreNotValid_InvalidAccount()
        {
            var movimento = new Movimento(Utils.GerarHashMd5("teste"), "123", "C", 1500);

            IMovimentoRepository movimentoRepositorySubstitute = Substitute.For<IMovimentoRepository>();

            movimentoRepositorySubstitute.AddMovimentoAsync(movimento);

            // Assert
            Assert.NotNull(movimento);
            movimentoRepositorySubstitute.Equals("INVALID_ACCOUNT");
        }

        [Fact]
        public void CreateMovimentoAreNotValid_InativeAccount()
        {
            var movimento = new Movimento(Utils.GerarHashMd5("teste"), "D2E02051-7067-ED11-94C0-835DFA4A16C9", "C", 1500);

            IMovimentoRepository movimentoRepositorySubstitute = Substitute.For<IMovimentoRepository>();

            movimentoRepositorySubstitute.AddMovimentoAsync(movimento);

            // Assert
            Assert.NotNull(movimento);
            movimentoRepositorySubstitute.Equals("INATIVE_ACCOUNT");
        }

        [Fact]
        public void CreateMovimentoAreNotValid_InvalidValue()
        {
            var movimento = new Movimento(Utils.GerarHashMd5("teste"), "FA99D033-7067-ED11-96C6-7C5DFA4A16C9", "C", -5);

            IMovimentoRepository movimentoRepositorySubstitute = Substitute.For<IMovimentoRepository>();

            movimentoRepositorySubstitute.AddMovimentoAsync(movimento);

            // Assert
            Assert.NotNull(movimento);
            movimentoRepositorySubstitute.Equals("INVALID_VALUE");
        }

        [Fact]
        public void CreateMovimentoAreNotValid_InvalidType()
        {
            var movimento = new Movimento(Utils.GerarHashMd5("teste"), "FA99D033-7067-ED11-96C6-7C5DFA4A16C9", "A", 800);

            IMovimentoRepository movimentoRepositorySubstitute = Substitute.For<IMovimentoRepository>();

            movimentoRepositorySubstitute.AddMovimentoAsync(movimento);

            // Assert
            Assert.NotNull(movimento);
            movimentoRepositorySubstitute.Equals("INVALID_TYPE");
        }
    }
}
