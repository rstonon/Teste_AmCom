using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.CreateMovimento;
using Questao5.Application.Queries.GetContaCorrente;
using Questao5.Domain.Entities;
using IdempotentAPI.Filters;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/movimento")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Idempotent(Enabled = true)]
    public class MovimentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ContaCorrenteValidator _contaCorrenteValidator;
        private readonly MovimentoValidator _movimentoValidator;

        public MovimentoController(IMediator mediator, ContaCorrenteValidator contaCorrenteValidator, MovimentoValidator movimentoValidator)
        {
            _mediator = mediator;
            _contaCorrenteValidator = contaCorrenteValidator;
            _movimentoValidator = movimentoValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovimentoCommand command)
        {
            var query = new GetContaCorrenteQuery(command.IdContaCorrente);

            var conta = await _mediator.Send(query);

            if (conta == null)
            {
                var erro = new ValidationFailure();
                erro.ErrorCode = "INVALID_ACCOUNT";
                erro.ErrorMessage = "Só é permitido movimentar contas cadastradas";

                var result = new ValidationResult();
                result.Errors.Add(erro);

                var messages = result.Errors.Select(r => new { r.ErrorCode, r.ErrorMessage });

                return BadRequest(messages);

            }

            var results = await _contaCorrenteValidator.ValidateAsync(conta);

            if (!results.IsValid)
            {
                var messages = results.Errors.Select(r => new { r.ErrorCode, r.ErrorMessage });
                //var error = $"{results.Errors.FirstOrDefault().ErrorMessage} / CODE: {results.Errors.FirstOrDefault().ErrorCode}";
                return BadRequest(messages);
            }

            results = await _movimentoValidator.ValidateAsync(command);

            if (!results.IsValid)
            {
                var messages = results.Errors.Select(r => new { r.ErrorCode, r.ErrorMessage });
                //var error = $"{results.Errors.FirstOrDefault().ErrorMessage} / CODE: {results.Errors.FirstOrDefault().ErrorCode}";
                return BadRequest(messages);
            }

            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
