using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.GetContaCorrente;
using Questao5.Application.Queries.GetSaldo;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/saldo")]
    public class SaldoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ContaCorrenteValidator _contaCorrenteValidator;
        public SaldoController(IMediator mediator, ContaCorrenteValidator contaCorrenteValidator)
        {
            _mediator = mediator;
            _contaCorrenteValidator = contaCorrenteValidator;

        }

        [HttpGet]
        public async Task<IActionResult> Get(string idContaCorrente)
        {
            var query = new GetContaCorrenteQuery(idContaCorrente);

            var conta = await _mediator.Send(query);

            if (conta == null)
            {
                var erro = new ValidationFailure();
                erro.ErrorCode = "INVALID_ACCOUNT";
                erro.ErrorMessage = "Só é permitido consultar contas cadastradas";

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

            var sql = new GetSaldoQuery(idContaCorrente);

            var saldo = await _mediator.Send(sql);

            return Ok(saldo);
        }
    }
}
