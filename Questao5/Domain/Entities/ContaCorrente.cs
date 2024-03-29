using FluentValidation;
using Questao5.Application.Queries.GetContaCorrente;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {
            
        }
        public ContaCorrente(string idContaCorrente, int numero, string nome, int ativo)
        {
            IdContaCorrente = idContaCorrente;
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }

        public string IdContaCorrente { get; set; }
        public int  Numero { get; set; }
        public string  Nome { get; set; }
        public int  Ativo { get; set; }
    }

    public class ContaCorrenteValidator : AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidator()
        {
            RuleFor(c => c.Ativo).Equal(1)
                .WithErrorCode("INACTIVE_ACCOUNT")
                .WithMessage("A Conta Corrente deve estar ativa.");
        }
    }
}
