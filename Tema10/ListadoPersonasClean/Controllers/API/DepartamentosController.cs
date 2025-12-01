using Domain.Entities;
using Domain.Interfaces;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoUseCases _departamentosUseCase;

        public DepartamentosController(IDepartamentoUseCases departamentosUseCase)
        {
            _departamentosUseCase = departamentosUseCase;
        }

        // GET: api/departamentos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _departamentosUseCase.getDepartamentos();

                if (lista == null || lista.Count == 0)
                    return NoContent();

                return Ok(lista);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/departamentos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var departamento = _departamentosUseCase.getDepartamento(id);

                if (departamento == null)
                    return NotFound();

                return Ok(departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/departamentos
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                int filas = _departamentosUseCase.addDepartamento(departamento);

                if (filas == 0)
                    return BadRequest();

                return CreatedAtAction(nameof(Get), new { id = departamento.IdDepartamento }, departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/departamentos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            if (id != departamento.IdDepartamento)
                return BadRequest("IDs no coinciden");

            try
            {
                int filas = _departamentosUseCase.updateDepartamento(id, departamento);

                if (filas == 0)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/departamentos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int filas = _departamentosUseCase.deleteDepartamento(id);

                if (filas == 0)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
