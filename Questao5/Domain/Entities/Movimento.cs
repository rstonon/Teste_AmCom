using FluentValidation;
using Questao5.Application.Commands.CreateMovimento;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public Movimento(string idMovimento, string idContaCorrente, string tipoMovimento, decimal valor)
        {
            IdMovimento = idMovimento;
            IdContaCorrente = idContaCorrente.ToString();
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }

        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }

    public class MovimentoValidator : AbstractValidator<CreateMovimentoCommand>
    {
        public MovimentoValidator()
        {
            var conditions = new List<string>() { "C", "D" };
            RuleFor(m => m.TipoMovimento)
              .Must(m => conditions.Contains(m))
              .WithErrorCode("INVALID_TYPE")
              .WithMessage("O Tipo do Movimento só pode ser C ou D");

            RuleFor(m => m.Valor).GreaterThan(0)
                .WithErrorCode("INVALID_VALUE")
                .WithMessage("O Valor deve ser maior que 0");
        }
    }
}
