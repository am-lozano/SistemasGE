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
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaUseCases _personasUseCase;

        public PersonasController(IPersonaUseCases personasUseCase)
        {
            _personasUseCase = personasUseCase;
        }

        // GET: api/personas
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _personasUseCase.getPersonas();

                if (lista == null || lista.Count == 0)
                    return NoContent();

                return Ok(lista);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/personas/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var persona = _personasUseCase.getPersona(id);

                if (persona == null)
                    return NotFound();

                return Ok(persona);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/personas
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            try
            {
                int filas = _personasUseCase.addPersona(persona);

                if (filas == 0)
                    return BadRequest();

                return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/personas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id)
                return BadRequest("IDs no coinciden");

            try
            {
                int filas = _personasUseCase.updatePersona(id, persona);

                if (filas == 0)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/personas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int filas = _personasUseCase.deletePersona(id);

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
