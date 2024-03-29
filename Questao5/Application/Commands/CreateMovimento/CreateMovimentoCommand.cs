using MediatR;

namespace Questao5.Application.Commands.CreateMovimento
{
    public class CreateMovimentoCommand : IRequest<string>
    {
        public CreateMovimentoCommand(string idMovimento, string idContaCorrente, string tipoMovimento, decimal valor)
        {
            IdMovimento = idMovimento;
            IdContaCorrente = idContaCorrente;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }

        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
