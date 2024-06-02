using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Services;

namespace RedesSociaisApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(
            IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterConta( int id)
        {
            var result = _contaService.GetById(id);

            if(!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Cadastrar(CreateContaInputModel model)
        {
            var result = _contaService.Insert(model);

            return CreatedAtAction(nameof(ObterConta), new { id = result} , model);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateContaInputModel model)
        {
            var result = _contaService.Update(id, model);

            return !result.IsSuccess ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var result = _contaService.Delete(id);

            return !result.IsSuccess ? NotFound() : NoContent();

        }

        [HttpPut("mudar-senha/{id}")]
        public IActionResult MudarSenha(int id, UpdateSenhaContaInputModel model)
        {
            var result = _contaService.MudarSenha(id, model);

            return !result.IsSuccess ? NotFound() : NoContent();
        }

        [HttpPut("login")]
        public IActionResult Login (LoginInputModel model)
        {
            var result = _contaService.Login(model);
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }



    }
}